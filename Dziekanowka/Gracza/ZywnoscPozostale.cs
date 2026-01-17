namespace Dziekanowka.Gracza
{
    public class ZywnoscPozostale(string nazwa, int ilosc = 0) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ZywnoscPozostale> StartowaZywnosc() => [
            new("olej", 2), new("sol", 2)
        ];
    }
}