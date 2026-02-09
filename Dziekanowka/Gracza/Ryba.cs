namespace Dziekanowka.Gracza
{
    public class Ryba(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<Ryba> StartoweRyby() => [new("losos"), new("pstrag"), new("halibut"), new("okon"), new("sledz")];
    }
}