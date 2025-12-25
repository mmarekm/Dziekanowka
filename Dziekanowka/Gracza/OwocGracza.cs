namespace Dziekanowka.Gracza
{
    public class OwocGracza(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<OwocGracza> StartoweOwoce() => [new("brzoskwinia"), new("nektarynka"), new("morela"), new("śliwka"), new("wiśnia"), new("czereśnia"), new("jabłko"), new("gruszka"),
		new("truskawka"), new("malina"), new("jeżyna"), new("borówka"), new("porzeczkaCzerwona"), new("porzeczkaCzarna"), new("żurawina"), new("pomarańcza"), new("mandarynka"),
		new("cytryna"), new("grejpfrut"), new("banan"), new("ananas"), new("mango"), new("papaja"), new("marakuja"), new("kokos"), new("awokado"), new("arbuz"), new("melon"),
		new("winogronoJasne"), new("winogronoRóżowe"), new("winogronoCiemne"), new("kiwi")];
    }
}
