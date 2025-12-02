using System.Text.Json;
namespace Dziekanowka.Mechanizm
{
    public class LadowanieGracza
    {
        private readonly string _sciezkaDoPliku;
        public Gracz? AktualnyGracz { get; private set; }
        private bool CzyNowyDzien(Gracz gracz) => gracz.DzienLogowania != DateTime.Now.Day || gracz.MiesiacLogowania != DateTime.Now.Month;
        public LadowanieGracza()
        {
            _sciezkaDoPliku = Path.Combine(AppContext.BaseDirectory, "gracze.json");
        }
        public async Task<Gracz> ZaladujLubUtworzGracza(string nazwa)
        {
            var nazwaLower = nazwa.Trim().ToLower();
            var gracze = await WczytajWszystkichGraczy();
            if (gracze.ContainsKey(nazwaLower))
            {
                AktualnyGracz = gracze[nazwaLower];
                if (CzyNowyDzien(AktualnyGracz))
                {
                    AktualnyGracz.DzienLogowania = DateTime.Now.Day;
                    AktualnyGracz.MiesiacLogowania = DateTime.Now.Month;
                    AktualnyGracz.Monety += 100;
                    await ZapiszWszystkichGraczy(gracze);
                }
                return AktualnyGracz;
            }
            AktualnyGracz = new Gracz(nazwa.Trim());
            gracze[nazwaLower] = AktualnyGracz;
            if (CzyNowyDzien(AktualnyGracz))
            {
                AktualnyGracz.DzienLogowania = DateTime.Now.Day;
                AktualnyGracz.MiesiacLogowania = DateTime.Now.Month;
                AktualnyGracz.Monety += 100;
                await ZapiszWszystkichGraczy(gracze);
            }
            await ZapiszWszystkichGraczy(gracze);
            return AktualnyGracz;
        }
        public async Task ZapiszAktualnegoGracza()
        {
            if (AktualnyGracz == null) return;
            var gracze = await WczytajWszystkichGraczy();
            gracze[AktualnyGracz.Nazwa.ToLower()] = AktualnyGracz;
            await ZapiszWszystkichGraczy(gracze);
        }
        private async Task<Dictionary<string, Gracz>> WczytajWszystkichGraczy()
        {
            if (!File.Exists(_sciezkaDoPliku))
                return new Dictionary<string, Gracz>();
            var json = await File.ReadAllTextAsync(_sciezkaDoPliku);
            return JsonSerializer.Deserialize<Dictionary<string, Gracz>>(json)
                   ?? new Dictionary<string, Gracz>();
        }
        private async Task ZapiszWszystkichGraczy(Dictionary<string, Gracz> gracze)
        {
            var opcje = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(gracze, opcje);
            await File.WriteAllTextAsync(_sciezkaDoPliku, json);
        }
    }
}