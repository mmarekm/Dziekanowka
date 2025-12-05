using Dziekanowka.Mechanizm;

namespace Dziekanowka.Gracza
{
    public class Statystyki
    {
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public int BonusDzienny { get; set; } = 50;
        public EkranGry Ekran { get; set; } = EkranGry.Gospodarstwo;
    }
}
