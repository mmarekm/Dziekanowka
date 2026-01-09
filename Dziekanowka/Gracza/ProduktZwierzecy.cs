namespace Dziekanowka.Gracza
{
    public class ProduktZwierzecy(string nazwa, int ilosc = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktZwierzecy> StartoweProdukty() => [
            new("jajoKurze"), new("kuraJedzenie"), new("gesPioro"), new("jajoGesie"), new("gesJedzenie"), new("gesSmalec"), new("jajoIndycze"), new("indykJedzenie"),
            new("kaczkaPioro"), new("jajoKacze"), new("kaczkaJedzenie"), new("kaczkaSmalec"), new("futroKrolik"), new("krolikJedzenie"), new("swiniaSzynka"), new("swiniaSchab"),
            new("swiniaBoczek"), new("swiniaSmalec"), new("mlekoOwcze"), new("owcaJedzenie"), new("owcaSkora"), new("owcaWelna"), new("alpakaWelna"), new("mlekoKozie"), new("kozaJedzenie"),
            new("kozaSkora"), new("mlekoKrowie"), new("krowaRostbef"), new("krowaAntrykot"), new("krowaLopatka"), new("krowaPoledwica"), new("krowaSkora")
        ];
    }
}
// przy zakupie nakarmione -> 0 wiec kura kupowana z jednym jajem ges tez kaczka tez, indyk tez, krowa z banka mleka, koza tez, krolik i swinia NIE