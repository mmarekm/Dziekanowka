namespace Dziekanowka.Mechanizm
{
    public static class BazaPociagow
    {
        public static bool CzyMetropolia(string stacja) => stacja.StartsWith("metropolia");
        public static int CenaBiletu(string stacja) => stacja is "miasto3" or "miastoMorskie" ? 7 : CzyMetropolia(stacja) ? 6 : 10;
        public static string CelPociagu(int nrPociagu) => nrPociagu switch
        {
            1 or 6 or 10 or 18 or 30 => "miastoLesne",
            2 or 4 or 13 or 16 or 35 or 39 => "miasto3",
            3 or 5 or 11 or 20 or 37 => "miastoBiale",
            7 or 8 or 9 or 14 or 22 or 31 => "miastoMorskie",
            12 or 24 or 27 => "miastoGorskie",
            25 or 43 => "miastoWiejskie",
            28 or 32 or 44 => "miastoKawy",
            33 or 36 => "miastoSnow",
            38 or 40 or 42 => "miastoHandlu",
            15 or 17 or 19 or 21 or 23 or 26 or 29 or 34 or 41 or 45 or 47 => "metropolia1",
            46 or 49 => "metropolia2",
            48 => "miastoPieniedzy",
            _ => throw new ArgumentOutOfRangeException()
        };
        public static readonly Dictionary<int, int[]> OdjazdyPociagu = new()
        {
            { 1, [10, 30, 40, 60, 90] },
            { 3, [15, 45, 75] },
            { 7, [35] },
            { 15, [20, 50, 70, 80] },
            { 38, [25, 55, 65, 95] },
            { 2, [10, 30, 55, 85] },
            { 5, [50] },
            { 8, [15, 40, 75] },
            { 17, [20, 40, 65, 75] },
            { 32, [5, 80] },
            { 4, [10, 20, 40, 80] },
            { 6, [45] },
            { 9, [15, 35, 75] },
            { 12, [30, 70] },
            { 19, [5, 25, 55, 85] },
            { 36, [50, 60, 90] },
            { 10, [10, 43, 76] },
            { 11, [28, 56, 90] },
            { 21, [19, 65, 85] },
            { 13, [18, 38, 58, 88] },
            { 14, [48] },
            { 23, [8, 28, 68] },
            { 27, [78] },
            { 26, [40, 77] },
            { 42, [49] },
            { 29, [5, 25, 45, 75] },
            { 30, [10, 30, 60] },
            { 31, [20, 50, 90] },
            { 34, [20, 60, 80] },
            { 35, [10, 30, 50, 89] },
            { 37, [15, 35, 55, 75, 98] },
            { 39, [9, 45, 72, 99] },
            { 41, [18, 54, 81, 90] },
            { 43, [36] },
            { 44, [27, 63] },
            { 16, [8, 30, 52, 77] },
            { 46, [19, 41, 64, 89] },
            { 18, [10, 40, 70] },
            { 20, [20, 50, 80] },
            { 22, [16, 46, 76] },
            { 24, [26, 56, 86] },
            { 25, [30, 82] },
            { 28, [9, 41, 61, 93] },
            { 33, [36, 66, 96] },
            { 40, [30, 60, 90] },
            { 45, [19, 51, 72] },
            { 47, [4, 26, 49, 74] },
            { 48, [8, 28, 58, 88] },
            { 49, [10, 40, 70] }
        };
        public static readonly Dictionary<string, int[]> PociagiZeStacji = new()
        {
            { "miasto3", [1, 3, 7, 15, 38] },
            { "miastoLesne", [2, 5, 8, 17, 32] },
            { "miastoBiale", [4, 6, 9, 12, 19, 36] },
            { "miastoMorskie", [10, 11, 21] },
            { "miastoGorskie", [13, 14, 23, 27] },
            { "miastoWiejskie", [26, 42] },
            { "miastoKawy", [29, 30, 31] },
            { "miastoSnow", [34, 35, 37] },
            { "miastoHandlu", [39, 41, 43, 44] },
            { "miastoPieniedzy", [49] },
            { "metropolia1", [16, 18, 20, 22, 24, 25, 28, 33, 40, 45, 46] },
            { "metropolia2", [47, 48] }
        };
        public static IEnumerable<(string obrazek, int[] godziny)> AktualnyRozklad(string stacja)
        {
            if (!PociagiZeStacji.TryGetValue(stacja, out var numery))
                return [];
            return numery.Where(nr => nr != 27).Select(nr => ($"{EtykietaRozkladu(nr)}Label.png", OdjazdyPociagu[nr]));
        }
        private static string EtykietaRozkladu(int nrPociagu) => nrPociagu switch
        {
            45 => "stacjaKopalnie",
            _ => CelPociagu(nrPociagu)
        };
        public static EkranGry Wyjscie(string stacja) => stacja switch
        {
            "miasto3" => EkranGry.Miasto3,
            "miastoLesne" => EkranGry.MiastoLesne,
            "miastoBiale" => EkranGry.MiastoBiale,
            "miastoMorskie" => EkranGry.MiastoMorskie,
            "miastoGorskie" => EkranGry.MiastoGorskie,
            "miastoKawy" => EkranGry.MiastoKawy,
            "miastoSnow" => EkranGry.MiastoSnow,
            "miastoHandlu" => EkranGry.MiastoHandlu,
            "miastoWiejskie" => EkranGry.MiastoWiejskie,
            "miastoPieniedzy" => EkranGry.MiastoPieniedzy,
            _ => throw new ArgumentOutOfRangeException()
        };
        public static bool PrawyTor(string nazwa, string stacja) => (nazwa, stacja) switch
        {
            ("pociag1", "miasto3") => true,
            ("pociag15", "miasto3") => true,
            ("pociag5", "miastoLesne") => true,
            ("pociag8", "miastoLesne") => true,
            ("pociag32", "miastoLesne") => true,
            ("pociag4", "miastoBiale") => true,
            ("pociag12", "miastoBiale") => true,
            ("pociag36", "miastoBiale") => true,
            ("pociag22", "metropolia1") => true,
            ("pociag24", "metropolia1") => true,
            ("pociag33", "metropolia1") => true,
            ("pociag25", "metropolia1") => true,
            ("pociag28", "metropolia1") => true,
            ("pociag45", "metropolia1") => true,
            ("pociag30", "miastoKawy") => true,
            ("pociag31", "miastoKawy") => true,
            ("pociag37", "miastoSnow") => true,
            _ => false
        };
        public static string StronaPrzyjazdu(string nazwa, string stacja) => PrawyTor(nazwa, stacja) ? "pociagNaPrawo" : "pociagNaLewo";
        public static string StronaOdjazdu(string nazwa, string stacja) => PrawyTor(nazwa, stacja) ? "pociagNaLewo" : "pociagNaPrawo";
    }
}