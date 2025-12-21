namespace Dziekanowka.Gracza
{
    public class ZwierzeGracza(string nazwa, int ilosc = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ZwierzeGracza> StartoweZwierzaki() => [ new("kura", 1) ];
    }
}
