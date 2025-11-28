namespace Dziekanowka
{
    public class Gracz(string nazwa)
    {
        public string Nazwa { get; set;  } = nazwa;
        public int Punkty { get; set; } = 0;
        public int Monety { get; set; } = 10;
    }
}