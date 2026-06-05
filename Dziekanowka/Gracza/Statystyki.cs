using Dziekanowka.Mechanizm;
namespace Dziekanowka.Gracza
{
    public class ZadaniaKolekcji
    {
        public string ChlopiecMiska { get; set; } = "";
        public string Restauracja { get; set; } = "";
        public string Zwierz { get; set; } = "";
        public List<string> Pizza { get; set; } = new();
    }
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public RozgrywkiWewnetrzne Mecze { get; set; } = new();
        public bool SkladowaChlopiecMiska { get; set; } = false;
        public bool SkladowaPizza { get; set; } = false;
        public ZadaniaKolekcji ZadaniaDoKolekcji { get; set; } = new();
        public int Kolekcje { get; set; } = 0;
        public int BonusDzienny { get; set; } = 33;
        public bool MoznaMiod { get; set; } = false;
        public bool MoznaKaweZSalonu { get; set; } = false;
        public bool MoznaSianoZKarczowiska { get; set; } = false;
        public EkranGry Ekran { get; set; } = EkranGry.Gospodarstwo;
        public string OtwarteOkno { get; set; } = "";
        public int Kiosk { get; set; } = 0;
        public string Stacja { get; set; } = "";
        public int Sklepiczek { get; set; } = 0;
        private List<string> zbiorChlopiecMiska = ["rosol", "barszczCzerwony", "zurek", "krupnik", "zupaPomidorowa", "zupaOgorkowa", "zupaGrzybowa", "kapusniak", "grochowka", "zupaFasolowa", "zupaCebulowa", "chlodnik", "kremZBrokulow", "kremZDyni", "kremZKalafiora"];
        //private List<string> zbiorRestauracja = ["karkowka", "gulasz", "pieczenWolowa", "indykDuszony", "krolikWWinie", "ratatouille", "leczo", "fasolkaPoBretonsku", "knedle", "lososGotowany", "rybaPoGrecku", "sledzWOleju", "jajecznica", "jajkoSadzone", "omlet", "shakshuka", "kotletSchabowy", "kotletMielony", "stek", "piersZKurczaka", "bitki", "indykSmazony", "krolikSmazony", "golabki", "pstragSmazony", "lososSmazony", "halibutSmazony", "okonSmazony", "sledzSmazony", "plackiZiemniaczane", "frytki", "pierogiRuskie", "pierogiZMiesem", "pierogiZKapustaIGrzybami", "pierogiZOwocami"];
        private List<string> skladnikiPizza = ["papryka", "cebula", "kukurydza", "ogórek", "ananas", "oliwki", "pieczarka", "rydz", "podgrzybek", "borowik", "kurka", "kielbasaWedlina", "salamiWedlina", "lopatkaWedlina", "poledwicaWedlina", "boczekWedlina", "szynkaWedlina", "schabWedlina", "kurczakWedlina", "indykWedlina", "krolikPasztet", "drobPasztet", "swiniaPasztet"];
        //private List<string> zbiorZwierz = ["losos", "pstrag", "halibut", "okon", "sledz"];
        public Statystyki()
        {
            ZadaniaDoKolekcji = new ZadaniaKolekcji
            {
                ChlopiecMiska = Losuj(zbiorChlopiecMiska),
                //Restauracja = Losuj(zbiorRestauracja),
                //Zwierz = Losuj(zbiorZwierz),
                Pizza = LosujPizza(3)
            };
        }
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