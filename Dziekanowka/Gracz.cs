using Dziekanowka.Gracza;
namespace Dziekanowka
{
    public class Gracz(string nazwa)
    {
        public string Nazwa { get; set;  } = nazwa;
        public int Doswiadczenie { get; set; } = 0;
        public int Monety { get; set; } = 0;
        public List<PrzedmiotGracza> Przedmioty { get; set; } = PrzedmiotGracza.StartowePrzedmioty();
        public bool MoznaRozszerzycGospodarstwo { get; set; } = false;
        public List<BudynekGracza> Budynki { get; set; } = [new("studnia", 2)];
        public int PoziomBudynku(string nazwaBudynku) => Budynki.First(b => b.Nazwa == nazwaBudynku).Poziom;
        public int KosztUlepszeniaBudynku(string nazwaBudynku) => nazwaBudynku switch { "studnia" => PoziomBudynku("studnia") * 1000, _ => 0 };
        public int IloscPrzedmiotow(string nazwaPrzedmiotu) => Przedmioty.First(p => p.Nazwa == nazwaPrzedmiotu).Ilosc;
    }
}