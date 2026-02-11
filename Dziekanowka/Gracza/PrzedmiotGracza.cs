namespace Dziekanowka.Gracza
{
    public class PrzedmiotGracza(string nazwa, int ilosc = 0, int poziom = 0) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public int Poziom { get; set; } = poziom;
        public static List<PrzedmiotGracza> StartowePrzedmioty() => [ new("pustaButelka", 3), new("pelnaButelka", 2), new("drewno", 2), new("siano", 2),
        new("siekiera")];
    }
}