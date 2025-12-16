namespace Dziekanowka.Gracza
{
    public class ZbozeGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<ZbozeGracza> StartoweZboza() => [new("pszenica"), new("żyto"), new("jęczmień"), new("owies"), new("kukurydza"), new("ryż"), new("proso"), new("gryka"), new("orkisz")];
    }
}
