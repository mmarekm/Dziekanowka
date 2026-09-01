using Dziekanowka.Mechanizm;
using System.Security.Cryptography.X509Certificates;
namespace Dziekanowka.Gracza
{
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public int Ogrodek { get; set; } = 0;
        public bool MoznaOdebracObraz { get; set; } = false;
        public List<string> BiezacyWorekMisji { get; set; } = new(Gra.WszystkieMisje);
        public string AktualnaMisja { get; set; } = "";
        public string[] DaneMisji { get; set; } = ["", "", "", "", "", "", "", "", "", ""];
        public int Kolekcje { get; set; } = 18;
        public int BonusDzienny { get; set; } = 33;
        public HashSet<string> Bonusy { get; set; } = ["miodUl", "kawaSalon", "karczowiskoSiano", "winoMorskie", "owceGorskie", "dzieciCiekawe", "pociagZGor"];
        public string ZwierzeNaDrodze { get; set; } = "krowa";
        public EkranGry Ekran { get; set; } = EkranGry.Gospodarstwo;
        public string OtwarteOkno { get; set; } = "";
        public int Kiosk { get; set; } = 0;
        public string Stacja { get; set; } = "";
        public int Sklepiczek { get; set; } = 0;
        public string DzieloZGlinyWWalizce { get; set; } = "";
        private List<string> skladnikiPizza = ["papryka", "cebula", "kukurydza", "ogórek", "ananas", "oliwki", "pieczarka", "rydz", "podgrzybek", "borowik", "kurka", "kielbasaWedlina", "salamiWedlina", "lopatkaWedlina", "poledwicaWedlina", "boczekWedlina", "szynkaWedlina", "schabWedlina", "kurczakWedlina", "indykWedlina", "krolikPasztet", "drobPasztet", "swiniaPasztet"];
        private string Losuj(List<string> zbior) => zbior[Random.Shared.Next(zbior.Count)];
        private List<string> LosujPizza(int ile)
        {
            var kopia = new List<string>(skladnikiPizza);
            var wynik = new List<string>();
            for (int i = 0; i < ile && kopia.Count > 0; i++)
            {
                int idx = Random.Shared.Next(kopia.Count);
                wynik.Add(kopia[idx]);
                kopia.RemoveAt(idx);
            }
            return wynik;
        }
    }
}