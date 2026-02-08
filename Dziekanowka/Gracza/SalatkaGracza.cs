namespace Dziekanowka.Gracza
{
    public class SalatkaGracza(bool jestMiod, HashSet<string> owoce)
    {
        public bool JestMiod { get; set; } = jestMiod;
        public HashSet<string> Owoce { get; set; } = owoce;
    }
}