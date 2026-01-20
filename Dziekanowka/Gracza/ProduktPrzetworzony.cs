namespace Dziekanowka.Gracza
{
    public class ProduktPrzetworzony(string nazwa, int ilosc = 0) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<ProduktPrzetworzony> StartoweProdukty() => [
        new("smietana"), new("maslo"), new("majonez"), new("krowaSer"), new("kozaSer"), new("owcaSer"), new("twarog"), new("makaron"), new("kielbasa"),
        new("zytoMaka"), new("jeczmienMaka"), new("pszenicaMaka"), new("ryzMaka"), new("owiesMaka"), new("grykaMaka"), new("orkiszMaka"),
        new("zytoPlatki"), new("jeczmienPlatki"), new("pszenicaPlatki"), new("ryzPlatki"), new("owiesPlatki"), new("grykaPlatki"), new("orkiszPlatki"), new("kukurydzaPlatki"),
        new("wino"), new("ogorekKiszony"), new("kapustaKiszona"), new("burakKiszony"), new("mieloneDrob"), new("mieloneDzikie"), new("mieloneSwinia"), new("mieloneKrowa"),
        new("marchewSok"), new("burakSok"), new("pomidorSok"), new("jabłkoSok"), new("pomarańczaSok"), new("grejpfrutSok"), new("cytrynaSok"), new("ananasSok"),
        new("brzoskwiniaSok"), new("morelaSok"), new("wiśniaSok"), new("truskawkaSok"), new("malinaSok"), new("borówkaSok"), new("porzeczkaCzarnaSok")
        ];
    }
}