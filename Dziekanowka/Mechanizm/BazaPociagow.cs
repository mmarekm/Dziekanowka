namespace Dziekanowka.Mechanizm
{
    public static class BazaPociagow
    {
        public static bool CzyMetropolia(string stacja) => stacja.StartsWith("metropolia");
        public static int CenaBiletu(string stacja) => stacja is "miasto3" or "miastoMorskie" ? 7 : stacja.StartsWith("metropolia") ? 6 : 10;
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
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}