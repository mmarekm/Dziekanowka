namespace Dziekanowka.Gracza
{
    public class Grzyb(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<Grzyb> StartoweGrzyby() => [new("pieczarka"), new("rydz"), new("podgrzybek"), new("borowik"), new("kurka")];
    }
}