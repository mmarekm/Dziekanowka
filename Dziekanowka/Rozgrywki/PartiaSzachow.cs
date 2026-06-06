namespace Dziekanowka.Rozgrywki
{
    public class DaneSzachowe
    {
        public Dictionary<string, PartiaSzachow> Partie { get; set; } = [];
        public Dictionary<string, Dictionary<string, double>> Mecze { get; set; } = [];
    }
    public class PoleSzachownicy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Bierka { get; set; } = "";
    }
    public class PartiaSzachow
    {
        public string Nazwa { get; set; } = "";
        public bool RuchBialych { get; set; } = true;
        public List<PoleSzachownicy> Plansza { get; set; } = [];
        public int OstatniRuchX { get; set; } = 0;
        public int OstatniRuchY { get; set; } = 0;
        public int OstatniStartX { get; set; } = 0;
        public int OstatniStartY { get; set; } = 0;
        public string OstatniaBierka { get; set; } = "";
        public string TrwaPropozyjaRemisu { get; set; } = "";
        public string NazwaBialego { get; set; } = "";
        public string NazwaCzarnego { get; set; } = "";
        public bool BialyKrolRuszal { get; set; } = false;
        public bool BialaWiezaKrolowaRuszala { get; set; } = false;
        public bool BialaWiezaKrolRuszala { get; set; } = false;
        public bool CzarnyKrolRuszal { get; set; } = false;
        public bool CzarnaWiezaKrolowaRuszala { get; set; } = false;
        public bool CzarnaWiezaKrolRuszala { get; set; } = false;
        public static List<PoleSzachownicy> StartowePlansza()
        {
            var plansza = new List<PoleSzachownicy>();
            for (int x = 1; x <= 8; x++)
                for (int y = 1; y <= 8; y++)
                    plansza.Add(new PoleSzachownicy { X = x, Y = y, Bierka = "" });
            void Postaw(int x, int y, string bierka) => plansza.First(p => p.X == x && p.Y == y).Bierka = bierka;
            Postaw(1, 1, "wiezaBialy"); Postaw(2, 1, "skoczekBialy"); Postaw(3, 1, "goniecBialy"); Postaw(4, 1, "hetmanBialy"); Postaw(5, 1, "krolBialy"); Postaw(6, 1, "goniecBialy"); Postaw(7, 1, "skoczekBialy"); Postaw(8, 1, "wiezaBialy");
            for (int x = 1; x <= 8; x++) Postaw(x, 2, "pionBialy");
            Postaw(1, 8, "wiezaCzarny"); Postaw(2, 8, "skoczekCzarny"); Postaw(3, 8, "goniecCzarny"); Postaw(4, 8, "hetmanCzarny"); Postaw(5, 8, "krolCzarny"); Postaw(6, 8, "goniecCzarny"); Postaw(7, 8, "skoczekCzarny"); Postaw(8, 8, "wiezaCzarny");
            for (int x = 1; x <= 8; x++) Postaw(x, 7, "pionCzarny");
            return plansza;
        }
        public static Dictionary<string, PartiaSzachow> StartowePartie()
        {
            var gracze = new List<string> { "Mama", "Tata", "Ula", "Basia", "Ania" };
            var partie = new Dictionary<string, PartiaSzachow>();
            foreach (var biale in gracze)
                foreach (var czarne in gracze)
                    if (biale != czarne)
                        partie[$"{biale}{czarne}"] = new PartiaSzachow
                        {
                            Nazwa = $"{biale}{czarne}",
                            RuchBialych = true,
                            NazwaBialego = biale,
                            NazwaCzarnego = czarne,
                            Plansza = StartowePlansza()
                        };
            return partie;
        }
    }
}