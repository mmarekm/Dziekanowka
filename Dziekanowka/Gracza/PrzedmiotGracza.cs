namespace Dziekanowka.Gracza
{
    public class PrzedmiotGracza(string nazwa, int ilosc)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<PrzedmiotGracza> StartowePrzedmioty() => [ new("pustaButelka", 2), new("pelnaButelka", 0), new("siano", 0) ];
    }
}
