using Dziekanowka.Gracza;
using System.Text.Json;
namespace Dziekanowka.Mechanizm
{
    public class LadowanieGracza
    {
        private static readonly JsonSerializerOptions Opcje = new() { WriteIndented = true };
        private static readonly HashSet<string> ProduktyTrwale = new() { "pioroGesi", "pioroKaczki", "futroKrolik", "owcaSkora", "kozaSkora", "krowaSkora", "owcaWelna", "alpakaWelna", "miod" };
        private const int MaxZmianaGieldyGlownej = 10;
        private const int MaxZmianaGieldyMalej = 3;
        private const int MaxZmianaGieldyDuzej = 30;
        private readonly string _sciezkaDoPliku;
        private readonly string _sciezkaDoDanych;
        public Gracz? AktualnyGracz { get; private set; }
        public DaneGry? DaneGry { get; private set; }
        public event Action? NowyDzienEvent;
        public Dzwieki? Dzwieki;
        public bool CzyPokazacWideo { get; private set; } = false;
        public LadowanieGracza()
        {
            _sciezkaDoPliku = Path.Combine(AppContext.BaseDirectory, "gracze.json");
            _sciezkaDoDanych = Path.Combine(AppContext.BaseDirectory, "dziekanowka.json");
        }
        private bool CzyNowyDzien() => AktualnyGracz!.Statystyki.DzienLogowania != DateTime.Now.Day || AktualnyGracz.Statystyki.MiesiacLogowania != DateTime.Now.Month;
        private bool CzyNowyDzienDanych() => DaneGry!.DzienLogowania != DateTime.Now.Day || DaneGry.MiesiacLogowania != DateTime.Now.Month || DaneGry.GodzinaLogowania != DateTime.Now.Hour;
        public async Task<Gracz> ZaladujGracza(string nazwa)
        {
            await WczytajDaneGry();
            var gracze = await WczytajWszystkichGraczy();
            AktualnyGracz = gracze[nazwa.ToLower()];
            CzyPokazacWideo = false;
            await SprawdzenieCzyPierwszyRazWDniu();
            await SprawdzenieCzyPierwszyRazWDniuDanych();
            return AktualnyGracz;
        }
        public async Task ZapiszAktualnegoGracza()
        {
            var gracze = await WczytajWszystkichGraczy();
            gracze[AktualnyGracz!.Nazwa.ToLower()] = AktualnyGracz;
            await ZapiszWszystkichGraczy(gracze);
        }
        public async Task<string> PobierzHaslo(string nazwa)
        {
            var gracze = await WczytajWszystkichGraczy();
            return gracze[nazwa.ToLower()].Haslo;
        }
        public async Task<Gracz> PobierzGracza(string nazwa)
        {
            var gracze = await WczytajWszystkichGraczy();
            return gracze[nazwa.ToLower()];
        }
        public async Task ZmienMonetyWieluGraczy(Dictionary<string, int> zmiany)
        {
            var gracze = await WczytajWszystkichGraczy();
            foreach (var (nazwa, zmiana) in zmiany)
            {
                if (zmiana == 0) continue;
                var klucz = nazwa.ToLower();
                if (gracze.TryGetValue(klucz, out var g))
                    g.Monety += zmiana;
            }
            await ZapiszWszystkichGraczy(gracze);
            if (AktualnyGracz != null && gracze.TryGetValue(AktualnyGracz.Nazwa.ToLower(), out var aktualny))
                AktualnyGracz.Monety = aktualny.Monety;
        }
        public async Task ZapiszGracza(Gracz gracz)
        {
            var gracze = await WczytajWszystkichGraczy();
            gracze[gracz.Nazwa.ToLower()] = gracz;
            await ZapiszWszystkichGraczy(gracze);
        }
        private async Task SprawdzenieCzyPierwszyRazWDniu()
        {
            if (!CzyNowyDzien()) return;

            var gracz = AktualnyGracz!;
            ZapiszDateLogowania(gracz);
            PrzyznajBonusDzienny(gracz);
            ZuzyjZapasy(gracz);
            ResetujJedzenie(gracz);

            NowyDzienEvent?.Invoke();
            await ZapiszAktualnegoGracza();
            CzyPokazacWideo = true;
        }
        private static void ZapiszDateLogowania(Gracz gracz)
        {
            gracz.Statystyki.DzienLogowania = DateTime.Now.Day;
            gracz.Statystyki.MiesiacLogowania = DateTime.Now.Month;
        }
        private static void PrzyznajBonusDzienny(Gracz gracz)
        {
            gracz.Monety += gracz.Statystyki.BonusDzienny + gracz.Przedmiot("siano").Ilosc;
            gracz.Statystyki.Bonusy = ["miodUl", "kawaSalon", "karczowiskoSiano", "winoMorskie", "owceGorskie", "dzieciCiekawe", "pociagZGor"];
            gracz.Statystyki.ZwierzeNaDrodze = Gra.ZwierzetaNaDrodze[Random.Shared.Next(Gra.ZwierzetaNaDrodze.Count)];
        }
        private static int ZmniejszZapas(int ilosc) => ilosc > 0 ? ilosc - (ilosc / 5 + 1) : ilosc;
        private static void ZuzyjZapasy(Gracz gracz)
        {
            gracz.Warzywa.ForEach(w => w.Ilosc = ZmniejszZapas(w.Ilosc));
            gracz.Owoce.ForEach(o => o.Ilosc = ZmniejszZapas(o.Ilosc));
            gracz.Zboza.ForEach(z => z.Ilosc = ZmniejszZapas(z.Ilosc));
            gracz.Ryby = Ryba.StartoweRyby();
            gracz.ProduktyZwierzece.ForEach(p => { if (!ProduktyTrwale.Contains(p.Nazwa) && p.Ilosc > 0) p.Ilosc--; });
            gracz.ProduktyPrzetworzone.ForEach(p => p.Ilosc = Math.Max(0, p.Ilosc - 1));
        }
        private static void ResetujJedzenie(Gracz gracz)
        {
            gracz.Kanapki = [];
            gracz.Salatki = [];
            gracz.Surowki = [];
            gracz.Obiady = Obiad.StartoweObiady();
        }
        private async Task WczytajDaneGry()
        {
            if (!File.Exists(_sciezkaDoDanych))
            {
                DaneGry = new DaneGry();
                await ZapiszDaneGry();
                return;
            }
            var zapisaneDane = await File.ReadAllTextAsync(_sciezkaDoDanych);
            DaneGry = JsonSerializer.Deserialize<DaneGry>(zapisaneDane) ?? new DaneGry();
        }
        private async Task ZapiszDaneGry() => await ZapiszJson(_sciezkaDoDanych, DaneGry);
        private async Task SprawdzenieCzyPierwszyRazWDniuDanych()
        {
            if (!CzyNowyDzienDanych()) return;
            GieldaPracuje();
            DaneGry!.DzienLogowania = DateTime.Now.Day;
            DaneGry.MiesiacLogowania = DateTime.Now.Month;
            DaneGry.GodzinaLogowania = DateTime.Now.Hour;
            await ZapiszDaneGry();
        }
        private void GieldaPracuje()
        {
            DaneGry!.GieldaGlowna = ZmienGielde(DaneGry.HistoriaNotowanGieldyGlownej, DaneGry.GieldaGlowna, MaxZmianaGieldyGlownej);
            DaneGry.GieldaMala = ZmienGielde(DaneGry.HistoriaNotowanGieldyMalej, DaneGry.GieldaMala, MaxZmianaGieldyMalej);
            DaneGry.GieldaDuza = ZmienGielde(DaneGry.HistoriaNotowanGieldyDuzej, DaneGry.GieldaDuza, MaxZmianaGieldyDuzej);
        }
        private static int ZmienGielde(List<NotowanieGieldy> historia, int aktualnaWartosc, int maxZmiana)
        {
            var ostatnieNotowania = historia.TakeLast(10).ToList();
            int plusy = ostatnieNotowania.Count(n => n.CzyPlus);
            int minusy = ostatnieNotowania.Count(n => !n.CzyPlus);
            int roznica = Math.Abs(plusy - minusy);
            double prawdopodobienstwoRzadszego = (roznica + 1.0) / (roznica + 2.0);
            double losowanie = Random.Shared.NextDouble();
            bool czyPlus;
            if (plusy == minusy)
                czyPlus = losowanie < 0.5;
            else if (plusy < minusy)
                czyPlus = losowanie < prawdopodobienstwoRzadszego;
            else
                czyPlus = losowanie >= prawdopodobienstwoRzadszego;
            int wartoscZmiany = Random.Shared.Next(0, maxZmiana + 1);
            int nowaWartosc = Math.Max(0, czyPlus ? aktualnaWartosc + wartoscZmiany : aktualnaWartosc - wartoscZmiany);
            if (historia.Count > 99)
                historia.RemoveAt(0);
            historia.Add(new NotowanieGieldy
            {
                CzyPlus = czyPlus,
                WartoscZmiany = wartoscZmiany,
                Gielda = nowaWartosc
            });
            return nowaWartosc;
        }
        private async Task<Dictionary<string, Gracz>> WczytajWszystkichGraczy()
        {
            if (!File.Exists(_sciezkaDoPliku))
            {
                var startowiGracze = new Dictionary<string, Gracz> { ["mama"] = new Gracz("Mama"), ["tata"] = new Gracz("Tata"), ["ula"] = new Gracz("Ula"), ["basia"] = new Gracz("Basia"), ["ania"] = new Gracz("Ania") };
                foreach (var gracz in startowiGracze.Values)
                    gracz.LosujNowaMisje();
                await ZapiszWszystkichGraczy(startowiGracze);
                return startowiGracze;
            }
            var json = await File.ReadAllTextAsync(_sciezkaDoPliku);
            var gracze = JsonSerializer.Deserialize<Dictionary<string, Gracz>>(json) ?? new Dictionary<string, Gracz>();
            bool cokolwiekUzupelniono = false;
            foreach (var gracz in gracze.Values)
            {
                if (gracz.UzupelnijBrakujacePrzedmioty())
                    cokolwiekUzupelniono = true;
            }
            if (cokolwiekUzupelniono)
                await ZapiszWszystkichGraczy(gracze);
            return gracze;
        }
        private async Task ZapiszWszystkichGraczy(Dictionary<string, Gracz> gracze) => await ZapiszJson(_sciezkaDoPliku, gracze);
        private static async Task ZapiszJson<T>(string sciezka, T obiekt)
        {
            var json = JsonSerializer.Serialize(obiekt, Opcje);
            await ZapiszPlik(sciezka, json);
        }
        private static async Task ZapiszPlik(string sciezka, string json)
        {
            var tmp = sciezka + ".tmp";
            await File.WriteAllTextAsync(tmp, json);
            File.Move(tmp, sciezka, overwrite: true);
        }
    }
}
