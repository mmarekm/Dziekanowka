namespace Dziekanowka.Mechanizm
{
    public class NotowanieGieldy
    {
        public bool CzyPlus { get; set; }
        public int WartoscZmiany { get; set; }
    }
    public class DaneGry
    {
        public int Gielda { get; set; } = 100;
        public int DzienLogowania { get; set; } = 0;
        public int MiesiacLogowania { get; set; } = 0;
        public List<NotowanieGieldy> HistoriaNotowanGieldyGlownej { get; set; } = [];
    }
}
