namespace Dziekanowka.Gracza
{
    public class OwocGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<OwocGracza> StartoweOwoce() => [new("brzoskwinia"), new("nektarynka"), new("morela"), new("śliwka"), new("wiśnia"), new("czereśnia"), new("jabłko"), new("gruszka"),
		new("truskawka"), new("malina")];
    }
}
