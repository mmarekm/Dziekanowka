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
            List<string> w1 = [ "kukurydza", "groch", "jarmuż", "pasternak", "pietruszka", "burak", "brukselka", "sorgo", "rzepaPastewna", "koniczyna", "sałata", "marchew", "ziemniak",
               "cebula", "szczypiorek", "pomidor", "papryka", "ogórek", "czosnek", "rzodkiewka" ];
            List<string> w2 = [ "szpinak", "rukola", "batat", "szczaw", "seler", "boćwina", "por", "fasola", "bób", "ciecierzyca", "bakłażan", "cukinia", "dynia",
               "brokuł", "kalafior", "kapustaWłoska", "kapustaPekińska", "szparagi", "selerNaciowy", "soczewica" ];
            int i1 = 0;
            int i2 = 0;
            return (from id in new[] { 1, 2 } from x in Enumerable.Range(1, 5) from y in Enumerable.Range(1, 4) select new PoleUprawne(id, x, y, id == 1 ? w1[i1++] : w2[i2++])).ToList();
        }
    }
}
