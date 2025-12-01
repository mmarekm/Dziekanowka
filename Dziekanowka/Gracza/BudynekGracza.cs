namespace Dziekanowka.Gracza
{
    public class BudynekGracza(string nazwa, int limitPoziomow)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Poziom { get; set; } = 1;
        public int LimitPoziomow { get; set; } = limitPoziomow;
    }
}
