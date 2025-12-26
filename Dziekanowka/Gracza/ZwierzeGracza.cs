namespace Dziekanowka.Gracza
{
    public class ZwierzeGracza(string nazwa, int ilosc = 0, int nakarmione = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public int Nakarmione { get; set; } = nakarmione;
        public int DajeProdukt() => Ilosc == 0 ? 1 : Nazwa switch
        {
            "kura" => Ilosc == 1 ? 8 : Ilosc < 4 ? 7 * (Ilosc - 1) + 8 : Ilosc < 7 ? 6 * (Ilosc - 3) + 22 : 5 * (Ilosc - 6) + 40,
            "ges" => Ilosc == 1 ? 20 : Ilosc < 4 ? 18 * (Ilosc - 1) + 20 : Ilosc < 7 ? 16 * (Ilosc - 3) + 56 : 13 * (Ilosc - 6) + 104,
            "indyk" => Ilosc * 40,
            _ => 1
        };
        public int Cena() => Nazwa switch
        {
            "kura" => Ilosc < 1 ? 20 : Ilosc * 10 + 30,
            "ges" => Ilosc < 1 ? 30 : Ilosc * 12 + 40,
            "indyk" => Ilosc < 1 ? 28 : Ilosc * 5 + 37,
            _ => 0
        };
        public static List<ZwierzeGracza> StartoweZwierzaki() => [ new("kura", 1), new("ges"), new("indyk") ];
    }
}