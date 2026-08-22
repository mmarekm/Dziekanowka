using Dziekanowka.Gracza;
namespace Dziekanowka.Mechanizm
{
    public static class Gra
    {
        public static bool JestZwierze(this Gracz g, string zwierz) => g.Zwierzeta.Any(z => z.Nazwa == zwierz && z.Ilosc > 0);
        public static bool JestProduktZ(this Gracz g, string produkt) => g.ProduktyZwierzece.Any(p => p.Nazwa == produkt && p.Ilosc > 0);
        public static bool JestProduktP(this Gracz g, string produkt) => g.ProduktyPrzetworzone.Any(p => p.Nazwa == produkt && p.Ilosc > 0);
        public static bool JestZywnoscP(this Gracz g, string produkt) => g.ZywnoscPozostala.Any(p => p.Nazwa == produkt && p.Ilosc > 0);
        public static bool JestWarzywo(this Gracz g, string warzywo) => g.Warzywa.Any(w => w.Nazwa == warzywo && w.Ilosc > 0);
        public static bool JestZboze(this Gracz g, string zboze) => g.Zboza.Any(w => w.Nazwa == zboze && w.Ilosc > 0);
        public static bool JestOwoc(this Gracz g, string owoc) => g.Owoce.Any(o => o.Nazwa == owoc && o.Ilosc > 0);
        public static bool JestGrzyb(this Gracz g, string grzyb) => g.Grzyby.Any(g => g.Nazwa == grzyb && g.Ilosc > 0);
        public static bool JestRyba(this Gracz g, string ryba) => g.Ryby.Any(r => r.Nazwa == ryba && r.Ilosc > 0);
        public static bool JestDar(this Gracz g, string dar) => g.ProduktyZwierzece.Any(p => p.Nazwa == dar && p.Ilosc > 0) || g.ProduktyPrzetworzone.Any(p => p.Nazwa == dar && p.Ilosc > 0) || g.ZywnoscPozostala.Any(p => p.Nazwa == dar && p.Ilosc > 0) || g.Warzywa.Any(w => w.Nazwa == dar && w.Ilosc > 0) || g.Zboza.Any(z => z.Nazwa == dar && z.Ilosc > 0) || g.Owoce.Any(o => o.Nazwa == dar && o.Ilosc > 0) || g.Grzyby.Any(gr => gr.Nazwa == dar && gr.Ilosc > 0) || g.Ryby.Any(r => r.Nazwa == dar && r.Ilosc > 0);
        public static bool JestObiad(this Gracz g, string obiad) => g.Obiady.Any(o => o.Nazwa == obiad && o.Ilosc > 0);
        public static bool JestPrzedmiot(this Gracz g, string przedmiot) => g.Przedmioty.Any(p => p.Nazwa == przedmiot && p.Ilosc > 0);
        public static bool JestDzielo(this Gracz g, string dzielo) => g.DzielaZPiorIFutra.Any(d => d.Nazwa == dzielo && d.Ilosc > 0);
        public static ZwierzeGracza Zwierze(this Gracz g, string zwierz) => g.Zwierzeta.First(z => z.Nazwa == zwierz);
        public static IDar ProduktZ(this Gracz g, string produkt) => g.ProduktyZwierzece.First(p => p.Nazwa == produkt);
        public static IDar ProduktP(this Gracz g, string produkt) => g.ProduktyPrzetworzone.First(p => p.Nazwa == produkt);
        public static IDar ZywnoscP(this Gracz g, string zywnosc) => g.ZywnoscPozostala.First(z => z.Nazwa == zywnosc);
        public static IDar Warzywo(this Gracz g, string warzywo) => g.Warzywa.First(w => w.Nazwa == warzywo);
        public static IDar Zboze(this Gracz g, string zboze) => g.Zboza.First(z => z.Nazwa == zboze);
        public static IDar Owoc(this Gracz g, string owoc) => g.Owoce.First(o => o.Nazwa == owoc);
        public static IDar Grzyb(this Gracz g, string grzyb) => g.Grzyby.First(g => g.Nazwa == grzyb);
        public static IDar Ryba(this Gracz g, string ryba) => g.Ryby.First(r => r.Nazwa == ryba);
        public static IDar Dar(this Gracz g, string dar)
        {
            if (g.ProduktyZwierzece.Any(p => p.Nazwa == dar)) return g.ProduktyZwierzece.First(p => p.Nazwa == dar);
            if (g.ProduktyPrzetworzone.Any(p => p.Nazwa == dar)) return g.ProduktyPrzetworzone.First(p => p.Nazwa == dar);
            if (g.ZywnoscPozostala.Any(z => z.Nazwa == dar)) return g.ZywnoscPozostala.First(z => z.Nazwa == dar);
            if (g.Warzywa.Any(w => w.Nazwa == dar)) return g.Warzywa.First(w => w.Nazwa == dar);
            if (g.Zboza.Any(z => z.Nazwa == dar)) return g.Zboza.First(z => z.Nazwa == dar);
            if (g.Owoce.Any(o => o.Nazwa == dar)) return g.Owoce.First(o => o.Nazwa == dar);
            if (g.Grzyby.Any(gr => gr.Nazwa == dar)) return g.Grzyby.First(gr => gr.Nazwa == dar);
            if (g.Ryby.Any(r => r.Nazwa == dar)) return g.Ryby.First(r => r.Nazwa == dar);
            throw new InvalidOperationException($"Nie znaleziono daru: {dar}");
        }
        public static IDar Obiad(this Gracz g, string obiad) => g.Obiady.First(o => o.Nazwa == obiad);
        public static IDar Przedmiot(this Gracz g, string przedmiot) => g.Przedmioty.First(p => p.Nazwa == przedmiot);
        public static DzieloZPiorIFutra Dzielo(this Gracz g, string dzielo) => g.DzielaZPiorIFutra.First(d => d.Nazwa == dzielo);
        public static string[] Sklepiczek = ["kosc", ""];
        public static string[] SklepiczekWymagane = ["zielonaKuleczka", ""];
        public static List<string> ZwierzetaNaDrodze = ["krowa", "owca", "koza", "koń", "słoń", "żyrafa"];
        public static readonly List<string> WszystkieMisje = [Misje.Chlopiec, Misje.Kot, Misje.FanZdrowia, Misje.DomMleka, Misje.KuchniaMorska, Misje.SlodkaBuleczka, Misje.SeryLesne, Misje.PlatkiGorskie, Misje.Stajenny, Misje.WiesSurowkaWarzywna, Misje.PotrzebaKawy, Misje.OczekujacyPiorIFuter];
        private static readonly Dictionary<string, Func<string[]>> GeneratoryDanychMisji = new()
        {
            [Misje.Chlopiec] = () => [ZbiorChlopiecMiska![Random.Shared.Next(ZbiorChlopiecMiska.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.Kot] = () => [Ryby![Random.Shared.Next(Ryby.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.FanZdrowia] = () => [Warzywa![Random.Shared.Next(Warzywa.Count)], Owoce![Random.Shared.Next(Owoce.Count)], Soki![Random.Shared.Next(Soki.Count)], "", "", "", "", "", "", ""],
            [Misje.DomMleka] = () => [Mleka![Random.Shared.Next(Mleka.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.KuchniaMorska] = () => [Restauracja![Random.Shared.Next(Restauracja.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.SlodkaBuleczka] = () => [SlodkieBuleczki![Random.Shared.Next(SlodkieBuleczki.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.SeryLesne] = () => [Sery![Random.Shared.Next(Sery.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.PlatkiGorskie] = () => [Mleka![Random.Shared.Next(Mleka.Count)], Platki![Random.Shared.Next(Platki.Count)], "", "", "", "", "", "", "", ""],
            [Misje.Stajenny] = () => [Ciasta![Random.Shared.Next(Ciasta.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.PotrzebaKawy] = () => ["", "", "", "", "", "", "", "", "", ""],
            [Misje.OczekujacyPiorIFuter] = () => [OczekujacyPiorIFuter![Random.Shared.Next(OczekujacyPiorIFuter.Count)], "", "", "", "", "", "", "", "", ""],
            [Misje.WiesSurowkaWarzywna] = () =>
            {
                var kopiaSkladnikow = new List<string>(skladnikiSurowki!);
                var wybrane = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    int idx = Random.Shared.Next(kopiaSkladnikow.Count);
                    wybrane[i] = kopiaSkladnikow[idx];
                    kopiaSkladnikow.RemoveAt(idx);
                }
                return [startSurowki![Random.Shared.Next(startSurowki.Count)], wybrane[0], wybrane[1], wybrane[2], "", "", "", "", "", ""];
            }
        };
        public static string[] WylosujDaneMisji(string misja) => GeneratoryDanychMisji[misja]();
        public static string WylosujNastepnaMisje(List<string> worekMisji)
        {
            if (worekMisji.Count == 0)
                worekMisji.AddRange(WszystkieMisje);
            var indeks = Random.Shared.Next(worekMisji.Count);
            var wybranaMisja = worekMisji[indeks];
            worekMisji.RemoveAt(indeks);
            return wybranaMisja;
        }
        public static void LosujNowaMisje(this Gracz g)
        {
            g.Statystyki.MoznaOdebracObraz = true;
            g.Statystyki.AktualnaMisja = WylosujNastepnaMisje(g.Statystyki.BiezacyWorekMisji);
            g.Statystyki.DaneMisji = WylosujDaneMisji(g.Statystyki.AktualnaMisja);
        }
        public static List<string> ZbiorChlopiecMiska = ["rosol", "barszczCzerwony", "zurek", "krupnik", "zupaPomidorowa", "zupaOgorkowa", "zupaGrzybowa", "kapusniak", "grochowka", "zupaFasolowa", "zupaCebulowa", "chlodnik", "kremZBrokulow", "kremZDyni", "kremZKalafiora"];
        public static List<string> Ryby = ["losos", "pstrag", "halibut", "okon", "sledz"];
        public static List<string> Warzywa = ["kukurydza", "groch", "jarmuż", "pasternak", "pietruszka", "burak", "brukselka", "sorgo", "rzepaPastewna", "koniczyna", "sałata", "marchew", "ziemniak", "cebula", "szczypiorek", "pomidor", "papryka", "ogórek", "czosnek", "rzodkiewka", "szpinak", "rukola", "batat", "szczaw", "seler", "boćwina", "por", "fasola", "bób", "ciecierzyca", "bakłażan", "cukinia", "dynia", "brokuł", "kalafior", "kapustaWłoska", "kapustaPekińska", "szparagi", "selerNaciowy", "soczewica"];
        public static List<string> Owoce = ["brzoskwinia", "nektarynka", "morela", "śliwka", "wiśnia", "czereśnia", "jabłko", "gruszka", "truskawka", "malina", "jeżyna", "borówka", "porzeczkaCzerwona", "porzeczkaCzarna", "żurawina", "pomarańcza", "mandarynka", "cytryna", "grejpfrut", "banan", "ananas", "mango", "papaja", "marakuja", "kokos", "awokado", "arbuz", "melon", "winogronoJasne", "winogronoRóżowe", "winogronoCiemne", "kiwi"];
        public static List<string> Soki = ["marchewSok", "burakSok", "pomidorSok", "jabłkoSok", "pomarańczaSok", "grejpfrutSok", "cytrynaSok", "ananasSok", "brzoskwiniaSok", "morelaSok", "wiśniaSok", "truskawkaSok", "malinaSok", "borówkaSok", "porzeczkaCzarnaSok"];
        public static List<string> Mleka = ["krowaMleko", "kozaMleko", "owcaMleko"];
        public static List<string> Restauracja = ["karkowka", "gulasz", "pieczenWolowa", "indykDuszony", "krolikWWinie", "ratatouille", "leczo", "fasolkaPoBretonsku", "knedle", "lososGotowany", "rybaPoGrecku", "sledzWOleju", "jajecznica", "jajkoSadzone", "omlet", "shakshuka", "kotletSchabowy", "kotletMielony", "stek", "piersZKurczaka", "bitki", "indykSmazony", "krolikSmazony", "golabki", "pstragSmazony", "lososSmazony", "halibutSmazony", "okonSmazony", "sledzSmazony", "plackiZiemniaczane", "frytki", "pierogiRuskie", "pierogiZMiesem", "pierogiZKapustaIGrzybami", "pierogiZOwocami"];
        public static List<string> SlodkieBuleczki = ["brzoskwiniaBuleczka", "śliwkaBuleczka", "wiśniaBuleczka", "jabłkoBuleczka", "gruszkaBuleczka", "malinaBuleczka", "twarogBuleczka"];
        public static List<string> Sery = ["krowaSer", "kozaSer", "owcaSer"];
        public static List<string> Platki = ["zytoPlatki", "jeczmienPlatki", "pszenicaPlatki", "ryzPlatki", "owiesPlatki", "grykaPlatki", "orkiszPlatki", "kukurydzaPlatki"];
        public static List<string> Ciasta = ["sernik", "babkaPiaskowa", "jabłkoCiasto", "brzoskwiniaCiasto", "nektarynkaCiasto", "morelaCiasto", "śliwkaCiasto", "wiśniaCiasto", "gruszkaCiasto", "borówkaCiasto", "porzeczkaCzerwonaCiasto", "porzeczkaCzarnaCiasto", "truskawkaCiasto", "malinaCiasto", "pomarańczaCiasto", "ananasCiasto"];
        public static List<string> startSurowki = ["majonez", "kuraJajo", "gesJajo", "kaczkaJajo", "indykJajo"];
        public static List<string> skladnikiSurowki = ["marchew", "burak", "sałata", "pomidor", "papryka", "ogórek", "rzodkiewka", "szpinak", "rukola", "szczaw", "kapustaWłoska", "kapustaPekińska", "brokuł", "kukurydza", "groch", "fasola", "szparagi", "brukselka", "cebula", "szczypiorek", "czosnek", "ogorekKiszony", "kapustaKiszona", "burakKiszony"];
        public static List<string> OczekujacyPiorIFuter = ["ozdobaDoKapelusza", "zakladkaDoKsiazki", "pedzelDoMalowania", "pioroDoPisania", "maskotkaMala", "strzalaDoLuku", "poduszeczkaNaIgly", "wachlarzOzdobny", "czapkaZimowa", "kapeluszMixPior", "poduszkaMala", "mufkaNaRece", "wypchaneZwierzatko", "pomPomZestaw", "koldraPuchowa"];
    }
}