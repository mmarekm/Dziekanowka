namespace Dziekanowka.Gracza
{
    public class ZwierzeGracza(string nazwa, int ilosc = 0, int nakarmione = 0, int gotowe = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public int Nakarmione { get; set; } = nakarmione;
        public int Gotowe { get; set; } = gotowe;
        public bool WszyscyObsluzeni => Ilosc == Gotowe;
        public int DajeProdukt => Ilosc == 0 ? 1 : Nazwa switch
        {
            "kura" or "krowa" => Ilosc == 1 ? 8 : Ilosc < 4 ? 7 * (Ilosc - 1) + 8 : Ilosc < 7 ? 6 * (Ilosc - 3) + 22 : 5 * (Ilosc - 6) + 40,
            "ges" => Ilosc == 1 ? 10 : 9 * (Ilosc - 1) + 10,
            "indyk" => Ilosc * 13,
            "kaczka" => Ilosc == 1 ? 9 : Ilosc < 4 ? 8 * (Ilosc - 1) + 9 : Ilosc < 7 ? 6 * (Ilosc - 3) + 25 : 5 * (Ilosc - 6) + 43,
            "krolik" => 15,
            "swinia" => 20,
            "owca" => Ilosc * 10,
            "alpaka" => Ilosc * 30,
            "koza" => Ilosc == 1 ? 11 : Ilosc < 4 ? 10 * (Ilosc - 1) + 11 : Ilosc < 7 ? 9 * (Ilosc - 3) + 31 : 8 * (Ilosc - 6) + 58,
            _ => 1
        };
        public int Cena => Nazwa switch
        {
            "kura" => Ilosc < 1 ? 20 : Ilosc * 10 + 30,
            "ges" => Ilosc < 1 ? 30 : Ilosc * 12 + 40,
            "indyk" => Ilosc < 1 ? 28 : Ilosc * 5 + 37,
            "kaczka" => Ilosc < 1 ? 23 : Ilosc * 11 + 30,
            "krolik" => 40,
            "swinia" => 60,
            "owca" => Ilosc < 1 ? 40 : Ilosc * 20 + 45,
            "alpaka" => Ilosc * 50 + 100,
            "koza" => Ilosc < 1 ? 35 : Ilosc * 15 + 50,
            "krowa" => Ilosc < 1 ? 55 : Ilosc * 40 + 60,
            _ => 0
        };
        public static List<ZwierzeGracza> StartoweZwierzaki() => [ new("kura", 1), new("ges"), new("indyk"), new("kaczka"), new("krolik"), new("swinia"), new("owca"), new("alpaka"), new("koza"), new("krowa") ];
    }
}