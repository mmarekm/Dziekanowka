namespace Dziekanowka.Gracza
{
    public class ZbozeGracza(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public int PoziomZakwasu { get; set; } = 0;
        public int OstatniDzienZakwaszenia { get; set; } = 0;
        public int OstatniMiesiacZakwaszenia { get; set; } = 0;
        public bool MoznaZakwasicDzisiaj => OstatniDzienZakwaszenia != DateTime.Now.Day || OstatniMiesiacZakwaszenia != DateTime.Now.Month;
        public static List<ZbozeGracza> StartoweZboza() => [new("zyto"), new("jeczmien"), new("pszenica"), new("ryz"), new("owies"), new("gryka"), new("orkisz")];
    }
}
