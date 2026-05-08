using System.Text.Json;
using HtmlAgilityPack;

namespace Dziekanowka.Mechanizm
{
    public static class WyswietlanieSlowa
    {
        private static readonly string _bazowa = Path.Combine(AppContext.BaseDirectory, "wwwroot", "Slowo");
        private static async Task<JsonElement> PobierzJson(string ksiega)
        {
            var sciezka = Path.Combine(_bazowa, "Biblia", $"{ksiega}.json");
            var json = await File.ReadAllTextAsync(sciezka, System.Text.Encoding.UTF8);
            return JsonSerializer.Deserialize<JsonElement>(json);
        }
        private static bool CzyWerset(HtmlNode node) => (node.Name == "p" || node.Name == "span") && node.GetAttributeValue("class", "").Contains("werset") && !node.GetAttributeValue("class", "").Contains("psalm");
        private static bool CzyPsalm(HtmlNode node) => (node.Name == "p" || node.Name == "span") && node.GetAttributeValue("class", "").Contains("psalm");
        private static bool CzyEwangelia(HtmlNode node) => node.Name == "div" && node.GetAttributeValue("class", "").Contains("Ewangelia");
        private static bool CzyOdstep(HtmlNode node) => node.Name == "div" && node.GetAttributeValue("class", "").Contains("odstep");
        private static async Task UzupelnijWerset(HtmlNode node)
        {
            var dataRef = node.GetAttributeValue("data-ref", "");
            if (string.IsNullOrEmpty(dataRef)) return;
            var czesci = dataRef.Trim().Split(' ');
            var ksiega = czesci[0];
            var zakresy = czesci[1].Split('.');
            var rozdzial = zakresy[0].Split(',')[0];
            var dane = await PobierzJson(ksiega);
            bool czyPsalm = node.GetAttributeValue("class", "").Contains("psalm");
            node.InnerHtml = ZbierzTekst(dane, rozdzial, zakresy, czyPsalm);
        }
        private static string ZbierzTekst(JsonElement dane, string rozdzial, string[] zakresy, bool czyPsalm)
        {
            var linie = new List<string>();
            foreach (var zakres in zakresy)
            {
                var wersetStr = zakres.Contains(',') ? zakres.Split(',')[1] : zakres;
                if (czyPsalm)
                {
                    if (dane.TryGetProperty(rozdzial, out var r) && r.TryGetProperty(wersetStr, out var w))
                        linie.Add(w.GetString() ?? "");
                }
                else if (wersetStr.Contains('-'))
                {
                    var czesciZakresu = wersetStr.Split('-');
                    var odStr = czesciZakresu[0];
                    var doStr = czesciZakresu[1];
                    if (System.Text.RegularExpressions.Regex.IsMatch(odStr, @"[a-z]$"))
                    {
                        if (dane.TryGetProperty(rozdzial, out var r) && r.TryGetProperty(odStr, out var w))
                            linie.Add(w.GetString() ?? "");
                    }
                    var od = int.Parse(System.Text.RegularExpressions.Regex.Match(odStr, @"\d+").Value);
                    var doNum = int.Parse(System.Text.RegularExpressions.Regex.Match(doStr, @"\d+").Value);
                    var odNum = System.Text.RegularExpressions.Regex.IsMatch(odStr, @"[a-z]$") ? od + 1 : od;
                    var doNum2 = System.Text.RegularExpressions.Regex.IsMatch(doStr, @"[a-z]$") ? doNum - 1 : doNum;
                    for (int i = odNum; i <= doNum2; i++)
                    {
                        if (dane.TryGetProperty(rozdzial, out var r) && r.TryGetProperty(i.ToString(), out var w))
                            linie.Add(w.GetString() ?? "");
                    }
                    if (System.Text.RegularExpressions.Regex.IsMatch(doStr, @"[a-z]$"))
                    {
                        if (dane.TryGetProperty(rozdzial, out var r) && r.TryGetProperty(doStr, out var w))
                            linie.Add(w.GetString() ?? "");
                    }
                }
                else
                {
                    if (dane.TryGetProperty(rozdzial, out var r) && r.TryGetProperty(wersetStr, out var w))
                        linie.Add(w.GetString() ?? "");
                }
            }
            return czyPsalm ? string.Join("<br>", linie) : string.Join(" ", linie);
        }
        private static async Task<string> BudujGrupy(HtmlNode fragment)
        {
            var dzieci = fragment.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Element && !CzyOdstep(n)).ToList();
            var grupy = new List<(string klasa, List<HtmlNode> nodes)>();
            var aktualnaGrupa = new List<HtmlNode>();
            string aktualnaKlasa = "";
            bool psalmaOtwarta = false;
            foreach (var node in dzieci)
            {
                if (CzyEwangelia(node))
                {
                    var wersetEwangelii = node.SelectSingleNode(".//*[contains(@class,'werset')]");
                    if (wersetEwangelii != null)
                        await UzupelnijWerset(wersetEwangelii);
                    if (aktualnaGrupa.Count > 0)
                    {
                        var aklamacja = aktualnaGrupa.Last();
                        aktualnaGrupa.RemoveAt(aktualnaGrupa.Count - 1);
                        if (aktualnaGrupa.Count > 0)
                            grupy.Add((aktualnaKlasa, aktualnaGrupa));
                        aktualnaGrupa = new List<HtmlNode> { aklamacja, node };
                    }
                    else
                        aktualnaGrupa.Add(node);
                    grupy.Add(("ewangelia", aktualnaGrupa));
                    aktualnaGrupa = new List<HtmlNode>();
                    aktualnaKlasa = "";
                    psalmaOtwarta = false;
                }
                else if (CzyPsalm(node))
                {
                    if (!psalmaOtwarta)
                    {
                        if (aktualnaGrupa.Count > 0)
                            grupy.Add((aktualnaKlasa, aktualnaGrupa));
                        aktualnaGrupa = new List<HtmlNode>();
                        psalmaOtwarta = true;
                        aktualnaKlasa = "psalm";
                    }
                    await UzupelnijWerset(node);
                    aktualnaGrupa.Add(node);
                }
                else if (CzyWerset(node))
                {
                    if (psalmaOtwarta || aktualnaKlasa != "czytanie")
                    {
                        if (aktualnaGrupa.Count > 0)
                            grupy.Add((aktualnaKlasa, aktualnaGrupa));
                        aktualnaGrupa = new List<HtmlNode>();
                        psalmaOtwarta = false;
                        aktualnaKlasa = "czytanie";
                    }
                    await UzupelnijWerset(node);
                    aktualnaGrupa.Add(node);
                }
                else
                {
                    if (aktualnaKlasa == "czytanie")
                    {
                        if (aktualnaGrupa.Count > 0)
                            grupy.Add((aktualnaKlasa, aktualnaGrupa));
                        aktualnaGrupa = new List<HtmlNode> { node };
                        aktualnaKlasa = "psalm";
                        psalmaOtwarta = true;
                    }
                    else
                        aktualnaGrupa.Add(node);
                }
            }
            if (aktualnaGrupa.Count > 0)
                grupy.Add((aktualnaKlasa, aktualnaGrupa));
            var sb = new System.Text.StringBuilder();
            foreach (var (klasa, nodes) in grupy)
            {
                sb.Append($"<div class=\"grupa {klasa}\">");
                foreach (var n in nodes)
                    sb.Append(n.OuterHtml);
                sb.Append("</div>");
            }
            return sb.ToString();
        }

