namespace Dziekanowka.Gracza
{
    public class Obiad(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<Obiad> DaniaZPatelni = [new("jajecznica"), new("jajkoSadzone"), new("omlet"), new("shakshuka"), new("kotletSchabowy"), new("kotletMielony"), new("stek"),
        new("piersZKurczaka"), new("bitki"), new("karkowka"), new("indykSmazony"), new("krolikSmazony"), new("golabki"), new("pstragSmazony"), new("lososSmazony"), new("halibutSmazony"), new("okonSmazony"), new("sledzSmazony"),
        new("plackiZiemniaczane"), new("frytki"), new("pierogiRuskie"), new("pierogiZMiesem"), new("pierogiZKapustaIGrzybami"), new("pierogiZOwocami"), new("kopytka"), new("knedle"), new("nalesniki"), new("racuchy")];
        public static List<Obiad> DaniaZGarnka = [];
        public static List<Obiad> StartoweObiady() => DaniaZPatelni.Concat(DaniaZGarnka).Select(d => new Obiad(d.Nazwa)).ToList();
    }
}