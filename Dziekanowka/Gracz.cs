using Dziekanowka.Gracza;
namespace Dziekanowka
{
    public class Gracz(string nazwa)
    {
        public string Nazwa { get; set;  } = nazwa;
        public int Doswiadczenie { get; set; } = 0;
        public int Monety { get; set; } = 0;
        public int Butelki { get; set; } = 2;
        public bool MoznaRozszerzycGospodarstwo { get; set; } = false;
        public List<Budynek> Budynki = [new("studnia", 2)];
    }
}