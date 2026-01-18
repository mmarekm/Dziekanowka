namespace Dziekanowka.Gracza
{
    public class ProduktZwierzecy(string nazwa, int ilosc = 0) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktZwierzecy> StartoweProdukty() => [
            new("kuraJajo"), new("kuraJedzenie"), new("gesPioro"), new("gesJajo"), new("gesJedzenie"), new("gesSmalec"), new("indykJajo"), new("indykJedzenie"),
            new("kaczkaPioro"), new("kaczkaJajo"), new("kaczkaJedzenie"), new("kaczkaSmalec"), new("futroKrolik"), new("krolikJedzenie"), new("swiniaSzynka"), new("swiniaSchab"),
            new("swiniaBoczek"), new("swiniaSmalec"), new("owcaMleko"), new("owcaJedzenie"), new("owcaSkora"), new("owcaWelna"), new("alpakaWelna"), new("kozaMleko"), new("kozaJedzenie"),
            new("kozaSkora"), new("krowaMleko"), new("krowaRostbef"), new("krowaAntrykot"), new("krowaLopatka"), new("krowaPoledwica"), new("krowaSkora"), 
            new("mieloneDrob"), new("mieloneDzikie"), new("mieloneSwinia"), new("mieloneKrowa"), new("miod")
        ];
    }
}