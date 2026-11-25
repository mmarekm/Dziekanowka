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
            ["20261125"] = ["sr34zwII"],
            ["20261126"] = ["cz34zwII"],
            ["20261127"] = ["pt34zwII"],
            ["20261128"] = ["sb34zwII"],
            ["20261129"] = ["Ndz1AdwB"],
            ["20261130"] = ["AndrzejaApostola"],
            ["20261201"] = ["wt1Adw"],
            ["20261202"] = ["sr1Adw"],
            ["20261203"] = ["cz1Adw", "FranciszkaKsawerego"],
            ["20261204"] = ["pt1Adw", "Barbary"],
            ["20261205"] = ["sb1Adw"],
            ["20261206"] = ["Ndz2AdwB"],
            ["20261207"] = ["pn2Adw", "AmbrozegoBiskupaDoktoraKosciola"],
            ["20261208"] = ["NiepokalanePoczecieNMP"],
            ["20261209"] = ["sr2Adw"],
            ["20261210"] = ["cz2Adw"],
            ["20261211"] = ["pt2Adw"],
            ["20261212"] = ["sb2Adw", "NMPZGuadalupe"],
            ["20261213"] = ["Ndz3AdwB"],
            ["20261214"] = ["pn3Adw", "JanaOdKrzyzaPrezbiteraIDoktoraKosciola"],
            ["20261215"] = ["wt3Adw"],
            ["20261216"] = ["sr3Adw"],
            ["20261217"] = ["grudzien17"],
            ["20261218"] = ["grudzien18"],
            ["20261219"] = ["grudzien19"],
            ["20261220"] = ["Ndz4AdwB"],
            ["20261221"] = ["grudzien21"],
            ["20261222"] = ["grudzien22"],
            ["20261223"] = ["grudzien23"],
            ["20261224"] = ["grudzien24", "WigiliaNarodzeniaPanskiego"],
            ["20261225"] = ["NocNarodzeniaPanskiego", "SwitNarodzeniaPanskiego", "DzienNarodzeniaPanskiego"],
            ["20261226"] = ["SzczepanaPierwszegoMeczennika"],
            ["20261227"] = ["NdzSwietejRodzinyB"],
            ["20261228"] = ["MlodziankowMeczennikow"],
            ["20261229"] = ["grudzien29"],
            ["20261230"] = ["grudzien30"],
            ["20261231"] = ["grudzien31"],
            ["20270101"] = ["SwietejBozejRodzicielkiMaryi"],
            ["20270102"] = ["styczen2", "BazylegoWielkiegoIGrzegorzaZNazjanzuBiskupowDoktorowKosciola"],
            ["20270103"] = ["Ndz2PoNarodzeniuPanskim"],
            ["20270104"] = ["styczen4"],
            ["20270105"] = ["styczen5"],
            ["20270106"] = ["ObjawieniePanskie"],
            ["20270107"] = ["styczen7"],
            ["20270108"] = ["styczen8"],
            ["20270109"] = ["styczen9"],
            ["20270110"] = ["ChrzestPanskiB"],
            ["20270111"] = ["pn1zwI"],
            ["20270112"] = ["wt1zwI"],
            ["20270113"] = ["sr1zwI"],
            ["20270114"] = ["cz1zwI"],
            ["20270115"] = ["pt1zwI"],
            ["20270116"] = ["sb1zwI"],
            ["20270117"] = ["Ndz2zwB"],
            ["20270118"] = ["pn2zwI"],
            ["20270119"] = ["wt2zwI", "JozefaSebastianaPelczara"],
            ["20270120"] = ["sr2zwI"],
            ["20270121"] = ["cz2zwI", "Agnieszki"],
            ["20270122"] = ["pt2zwI"],
            ["20270123"] = ["sb2zwI"],
            ["20270124"] = ["Ndz3zwB"],
            ["20270125"] = ["NawroceniePawlaApostola"],
            ["20270126"] = ["wt3zwI", "BiskupowTymoteuszaITytusa"],
            ["20270127"] = ["sr3zwI"],
            ["20270128"] = ["cz3zwI", "TomaszaZAkwinuDoktoraKosciola"],
            ["20270129"] = ["pt3zwI"],
            ["20270130"] = ["sb3zwI"],
            ["20270131"] = ["Ndz4zwB"],
            ["20270201"] = ["pn4zwI"],
            ["20270202"] = ["OfiarowaniePanskie"],
            ["20270203"] = ["sr4zwI"],
            ["20270204"] = ["cz4zwI"],
            ["20270205"] = ["pt4zwI", "Agaty"],
            ["20270206"] = ["sb4zwI", "PawlaMikiITowarzyszy"],
            ["20270207"] = ["Ndz5zwB"],
            ["20270208"] = ["pn5zwI"],
            ["20270209"] = ["wt5zwI"],
            ["20270210"] = ["srPopielcowa"],
            ["20270211"] = ["czPoPopielcu", "NMPZLourdes"],
            ["20270212"] = ["ptPoPopielcu"],
            ["20270213"] = ["sbPoPopielcu"],
            ["20270214"] = ["Ndz1WPB"],
            ["20270215"] = ["pn1WP"],
            ["20270216"] = ["wt1WP"],
            ["20270217"] = ["sr1WP"],
            ["20270218"] = ["cz1WP"],
            ["20270219"] = ["pt1WP"],
            ["20270220"] = ["sb1WP"],
            ["20270221"] = ["Ndz2WPB"],
            ["20270222"] = ["KatedryPiotra"],
            ["20270223"] = ["wt2WP", "Polikarpa"],
            ["20270224"] = ["sr2WP"],
            ["20270225"] = ["cz2WP"],
            ["20270226"] = ["pt2WP"],
            ["20270227"] = ["sb2WP"],
            ["20270228"] = ["Ndz3WPB"],
            ["20270301"] = ["pn3WP"],
            ["20270302"] = ["wt3WP"],
            ["20270303"] = ["sr3WP"],
            ["20270304"] = ["KazimierzaKrolewicza"],
            ["20270305"] = ["pt3WP"],
            ["20270306"] = ["sb3WP"],
            ["20270307"] = ["Ndz4WPB"],
            ["20270308"] = ["pn4WP"],
            ["20270309"] = ["wt4WP"],
            ["20270310"] = ["sr4WP"],
            ["20270311"] = ["cz4WP"],
            ["20270312"] = ["pt4WP"],
            ["20270313"] = ["sb4WP"],
            ["20270314"] = ["Ndz5WPB"],
            ["20270315"] = ["pn5WP", "Klemensa"],
            ["20270316"] = ["wt5WP"],
            ["20270317"] = ["sr5WP"],
            ["20270318"] = ["cz5WP"],
            ["20270319"] = ["JozefaOblubiencaNMP"],
            ["20270320"] = ["sb5WP"],
            ["20270321"] = ["NdzPalmowaB"],
            ["20270322"] = ["wielkiPn"],
            ["20270323"] = ["wielkiWt"],
            ["20270324"] = ["wielkaSr"],
            ["20270325"] = ["wielkiCz"],
            ["20270326"] = ["wielkiPt"],
            ["20270327"] = ["WigiliaPaschalnaB"],
            ["20270328"] = ["ZmartwychwstaniePanskie"],
            ["20270329"] = ["PnWlk"],
            ["20270330"] = ["WtWlk"],
            ["20270331"] = ["SrWlk"],
            ["20270401"] = ["CzWlk"],
            ["20270402"] = ["PtWlk"],
            ["20270403"] = ["SbWlk"]
        };
    };
}