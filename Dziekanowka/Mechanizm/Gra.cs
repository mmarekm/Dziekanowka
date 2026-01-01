using Dziekanowka.Gracza;
namespace Dziekanowka.Mechanizm
{
    public static class Gra
    {
        public static bool JestZwierze(this Gracz g, string zwierz) => g.Zwierzeta.Any(z => z.Nazwa == zwierz && z.Ilosc > 0);
        public static bool JestWarzywo(this Gracz g, string warzywo) => g.Warzywa.Any(w => w.Nazwa == warzywo && w.Ilosc > 0);
        public static bool JestZboze(this Gracz g, string zboze) => g.Zboza.Any(w => w.Nazwa == zboze && w.Ilosc > 0);
        public static bool JestOwoc(this Gracz g, string owoc) => g.Owoce.Any(o => o.Nazwa == owoc && o.Ilosc > 0);
        public static bool JestPrzedmiot(this Gracz g, string przedmiot) => g.Przedmioty.Any(p => p.Nazwa == przedmiot && p.Ilosc > 0);
        public static ZwierzeGracza Zwierze(this Gracz g, string zwierz) => g.Zwierzeta.First(z => z.Nazwa == zwierz);
        public static ProduktZwierzecy ProduktZ(this Gracz g, string produkt) => g.ProduktyZwierzece.First(p => p.Nazwa == produkt);
        public static IDar Warzywo(this Gracz g, string warzywo) => g.Warzywa.First(w => w.Nazwa == warzywo);
        public static IDar Zboze(this Gracz g, string zboze) => g.Zboza.First(z => z.Nazwa == zboze);
        public static IDar Owoc(this Gracz g, string owoc) => g.Owoce.First(o => o.Nazwa == owoc);
        public static PrzedmiotGracza Przedmiot(this Gracz g, string przedmiot) => g.Przedmioty.First(p => p.Nazwa == przedmiot);
    }
}