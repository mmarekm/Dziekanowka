namespace Dziekanowka.Gracza
{
    public class SadyGracza(int id, int x, int y, string owoc = "")
    {
        public int Id { get; set; } = id;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Poziom { get; set; } = -1;
        public string Owoc { get; set; } = owoc;
        public static List<SadyGracza> StartoweSady()
        {
            List<string> o1 = ["brzoskwinia", "nektarynka", "morela", "śliwka", "wiśnia", "czereśnia", "jabłko", "gruszka", "pomarańcza",
                "mandarynka", "cytryna", "grejpfrut", "mango", "papaja", "awokado", "kokos"];
            List<string> o2 = ["truskawka", "malina", "jeżyna", "borówka", "porzeczkaCzerwona", "porzeczkaCzarna", "żurawina", "banan", "ananas",
                "marakuja", "arbuz", "melon", "winogronoJasne", "winogronoRóżowe", "winogronoCiemne", "kiwi"];
            int i1 = 0;
            int i2 = 0;
            return (from id in new[] { 1, 2 } from x in Enumerable.Range(1, 4) from y in Enumerable.Range(1, 4) select new SadyGracza(id, x, y, id == 1 ? o1[i1++] : o2[i2++])).ToList();
        }
    }
}