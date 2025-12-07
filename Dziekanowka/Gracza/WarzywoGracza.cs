namespace Dziekanowka.Gracza
{
    public class WarzywoGracza(string nazwa, int ilosc)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
    }
}
