namespace Dziekanowka.Gracza
{
    public class Obiad(string nazwa) : IDar
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = 0;
        public static List<Obiad> StartoweObiady() => [new("jajecznica"), new("jajkoSadzone"), new("omlet"), new("shakshuka"), new("kotletSchabowy"), new("kotletMielony"), new("stek"),
        new("piersZKurczaka"), new("bitki"), new("indykSmazony"), new("krolikSmazony"), new("pstragSmazony"), new("lososSmazony"), new("halibutSmazony"), new("okonSmazony"), new("sledzSmazony")];
    }
}