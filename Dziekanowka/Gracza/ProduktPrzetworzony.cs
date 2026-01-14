namespace Dziekanowka.Gracza
{
    public class ProduktPrzetworzony(string nazwa, int ilosc = 0) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktPrzetworzony> StartoweProdukty() => [
        new("smietana"), new("maslo"), new("majonez"), new("krowaSer"), new("kozaSer"), new("owcaSer"), new("twarog"), new("makaron"),
        new("zytoMaka"), new("jeczmienMaka"), new("pszenicaMaka"), new("ryzMaka"), new("owiesMaka"), new("grykaMaka"), new("orkiszMaka")
        ];
    }
}