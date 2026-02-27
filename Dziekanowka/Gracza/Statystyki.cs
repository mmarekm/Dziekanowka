using Dziekanowka.Mechanizm;

namespace Dziekanowka.Gracza
{
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public int BonusDzienny { get; set; } = 60;
        public bool MoznaMiod { get; set; } = false;
        public bool MoznaSianoZKarczowiska { get; set; } = false;
        public EkranGry Ekran { get; set; } = EkranGry.Gospodarstwo;
        public string OtwarteOkno { get; set; } = "";
        public int Kiosk { get; set; } = 0;
        public int Sklepiczek { get; set; } = 0;
    }
}
