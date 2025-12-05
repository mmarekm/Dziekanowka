using Dziekanowka.Gracza;
namespace Dziekanowka
{
    public class Gracz(string nazwa)
    {
        public string Nazwa { get; set;  } = nazwa;
        public int Monety { get; set; } = 0;
        public Statystyki Statystyki { get; set; } = new Statystyki();
        public List<PrzedmiotGracza> Przedmioty { get; set; } = PrzedmiotGracza.StartowePrzedmioty();
        public List<BudynekGracza> Budynki { get; set; } = BudynekGracza.StartoweBudynki();
        public Paliwo Paliwo { get; set; } = new Paliwo();
        public int PoziomBudynku(string nazwaBudynku) => Budynki.First(b => b.Nazwa == nazwaBudynku).Poziom;
        public void UlepszBudynek(string nazwaBudynku) => Budynki.First(b => b.Nazwa == nazwaBudynku).Poziom++;
        public int KosztUlepszeniaBudynku(string nazwaBudynku) => nazwaBudynku switch { "studnia" => PoziomBudynku("studnia") * 1000, _ => 0 };
        public int IloscPrzedmiotow(string nazwaPrzedmiotu) => Przedmioty.First(p => p.Nazwa == nazwaPrzedmiotu).Ilosc;
    }
}