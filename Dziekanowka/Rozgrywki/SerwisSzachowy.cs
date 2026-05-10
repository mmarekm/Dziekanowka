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
        private async Task<Dictionary<string, PartiaSzachow>> WczytajWszystkiePartie()
        {
            if (!File.Exists(_sciezkaDoPliku))
            {
                var startowePartie = PartiaSzachow.StartowePartie();
                await ZapiszWszystkiePartie(startowePartie);
                return startowePartie;
            }
            var json = await File.ReadAllTextAsync(_sciezkaDoPliku);
            return JsonSerializer.Deserialize<Dictionary<string, PartiaSzachow>>(json) ?? new Dictionary<string, PartiaSzachow>();
        }
        private async Task ZapiszWszystkiePartie(Dictionary<string, PartiaSzachow> partie)
        {
            var opcje = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(partie, opcje);
            await File.WriteAllTextAsync(_sciezkaDoPliku, json);
        }
        public async Task<PartiaSzachow> PobierzPartie(string nazwa)
        {
            var partie = await WczytajWszystkiePartie();
            return partie[nazwa];
        }
        public async Task ZapiszPartie(PartiaSzachow partia)
        {
            var partie = await WczytajWszystkiePartie();
            partie[partia.Nazwa] = partia;
            await ZapiszWszystkiePartie(partie);
        }
    }
}