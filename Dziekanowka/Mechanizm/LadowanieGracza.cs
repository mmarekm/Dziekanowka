using Dziekanowka.Gracza;
using System.Text.Json;
namespace Dziekanowka.Mechanizm
{
    public class LadowanieGracza
    {
        private readonly string _sciezkaDoPliku;
        public Gracz? AktualnyGracz { get; private set; }
        public event Action? NowyDzienEvent;
        public Dzwieki? Dzwieki;
        public bool CzyPokazacWideo { get; private set; } = false;
        private bool CzyNowyDzien() => AktualnyGracz!.Statystyki.DzienLogowania != DateTime.Now.Day || AktualnyGracz.Statystyki.MiesiacLogowania != DateTime.Now.Month;
        public LadowanieGracza()
        {
            _sciezkaDoPliku = Path.Combine(AppContext.BaseDirectory, "gracze.json");
        }
        private async Task SprawdzenieCzyPierwszyRazWDniu()
        {
            if (CzyNowyDzien())
            {
                AktualnyGracz!.Statystyki.DzienLogowania = DateTime.Now.Day;
                AktualnyGracz.Statystyki.MiesiacLogowania = DateTime.Now.Month;
                AktualnyGracz.Monety += AktualnyGracz.Statystyki.BonusDzienny + AktualnyGracz.Przedmiot("siano").Ilosc;
                AktualnyGracz.Statystyki.MoznaMiod = true;
                AktualnyGracz.Statystyki.MoznaSianoZKarczowiska = true;
                AktualnyGracz.Warzywa.ForEach(w => w.Ilosc = w.Ilosc > 0 ? w.Ilosc - (w.Ilosc / 5 + 1) : w.Ilosc);
                AktualnyGracz.Owoce.ForEach(o => o.Ilosc = o.Ilosc > 0 ? o.Ilosc - (o.Ilosc / 5 + 1) : o.Ilosc);
                AktualnyGracz.Zboza.ForEach(z => z.Ilosc = z.Ilosc > 0 ? z.Ilosc - (z.Ilosc / 5 + 1) : z.Ilosc);
                AktualnyGracz.Ryby = Ryba.StartoweRyby();
                var produktyTrwale = new HashSet<string> { "pioroGesi", "pioroKaczki", "futroKrolik", "owcaSkora", "kozaSkora", "krowaSkora", "owcaWelna", "alpakaWelna", "miod" };
                AktualnyGracz.ProduktyZwierzece.ForEach(p => { if (!produktyTrwale.Contains(p.Nazwa) && p.Ilosc > 0) p.Ilosc--; });
                AktualnyGracz.ProduktyPrzetworzone.ForEach(p => p.Ilosc = Math.Max(0, p.Ilosc - 1));
                AktualnyGracz.Kanapki = [];
                AktualnyGracz.Salatki = [];
                AktualnyGracz.Surowki = [];
                AktualnyGracz.Obiady = Obiad.StartoweObiady();
                //START DEBUG
                /*
                foreach (var item in AktualnyGracz.Przedmioty)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.Owoce)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.Warzywa)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.Zboza)
                {
                    item.Ilosc += 10;
                    item.PoziomZakwasu += 10;
                }
                foreach (var item in AktualnyGracz.ProduktyZwierzece)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.ProduktyPrzetworzone)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.Ryby)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.Grzyby)
                    item.Ilosc += 10;
                foreach (var item in AktualnyGracz.ZywnoscPozostala)
                    item.Ilosc += 10;
                */
                //KONIEC DEBUG
                NowyDzienEvent?.Invoke();
                await ZapiszAktualnegoGracza();
                CzyPokazacWideo = true;
            }
        }
        public async Task<Gracz> ZaladujGracza(string nazwa)
        {
            var gracze = await WczytajWszystkichGraczy();
            AktualnyGracz = gracze[nazwa.ToLower()];
            await SprawdzenieCzyPierwszyRazWDniu();
            return AktualnyGracz;
        }
        public async Task ZapiszAktualnegoGracza()
        {
            var gracze = await WczytajWszystkichGraczy();
            gracze[AktualnyGracz!.Nazwa.ToLower()] = AktualnyGracz;
            await ZapiszWszystkichGraczy(gracze);
        }
        private async Task<Dictionary<string, Gracz>> WczytajWszystkichGraczy()
        {
            if (!File.Exists(_sciezkaDoPliku))
            {
                var startowiGracze = new Dictionary<string, Gracz> { ["mama"] = new Gracz("Mama"), ["tata"] = new Gracz("Tata"), ["ula"] = new Gracz("Ula"), ["basia"] = new Gracz("Basia"), ["ania"] = new Gracz("Ania") };
                await ZapiszWszystkichGraczy(startowiGracze);
                return startowiGracze;
            }
            var json = await File.ReadAllTextAsync(_sciezkaDoPliku);
            return JsonSerializer.Deserialize<Dictionary<string, Gracz>>(json) ?? new Dictionary<string, Gracz>();
        }
        private async Task ZapiszWszystkichGraczy(Dictionary<string, Gracz> gracze)
        {
            var opcje = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(gracze, opcje);
            await File.WriteAllTextAsync(_sciezkaDoPliku, json);
        }
    }
}