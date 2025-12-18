namespace Dziekanowka.Gracza
{
    public class UprawaZboza(int x, string zboze = "")
    {
        public int X { get; set; } = x;
        public string Zboze { get; set; } = zboze;
        public int Poziom { get; set; } = 0;
        public int LiczbaPosiadanych(Gracz gracz) => gracz.Zboza.First(z => z.Nazwa == Zboze).Ilosc;
        public static List<UprawaZboza> StartoweUprawyZboza() => ZbozeGracza.StartoweZboza().Select((zboze, index) => new UprawaZboza(x: index, zboze: zboze.Nazwa)).ToList();
    }
}
