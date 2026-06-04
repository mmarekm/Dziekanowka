using Dziekanowka.Mechanizm;

namespace Dziekanowka.Gracza
{
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public RozgrywkiWewnetrzne Mecze { get; set; } = new();
        public (bool chlopiecMiska, bool pizza, bool zwierz, bool restauracja) SkladoweDoKolekcji { get; set; } = (false, false, false, false);
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
    }
}
