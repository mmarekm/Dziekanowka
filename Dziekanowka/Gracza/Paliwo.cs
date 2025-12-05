namespace Dziekanowka.Gracza
{
    public class Paliwo
    {
        public int PoziomKanistera { get; set; } = 1;
        public int IloscPaliwa { get; set; } = 3;
        public int MaksymalnaIloscPaliwa => 5 + (PoziomKanistera - 1) * 6;
        public int PolowaPaliwa => MaksymalnaIloscPaliwa / 2;
        public int CwiercPaliwa => MaksymalnaIloscPaliwa / 4;
        public int CenaPelnegoPaliwa => PoziomKanistera switch { 1 => 11, 2 => 22, 3 => 31, 4 => 39, 5 => 47, 6 => 55, 7 => 62, 8 => 69, 9 => 76, 10 => 83, _ => 83 + (PoziomKanistera - 10) * 7 };
        public int CenaPolowyPaliwa => PoziomKanistera switch { 1 => 6, 2 => 11, 3 => 16, 4 => 22, 5 => 27, 6 => 32, 7 => 37, 8 => 43, 9 => 48, 10 => 54, _ => 54 + (PoziomKanistera - 10) * 5 };
        public int CenaCwierciPaliwa => PoziomKanistera switch { 1 => 5, 2 => 7, 3 => 11, 4 => 12, 5 => 17, 6 => 20, 7 => 23, 8 => 26, 9 => 29, 10 => 32, _ => 32 + (PoziomKanistera - 10) * 3 };
        public int KosztUpgrade => (int)(20 * Math.Pow(2.5, PoziomKanistera - 1));
    }
}