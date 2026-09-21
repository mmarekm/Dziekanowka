namespace Dziekanowka.Mechanizm
{
    public class NotowanieGieldy
    {
        public bool CzyPlus { get; set; }
        public int WartoscZmiany { get; set; }
        public int Gielda { get; set; }
    }
    public class DaneGry
    {
        public int GieldaGlowna { get; set; } = 100;
        public int GieldaMala { get; set; } = 30;
        public int GieldaDuza { get; set; } = 300;
        public int GodzinaLogowania { get; set; } = -1;
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public List<NotowanieGieldy> HistoriaNotowanGieldyGlownej { get; set; } = [];
        public List<NotowanieGieldy> HistoriaNotowanGieldyMalej { get; set; } = [];
        public List<NotowanieGieldy> HistoriaNotowanGieldyDuzej { get; set; } = [];
    }
}