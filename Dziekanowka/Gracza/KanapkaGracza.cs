namespace Dziekanowka.Gracza
{
    public class KanapkaGracza(string pieczywo, string? tluszcz = null, string? wedlina = null, string? ser = null, HashSet<string>? dodatki = null)
    {
        public string Pieczywo { get; set; } = pieczywo;
        public string? Tluszcz { get; set; } = tluszcz;
        public string? Wedlina { get; set; } = wedlina;
        public string? Ser { get; set; } = ser;
        public HashSet<string> Dodatki { get; set; } = dodatki ?? [];
    }
}