using Dziekanowka.Gracza;
using System.Text.Json;
namespace Dziekanowka.Rozgrywki
{
    public class SerwisSzachowy
    {
        private readonly string _sciezkaDoPliku;

        public SerwisSzachowy()
        {
            _sciezkaDoPliku = Path.Combine(AppContext.BaseDirectory, "szachy.json");
        }

        private async Task<DaneSzachowe> WczytajDane()
        {
            if (!File.Exists(_sciezkaDoPliku))
            {
                var dane = new DaneSzachowe { Partie = PartiaSzachow.StartowePartie() };
                await ZapiszDane(dane);
                return dane;
            }
            var json = await File.ReadAllTextAsync(_sciezkaDoPliku);
            return JsonSerializer.Deserialize<DaneSzachowe>(json) ?? new DaneSzachowe();
        }

        private async Task ZapiszDane(DaneSzachowe dane)
        {
            var opcje = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(dane, opcje);
            await File.WriteAllTextAsync(_sciezkaDoPliku, json);
        }

        public async Task<PartiaSzachow> PobierzPartie(string nazwa)
        {
            var dane = await WczytajDane();
            return dane.Partie[nazwa];
        }

        public async Task ZapiszPartie(PartiaSzachow partia)
        {
            var dane = await WczytajDane();
            dane.Partie[partia.Nazwa] = partia;
            await ZapiszDane(dane);
        }

        public async Task<Dictionary<string, double>> PobierzPunkty(string nazwaGracza)
        {
            var dane = await WczytajDane();
            return dane.Mecze.TryGetValue(nazwaGracza, out var punkty) ? punkty : [];
        }

        public async Task ZapiszPunkty(string nazwaGracza, Dictionary<string, double> punkty)
        {
            var dane = await WczytajDane();
            dane.Mecze[nazwaGracza] = punkty;
            await ZapiszDane(dane);
        }
    }
}