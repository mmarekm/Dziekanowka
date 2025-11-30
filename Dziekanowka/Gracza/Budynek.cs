namespace Dziekanowka.Gracza
{
    public class Budynek(string nazwa, int limitPoziomow)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Poziom { get; set; } = 1;
        public int LimitPoziomow { get; set; } = limitPoziomow;
        public int KosztUlepszenia() => Nazwa switch { "studnia" => Poziom * 1000, _ => 0 };
    }
}
