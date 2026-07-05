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
                    var wersety = node.SelectNodes(".//*[contains(@class,'werset')]");
                    if (wersety != null)
                        foreach (var w in wersety)
                            await UzupelnijWerset(w);
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
            ["20260705"] = ["Ndz14zwA"],
            ["20260706"] = ["pn14zwII", "MariiTeresyLedochowskiej"],
            ["20260707"] = ["wt14zwII"],
            ["20260708"] = ["sr14zwII", "JanaZDukli"],
            ["20260709"] = ["cz14zwII"],
            ["20260710"] = ["pt14zwII"],
            ["20260711"] = ["BenedyktaOpataPatronaEuropy"],
            ["20260712"] = ["Ndz15zwA"],
            ["20260713"] = ["pn15zwII", "PustelnikowAndrzejaSwieradaIBenedykta"],
            ["20260714"] = ["wt15zwII"],
            ["20260715"] = ["sr15zwII", "BonawenturyBiskupaDoktoraKosciola"],
            ["20260716"] = ["cz15zwII", "NMPZGoryKarmel"],
            ["20260717"] = ["pt15zwII"],
            ["20260718"] = ["sb15zwII"],
            ["20260719"] = ["Ndz16zwA"],
            ["20260720"] = ["pn16zwII"],
            ["20260721"] = ["wt16zwII"],
            ["20260722"] = ["MariiMagdaleny"],
            ["20260723"] = ["BrygidyPatronkiEuropy"],
            ["20260724"] = ["pt16zwII", "Kingi"],
            ["20260725"] = ["JakubaApostola"],
            ["20260726"] = ["Ndz17zwA"],
            ["20260727"] = ["pn17zwII"],
            ["20260728"] = ["wt17zwII"],
            ["20260729"] = ["sr17zwII", "MartyMariiILazarza"],
            ["20260730"] = ["cz17zwII"],
            ["20260731"] = ["pt17zwII", "IgnacegoZLoyoli"],
            ["20260801"] = ["sb17zwII", "AlfonsaMariiLiguoriegoBiskupaDoktoraKosciola"],
            ["20260802"] = ["Ndz18zwA"],
            ["20260803"] = ["pn18zwIIA"],
            ["20260804"] = ["wt18zwIIA", "JanaMariiVianneya"],
            ["20260805"] = ["sr18zwII"],
            ["20260806"] = ["PrzemienieniePanskieA"],
            ["20260807"] = ["pt18zwII"],
            ["20260808"] = ["sb18zwII", "Dominika"],
            ["20260809"] = ["Ndz19zwA"],
            ["20260810"] = ["Wawrzynca"],
            ["20260811"] = ["wt19zwII", "Klary"],
            ["20260812"] = ["sr19zwII"],
            ["20260813"] = ["cz19zwII"],
            ["20260814"] = ["pt19zwII", "MaksymilianaMariiKolbego", "WigiliaWniebowzieciaNMP"],
            ["20260815"] = ["WniebowziecieNMP"],
            ["20260816"] = ["Ndz20zwA"],
            ["20260817"] = ["pn20zwII", "Jacka"],
            ["20260818"] = ["wt20zwII"],
            ["20260819"] = ["sr20zwII"],
            ["20260820"] = ["cz20zwII", "BernardaOpataDoktoraKosciola"],
            ["20260821"] = ["pt20zwII", "PiusaX"],
            ["20260822"] = ["sb20zwII", "NMPKrolowej"],
            ["20260823"] = ["Ndz21zwA"],
            ["20260824"] = ["BartlomiejaApostola"],
            ["20260825"] = ["wt21zwII"],
            ["20260826"] = ["NMPCzestochowskiej"],
            ["20260827"] = ["cz21zwII", "Moniki"],
            ["20260828"] = ["pt21zwII", "AugustynaBiskupaDoktoraKosciola"],
            ["20260829"] = ["sb21zwII", "MeczenstwoJanaChrzciciela"],
            ["20260830"] = ["Ndz22zwA"],
            ["20260831"] = ["pn22zwII"],
            ["20260901"] = ["wt22zwII"],
            ["20260902"] = ["sr22zwII"],
            ["20260903"] = ["cz22zwII", "GrzegorzaWielkiegoPapiezaDoktoraKosciola"],
            ["20260904"] = ["pt22zwII"],
            ["20260905"] = ["sb22zwII"],
            ["20260906"] = ["Ndz23zwA"],
            ["20260907"] = ["pn23zwII"],
            ["20260908"] = ["NarodzenieNMP"],
            ["20260909"] = ["sr23zwII"],
            ["20260910"] = ["cz23zwII"],
            ["20260911"] = ["pt23zwII"],
            ["20260912"] = ["sb23zwII"],
            ["20260913"] = ["Ndz24zwA"],
            ["20260914"] = ["PodwyzszenieKrzyzaSwietego"],
            ["20260915"] = ["wt24zwII", "NMPBolesnej"],
            ["20260916"] = ["sr24zwII", "KorneliuszaPapiezaCyprianaBiskupaMeczennikow"],
            ["20260917"] = ["cz24zwII"],
            ["20260918"] = ["StanislawaKostki"],
            ["20260919"] = ["sb24zwII"],
            ["20260920"] = ["Ndz25zwA"],
            ["20260921"] = ["MateuszaApostolaIEwangelisty"],
            ["20260922"] = ["wt25zwII"],
            ["20260923"] = ["sr25zwII", "PioZPietrelciny"],
            ["20260924"] = ["cz25zwII"],
            ["20260925"] = ["pt25zwII"],
            ["20260926"] = ["sb25zwII"],
            ["20260927"] = ["Ndz26zwA"]
        };
    }
}