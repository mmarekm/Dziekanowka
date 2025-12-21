namespace Dziekanowka.Gracza
{
    public class ZwierzeGracza(string nazwa, int ilosc = 0, int nakarmione = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public int Nakarmione { get; set; } = nakarmione;
        public int DajeProdukt() => Ilosc == 1 ? 8 : Ilosc < 4 ? 7 * (Ilosc - 1) + 8 : Ilosc < 7 ? 6 * (Ilosc - 3) + 22 : 5 * (Ilosc - 6) + 40;
        public static List<ZwierzeGracza> StartoweZwierzaki() => [ new("kura", 1) ];
    }
}
