namespace Dziekanowka.Rozgrywki
{
    public static class MechanizmSzachow
    {
        private static PoleSzachownicy? Pole(int x, int y, List<PoleSzachownicy> plansza) => plansza.FirstOrDefault(p => p.X == x && p.Y == y);
        //uwzglednic priorytet ucieczki spod szacha, a takze np. nieodsloniecie krola
        private static List<PoleSzachownicy> RuchyPiona(PoleSzachownicy bierka, List<PoleSzachownicy> plansza, PartiaSzachow partia)
        {
            var mozliwe = new List<PoleSzachownicy>();
            int kierunek = bierka.Bierka.EndsWith("Bialy") ? 1 : -1;
            int startY = bierka.Bierka.EndsWith("Bialy") ? 2 : 7;
            int liniaBiciaWPrzelocie = bierka.Bierka.EndsWith("Bialy") ? 5 : 4;
            var przod = Pole(bierka.X, bierka.Y + kierunek, plansza);
            if (przod != null && przod.Bierka == "")
            {
                mozliwe.Add(przod);
                if (bierka.Y == startY)
                {
                    var przod2 = Pole(bierka.X, bierka.Y + kierunek * 2, plansza);
                    if (przod2 != null && przod2.Bierka == "")
                        mozliwe.Add(przod2);
                }
            }
            foreach (int dx in new[] { -1, 1 })
            {
                var skos = Pole(bierka.X + dx, bierka.Y + kierunek, plansza);
                if (skos != null && skos.Bierka != "" && skos.Bierka.EndsWith("Bialy") != bierka.Bierka.EndsWith("Bialy"))
                    mozliwe.Add(skos);
            }
            if (bierka.Y == liniaBiciaWPrzelocie && partia.OstatniaBierka.StartsWith("pion") && partia.OstatniaBierka.EndsWith("Bialy") != bierka.Bierka.EndsWith("Bialy") && Math.Abs(partia.OstatniRuchY - partia.OstatniStartY) == 2 && partia.OstatniRuchY == bierka.Y && (partia.OstatniRuchX == bierka.X + 1 || partia.OstatniRuchX == bierka.X - 1))
            {
                var poleBicia = Pole(partia.OstatniRuchX, bierka.Y + kierunek, plansza);
                if (poleBicia != null)
                    mozliwe.Add(poleBicia);
            }
            // dodac promocje
            return mozliwe;
        }
        private static List<PoleSzachownicy> RuchySkoczka(PoleSzachownicy bierka, List<PoleSzachownicy> plansza)
        {
            var mozliwe = new List<PoleSzachownicy>();
            var skoki = new (int dx, int dy)[] { (1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1) };
            foreach (var (dx, dy) in skoki)
            {
                var sprPole = Pole(bierka.X + dx, bierka.Y + dy, plansza);
                if (sprPole == null) continue;
                if (sprPole.Bierka != "" && sprPole.Bierka.EndsWith("Bialy") == bierka.Bierka.EndsWith("Bialy")) continue;
                mozliwe.Add(sprPole);
            }
            return mozliwe;
        }
        private static List<PoleSzachownicy> RuchyGonca(PoleSzachownicy bierka, List<PoleSzachownicy> plansza)
        {
            var mozliwe = new List<PoleSzachownicy>();
            var kierunki = new (int dx, int dy)[] { (1, 1), (-1, 1), (1, -1), (-1, -1) };
            foreach (var (dx, dy) in kierunki)
            {
                for (int i = 1; i <= 7; i++)
                {
                    var sprPole = Pole(bierka.X + dx * i, bierka.Y + dy * i, plansza);
                    if (sprPole == null) break;
                    if (sprPole.Bierka != "" && sprPole.Bierka.EndsWith("Bialy") == bierka.Bierka.EndsWith("Bialy")) break;
                    mozliwe.Add(sprPole);
                    if (sprPole.Bierka != "") break;
                }
            }
            return mozliwe;
        }
        private static List<PoleSzachownicy> RuchyWiezy(PoleSzachownicy bierka, List<PoleSzachownicy> plansza)
        {
            var mozliwe = new List<PoleSzachownicy>();
            var kierunki = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            foreach (var (dx, dy) in kierunki)
            {
                for (int i = 1; i <= 7; i++)
                {
                    var sprPole = Pole(bierka.X + dx * i, bierka.Y + dy * i, plansza);
                    if (sprPole == null) break;
                    if (sprPole.Bierka != "" && sprPole.Bierka.EndsWith("Bialy") == bierka.Bierka.EndsWith("Bialy")) break;
                    mozliwe.Add(sprPole);
                    if (sprPole.Bierka != "") break;
                }
            }
            return mozliwe;
        }
        private static List<PoleSzachownicy> RuchyHetmana(PoleSzachownicy bierka, List<PoleSzachownicy> plansza) => [.. RuchyWiezy(bierka, plansza), .. RuchyGonca(bierka, plansza)];
        private static List<PoleSzachownicy> RuchyKrola(PoleSzachownicy bierka, List<PoleSzachownicy> plansza)
        {
            var mozliwe = new List<PoleSzachownicy>();
            var kroki = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, 1), (1, -1), (-1, -1) };
            foreach (var (dx, dy) in kroki)
            {
                var sprPole = Pole(bierka.X + dx, bierka.Y + dy, plansza);
                if (sprPole == null) continue;
                if (sprPole.Bierka != "" && sprPole.Bierka.EndsWith("Bialy") == bierka.Bierka.EndsWith("Bialy")) continue;
                mozliwe.Add(sprPole);
            }
            // uwzglednic roszade i niemoznosc wejscia na szachowane pola
            return mozliwe;
        }
        public static List<PoleSzachownicy> MozliweRuchy(PoleSzachownicy bierka, List<PoleSzachownicy> plansza, PartiaSzachow partia) => bierka.Bierka switch
            {
                var b when b.StartsWith("pion") => RuchyPiona(bierka, plansza, partia),
                var b when b.StartsWith("skoczek") => RuchySkoczka(bierka, plansza),
                var b when b.StartsWith("goniec") => RuchyGonca(bierka, plansza),
                var b when b.StartsWith("wieza") => RuchyWiezy(bierka, plansza),
                var b when b.StartsWith("hetman") => RuchyHetmana(bierka, plansza),
                var b when b.StartsWith("krol") => RuchyKrola(bierka, plansza),
                _ => []
            };
    }
}