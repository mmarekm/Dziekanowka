namespace Dziekanowka.Gracza
{
    public class ProduktZwierzecy(string nazwa, int ilosc = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktZwierzecy> StartoweProdukty() => [new("jajoKurze")];
    }
}
