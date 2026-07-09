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
        public static string[] Sklepiczek = ["kosc", ""];
        public static string[] SklepiczekWymagane = ["zielonaKuleczka", ""];
        public static List<string> ZbiorChlopiecMiska = ["rosol", "barszczCzerwony", "zurek", "krupnik", "zupaPomidorowa", "zupaOgorkowa", "zupaGrzybowa", "kapusniak", "grochowka", "zupaFasolowa", "zupaCebulowa", "chlodnik", "kremZBrokulow", "kremZDyni", "kremZKalafiora"];
        public static List<string> Ryby = ["losos", "pstrag", "halibut", "okon", "sledz"];
        public static List<string> Warzywa = ["kukurydza", "groch", "jarmuż", "pasternak", "pietruszka", "burak", "brukselka", "sorgo", "rzepaPastewna", "koniczyna", "sałata", "marchew", "ziemniak", "cebula", "szczypiorek", "pomidor", "papryka", "ogórek", "czosnek", "rzodkiewka", "szpinak", "rukola", "batat", "szczaw", "seler", "boćwina", "por", "fasola", "bób", "ciecierzyca", "bakłażan", "cukinia", "dynia", "brokuł", "kalafior", "kapustaWłoska", "kapustaPekińska", "szparagi", "selerNaciowy", "soczewica"];
        public static List<string> Owoce = ["brzoskwinia", "nektarynka", "morela", "śliwka", "wiśnia", "czereśnia", "jabłko", "gruszka", "truskawka", "malina", "jeżyna", "borówka", "porzeczkaCzerwona", "porzeczkaCzarna", "żurawina", "pomarańcza", "mandarynka", "cytryna", "grejpfrut", "banan", "ananas", "mango", "papaja", "marakuja", "kokos", "awokado", "arbuz", "melon", "winogronoJasne", "winogronoRóżowe", "winogronoCiemne", "kiwi"];
        public static List<string> Soki = ["marchewSok", "burakSok", "pomidorSok", "jabłkoSok", "pomarańczaSok", "grejpfrutSok", "cytrynaSok", "ananasSok", "brzoskwiniaSok", "morelaSok", "wiśniaSok", "truskawkaSok", "malinaSok", "borówkaSok", "porzeczkaCzarnaSok"];
        public static List<string> Mleka = ["krowaMleko", "kozaMleko", "owcaMleko"];
    }
}