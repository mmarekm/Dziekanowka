namespace Dziekanowka.Gracza
{
    public class KanapkaGracza(string pieczywo, string? tluszcz = null, string? ser = null, string? wedlina = null, HashSet<string>? dodatki = null)
    {
        public string Pieczywo { get; set; } = pieczywo;
        public string? Tluszcz { get; set; } = tluszcz;
        public string? Ser { get; set; } = ser;
        public string? Wedlina { get; set; } = wedlina;
        public HashSet<string> Dodatki { get; set; } = dodatki ?? [];
    }
}