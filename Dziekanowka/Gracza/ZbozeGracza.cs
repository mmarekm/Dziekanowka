namespace Dziekanowka.Gracza
{
    public class ZbozeGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<ZbozeGracza> StartoweZboza() => [new("żyto"), new("jęczmień"), new("pszenica"), new("ryż"), new("owies"), new("gryka"), new("orkisz")];
    }
}
