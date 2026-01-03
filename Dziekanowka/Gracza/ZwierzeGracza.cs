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
            "ges" => Ilosc == 1 ? 20 : Ilosc < 4 ? 18 * (Ilosc - 1) + 20 : Ilosc < 7 ? 16 * (Ilosc - 3) + 56 : 13 * (Ilosc - 6) + 104,
            "indyk" => Ilosc * 30,
            "kaczka" => Ilosc == 1 ? 9 : Ilosc < 4 ? 8 * (Ilosc - 1) + 9 : Ilosc < 7 ? 6 * (Ilosc - 3) + 25 : 5 * (Ilosc - 6) + 43,
            "krolik" => 35,
            "swinia" => 60,
            "koza" => Ilosc == 1 ? 15 : Ilosc < 4 ? 13 * (Ilosc - 1) + 15 : Ilosc < 7 ? 11 * (Ilosc - 3) + 41 : 9 * (Ilosc - 6) + 74,
            _ => 1
        };
        public int Cena => Nazwa switch
        {
            "kura" => Ilosc < 1 ? 20 : Ilosc * 10 + 30,
            "ges" => Ilosc < 1 ? 30 : Ilosc * 12 + 40,
            "indyk" => Ilosc < 1 ? 28 : Ilosc * 5 + 37,
            "kaczka" => Ilosc < 1 ? 23 : Ilosc * 11 + 30,
            "krolik" => 40,
            "swinia" => 70,
            "koza" => Ilosc < 1 ? 35 : Ilosc * 15 + 50,
            "krowa" => Ilosc < 1 ? 55 : Ilosc * 40 + 60,
            _ => 0
        };
        public static List<ZwierzeGracza> StartoweZwierzaki() => [ new("kura", 1), new("ges"), new("indyk"), new("kaczka"), new("krolik"), new("swinia"), new("koza"), new("krowa") ];
    }
}