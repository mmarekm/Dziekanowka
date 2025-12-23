namespace Dziekanowka.Mechanizm
{
    public static class Gra
    {
        public static bool JestZwierze(Gracz g, string zwierz) => g.Zwierzeta.Any(z => z.Nazwa == zwierz && z.Ilosc > 0);
    }
}