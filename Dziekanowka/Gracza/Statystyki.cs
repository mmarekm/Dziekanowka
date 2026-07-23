using Dziekanowka.Mechanizm;
using System.Security.Cryptography.X509Certificates;
namespace Dziekanowka.Gracza
{
    public static class Misje
    {
        public const string Chlopiec = "Chlopiec";
        public const string Kot = "Kot";
        public const string FanZdrowia = "FanZdrowia";
        public const string DomMleka = "DomMleka";
        public const string KuchniaMorska = "KuchniaMorska";
        public const string SlodkaBuleczka = "SlodkaBuleczka";
    }
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public bool MoznaOdebracObraz { get; set; } = false;
        public string AktualnaMisja { get; set; } = Misje.Chlopiec;
        public string[] DaneMisji { get; set; } = [Gra.ZbiorChlopiecMiska[Random.Shared.Next(Gra.ZbiorChlopiecMiska.Count)], "", ""];
        public int Kolekcje { get; set; } = 18;
        public int BonusDzienny { get; set; } = 33;
        public HashSet<string> Bonusy { get; set; } = ["miodUl", "kawaSalon", "karczowiskoSiano", "winoMorskie"];
        public EkranGry Ekran { get; set; } = EkranGry.Gospodarstwo;
        public string OtwarteOkno { get; set; } = "";
        public int Kiosk { get; set; } = 0;
        public string Stacja { get; set; } = "";
        public int Sklepiczek { get; set; } = 0;
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