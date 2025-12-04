namespace Dziekanowka.Gracza
{
    public class BudynekGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Poziom { get; set; } = 1;
        public static List<BudynekGracza> StartoweBudynki() => [new("studnia"), new("garazGospodarczy")];
    }
}
