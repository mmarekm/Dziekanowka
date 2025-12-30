namespace Dziekanowka.Gracza
{
    public class ProduktZwierzecy(string nazwa, int ilosc = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktZwierzecy> StartoweProdukty() => [
            new("jajoKurze"), new("kuraJedzenie"), new("pioroGesi"), new("jajoGesie"), new("gesJedzenie"), new("smalecGesi"), new("jajoIndycze"), new("indykJedzenie"),
            new("pioroKaczki"), new("jajoKacze"), new("kaczkaJedzenie"), new("smalecKaczy"), new("futroKrolik"), new("krolikJedzenie"), new("swiniaSzynka"), new("swiniaSchab"), new("swiniaBoczek")
        ];
    }
}