        public static async Task<string> PobierzFragment(string nazwaPliku)
        {
            var sciezka = Path.Combine(_bazowa, "Slowo", $"{nazwaPliku}.html");
            var html = await File.ReadAllTextAsync(sciezka, System.Text.Encoding.UTF8);
            var doc = new HtmlDocument();
            doc.OptionOutputAsXml = false;
            doc.OptionAutoCloseOnEnd = false;
            doc.OptionCheckSyntax = false;
            doc.LoadHtml(html);
            var fragment = doc.DocumentNode.SelectSingleNode("//*[@id='fragment']");
            if (fragment == null) return "";
            return await BudujGrupy(fragment);
        }
        public static async Task<List<string>> PobierzDzisiejszeFragmenty()
        {
            var pliki = PobierzDzis();
            var wyniki = new List<string>();
            foreach (var plik in pliki)
                wyniki.Add(await PobierzFragment(plik));
            return wyniki;
        }
        public static string[] PobierzDzis() => Klucz.TryGetValue(DateTime.Now.ToString("yyyyMMdd"), out var pliki) ? pliki : [];

        public static readonly Dictionary<string, string[]> Klucz = new()
        {
            ["20260506"] = ["FilipaJakubaApostolow"],
            ["20260507"] = ["cz5Wlk"],
            ["20260508"] = ["StanislawaBiskupaMeczennikaPatronaPolski"],
            ["20260509"] = ["sb5Wlk", "NMPLaskawejPatronkiWarszawy"],
            ["20260510"] = ["Ndz6WlkA"],
            ["20260511"] = ["pn6Wlk"],
            ["20260512"] = ["wt6Wlk"],
            ["20260513"] = ["sr6Wlk"],
            ["20260514"] = ["MaciejaApostola"],
            ["20260515"] = ["pt6Wlk"],
            ["20260516"] = ["AndrzejaBoboliPatronaPolskiMetropoliiWarszawskiej"],
            ["20260517"] = ["WniebowstapieniePanskieA"],
            ["20260518"] = ["pn7Wlk"],
            ["20260519"] = ["wt7Wlk"],
            ["20260520"] = ["sr7Wlk"],
            ["20260521"] = ["cz7Wlk"],
            ["20260522"] = ["pt7Wlk"],
            ["20260523"] = ["sb7Wlk", "WigiliaZeslaniaDuchaSwietego"],
            ["20260524"] = ["ZeslanieDuchaSwietegoA"],
            ["20260525"] = ["NMPMatkiKosciola"],
            ["20260526"] = ["wt8zwII"],
            ["20260527"] = ["sr8zwII"],
            ["20260528"] = ["JezusaChrystusaNajwyzszegoIWiecznegoKaplanaA"],
            ["20260529"] = ["pt8zwII", "UrszuliLedochowskiejzw"],
            ["20260530"] = ["sb8zwII"],
            ["20260531"] = ["NajswietszejTrojcyA"],
            ["20260601"] = ["pn9zwII"],
            ["20260602"] = ["wt9zwII"],
            ["20260603"] = ["sr9zwII"],
            ["20260604"] = ["NajswietszegoCialaIKrwiChrystusaA"],
            ["20260605"] = ["pt9zwII"],
            ["20260606"] = ["sb9zwII"],
            ["20260607"] = ["Ndz10zwA"],
            ["20260608"] = ["pn10zwII"],
            ["20260609"] = ["wt10zwII"],
            ["20260610"] = ["sr10zwII"],
            ["20260611"] = ["cz10zwII", "BarnabyApostola"],
            ["20260612"] = ["NajswietszegoSercaPanaJezusaA"],
            ["20260613"] = ["sb10zwII"],
            ["20260614"] = ["Ndz11zwA"],
            ["20260615"] = ["pn11zwII"],
            ["20260616"] = ["wt11zwII"],
            ["20260617"] = ["sr11zwII", "BrataAlbertaChmielowskiego"],
            ["20260618"] = ["cz11zwII"],
            ["20260619"] = ["pt11zwII"],
            ["20260620"] = ["sb11zwII"],
            ["20260621"] = ["Ndz12zwA"],
            ["20260622"] = ["pn12zwII"],
            ["20260623"] = ["wt12zwII", "WigiliaNarodzeniaJanaChrzciciela"],
            ["20260624"] = ["NarodzenieJanaChrzciciela"],
            ["20260625"] = ["cz12zwII"],
            ["20260626"] = ["pt12zwII"],
            ["20260627"] = ["sb12zwII"]
        };
    }
}