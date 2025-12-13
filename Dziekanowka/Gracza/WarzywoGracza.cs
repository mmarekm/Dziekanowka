namespace Dziekanowka.Gracza
{
    public class WarzywoGracza(string nazwa)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<WarzywoGracza> StartoweWarzywa() => [new("kukurydza"), new("groch"), new("jarmuż"), new("pasternak"), new("pietruszka"), new("burak"), new("brukselka"),
		new("sorgo"), new("rzepaPastewna"), new("koniczyna"), new("sałata"), new("marchew"), new("ziemniak"), new("cebula"), new("szczypiorek"), new("pomidor"), new("papryka"),
		new("ogórek"), new("czosnek"), new("rzodkiewka"), new("szpinak"), new("rukola"), new("batat"), new("szczaw"), new("seler"), new("boćwina"), new("por"), new("fasola"), new("bób"),
		new("ciecierzyca"), new("bakłażan"), new("cukinia"), new("dynia"), new("brokuł"), new("kalafior"), new("kapustaWłoska"), new("kapustaPekińska"), new("szparagi"), new("selerNaciowy"),
		new("soczewica")];
    }
}
