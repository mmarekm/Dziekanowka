namespace Dziekanowka.Rozgrywki
{
    public static class MechanizmSzachow
    {
        private static PoleSzachownicy? Pole(int x, int y, List<PoleSzachownicy> plansza) => plansza.FirstOrDefault(p => p.X == x && p.Y == y);
        public enum StanGry { Trwa, Szach, Mat, Pat }
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
        private static List<PoleSzachownicy> RuchyKrola(PoleSzachownicy bierka, List<PoleSzachownicy> plansza, PartiaSzachow partia, bool ignorujRoszade = false)
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
            if (!ignorujRoszade)
            {
                bool bialy = bierka.Bierka.EndsWith("Bialy");
                int yKrola = bialy ? 1 : 8;
                if (bierka.X == 5 && bierka.Y == yKrola)
                {
                    if ((bialy && !partia.BialyKrolRuszal && !partia.BialaWiezaKrolRuszala) ||
                        (!bialy && !partia.CzarnyKrolRuszal && !partia.CzarnaWiezaKrolRuszala))
                    {
                        var wiezaKrolewska = Pole(8, yKrola, plansza);
                        if (wiezaKrolewska != null && wiezaKrolewska.Bierka.StartsWith("wieza") &&
                            Pole(6, yKrola, plansza)?.Bierka == "" && Pole(7, yKrola, plansza)?.Bierka == "")
                        {
                            if (!CzyPoleAtakowane(5, yKrola, !bialy, plansza, partia) &&
                                !CzyPoleAtakowane(6, yKrola, !bialy, plansza, partia) &&
                                !CzyPoleAtakowane(7, yKrola, !bialy, plansza, partia))
                            {
                                var poleRoszady = Pole(7, yKrola, plansza);
                                if (poleRoszady != null) mozliwe.Add(poleRoszady);
                            }
                        }
                    }
                    if ((bialy && !partia.BialyKrolRuszal && !partia.BialaWiezaKrolowaRuszala) ||
                        (!bialy && !partia.CzarnyKrolRuszal && !partia.CzarnaWiezaKrolowaRuszala))
                    {
                        var wiezaHetmanska = Pole(1, yKrola, plansza);
                        if (wiezaHetmanska != null && wiezaHetmanska.Bierka.StartsWith("wieza") &&
                            Pole(2, yKrola, plansza)?.Bierka == "" && Pole(3, yKrola, plansza)?.Bierka == "" && Pole(4, yKrola, plansza)?.Bierka == "")
                        {
                            if (!CzyPoleAtakowane(5, yKrola, !bialy, plansza, partia) &&
                                !CzyPoleAtakowane(4, yKrola, !bialy, plansza, partia) &&
                                !CzyPoleAtakowane(3, yKrola, !bialy, plansza, partia))
                            {
                                var poleRoszady = Pole(3, yKrola, plansza);
                                if (poleRoszady != null) mozliwe.Add(poleRoszady);
                            }
                        }
                    }
                }
            }
            return mozliwe;
        }
        public static List<PoleSzachownicy> MozliweRuchy(PoleSzachownicy bierka, List<PoleSzachownicy> plansza, PartiaSzachow partia, bool ignorujRoszade = false) => bierka.Bierka switch
            {
                var b when b.StartsWith("pion") => RuchyPiona(bierka, plansza, partia),
                var b when b.StartsWith("skoczek") => RuchySkoczka(bierka, plansza),
                var b when b.StartsWith("goniec") => RuchyGonca(bierka, plansza),
                var b when b.StartsWith("wieza") => RuchyWiezy(bierka, plansza),
                var b when b.StartsWith("hetman") => RuchyHetmana(bierka, plansza),
                var b when b.StartsWith("krol") => RuchyKrola(bierka, plansza, partia, ignorujRoszade),
                _ => []
            };
        public static List<PoleSzachownicy> LegalneRuchy(PoleSzachownicy bierka, List<PoleSzachownicy> plansza, PartiaSzachow partia)
        {
            var pseudolegalne = MozliweRuchy(bierka, plansza, partia);
            var legalne = new List<PoleSzachownicy>();
            bool bialy = bierka.Bierka.EndsWith("Bialy");
            int startX = bierka.X;
            int startY = bierka.Y;
            string nazwaBierki = bierka.Bierka;
            foreach (var cel in pseudolegalne)
            {
                string oryginalnaBierkaCelu = cel.Bierka;
                PoleSzachownicy? zbityPionWPrzelocie = null;
                string nazwaZbitegoPiona = "";
                bool czyRoszada = nazwaBierki.StartsWith("krol") && Math.Abs(cel.X - startX) == 2;
                PoleSzachownicy? wiezaStart = null;
                PoleSzachownicy? wiezaCel = null;
                string nazwaWiezy = "";
                cel.Bierka = nazwaBierki;
                bierka.Bierka = "";
                if (nazwaBierki.StartsWith("pion") && cel.X != startX && oryginalnaBierkaCelu == "")
                {
                    zbityPionWPrzelocie = Pole(cel.X, startY, plansza);
                    if (zbityPionWPrzelocie != null)
                    {
                        nazwaZbitegoPiona = zbityPionWPrzelocie.Bierka;
                        zbityPionWPrzelocie.Bierka = "";
                    }
                }
                if (czyRoszada)
                {
                    int xWiezy = cel.X == 7 ? 8 : 1;
                    int xNowyWiezy = cel.X == 7 ? 6 : 4;
                    wiezaStart = Pole(xWiezy, cel.Y, plansza);
                    wiezaCel = Pole(xNowyWiezy, cel.Y, plansza);
                    if (wiezaStart != null && wiezaCel != null)
                    {
                        nazwaWiezy = wiezaStart.Bierka;
                        wiezaCel.Bierka = nazwaWiezy;
                        wiezaStart.Bierka = "";
                    }
                }
                var krol = plansza.FirstOrDefault(p => p.Bierka == (bialy ? "krolBialy" : "krolCzarny"));
                if (krol != null && !CzyPoleAtakowane(krol.X, krol.Y, !bialy, plansza, partia))
                        legalne.Add(cel);
                if (czyRoszada && wiezaStart != null && wiezaCel != null)
                {
                    wiezaStart.Bierka = nazwaWiezy;
                    wiezaCel.Bierka = "";
                }
                if (zbityPionWPrzelocie != null)
                    zbityPionWPrzelocie.Bierka = nazwaZbitegoPiona;
                bierka.Bierka = nazwaBierki;
                cel.Bierka = oryginalnaBierkaCelu;
            }
            return legalne;
        }
        public static StanGry SprawdzStanGry(bool ruchBialych, List<PoleSzachownicy> plansza, PartiaSzachow partia)
        {
            var krol = plansza.First(p => p.Bierka == (ruchBialych ? "krolBialy" : "krolCzarny"));
            bool czySzach = CzyPoleAtakowane(krol.X, krol.Y, !ruchBialych, plansza, partia);
            bool maLegalnyRuch = plansza.Where(p => p.Bierka != "" && p.Bierka.EndsWith(ruchBialych ? "Bialy" : "Czarny")).Any(p => LegalneRuchy(p, plansza, partia).Count > 0);
            if (maLegalnyRuch) return czySzach ? StanGry.Szach : StanGry.Trwa;
            if (czySzach) return StanGry.Mat;
            return StanGry.Pat;
        }
        public static bool CzyPoleAtakowane(int x, int y, bool przezBialych, List<PoleSzachownicy> plansza, PartiaSzachow partia)
        {
            foreach (var pole in plansza)
            {
                if (pole.Bierka == "" || pole.Bierka.EndsWith("Bialy") != przezBialych) continue;
                if (pole.Bierka.StartsWith("pion"))
                {
                    int kierunek = pole.Bierka.EndsWith("Bialy") ? 1 : -1;
                    if (Math.Abs(pole.X - x) == 1 && pole.Y + kierunek == y)
                        return true;
                    continue;
                }
                var ruchy = MozliweRuchy(pole, plansza, partia, ignorujRoszade: true);
                if (ruchy.Any(p => p.X == x && p.Y == y))
                    return true;
            }
            return false;
        }
    }
}