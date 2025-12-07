namespace Dziekanowka.Gracza
{
    public class PoleUprawne(int id, int x, int y, string warzywo = "")
    {
        public int Id { get; set; } = id;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Poziom { get; set; } = 0;
        public string Warzywo { get; set; } = warzywo;
        public static List<PoleUprawne> StartowePola()
        {
            List<string> w = [ "kukurydza", "groch", "jarmuż", "pasternak", "pietruszka", "burak", "brukselka", "sorgo", "rzepaPastewna", "koniczyna", "sałata", "marchew", "ziemniak",
                       "cebula", "szczypiorek", "pomidor", "papryka", "ogórek", "czosnek", "rzodkiewka" ];
            int i = 0;
            return (from id in new[] { 1, 2 } from x in Enumerable.Range(1, 5) from y in Enumerable.Range(1, 4) select new PoleUprawne(id, x, y, id == 1 ? w[i++] : "")).ToList();
        }
    }
}
