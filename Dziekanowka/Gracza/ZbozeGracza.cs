namespace Dziekanowka.Gracza
{
    public class ZbozeGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<ZbozeGracza> StartoweZboza() => [new("zyto"), new("jeczmien"), new("pszenica"), new("ryz"), new("owies"), new("gryka"), new("orkisz")];
    }
}
