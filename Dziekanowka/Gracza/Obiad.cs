namespace Dziekanowka.Gracza
{
    public class Obiad(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<Obiad> StartoweObiady() => [new("jajecznica")];
    }
}
