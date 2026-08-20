namespace Dziekanowka.Gracza
{
    public class DzieloZPiorIFutra(string nazwa, int ilosc = 0)
    {
        public string Nazwa { get; set; } = nazwa;
        public int Ilosc { get; set; } = ilosc;
        public static List<DzieloZPiorIFutra> StartoweDziela() => [
            new("ozdobaDoKapelusza"), new("zakladkaDoKsiazki"), new("pedzelDoMalowania"), new("pioroDoPisania"), new("maskotkaMala"), new("strzalaDoLuku"), new("poduszeczkaNaIgly"),
            new("wachlarzOzdobny"), new("czapkaZimowa"), new("kapeluszMixPior"), new("poduszkaMala"), new("mufkaNaRece"), new("wypchaneZwierzatko"), new("pomPomZestaw"), new("koldraPuchowa"), 
            new("kamizelkaFutrzana"), new("kapturFutrzany"), new("poduszkaPremium"), new("kolnierzOcieplacz"), new("kocFutrzany"), new("kurtkaZimowa"), new("strojZimowyKomplet"), 
            new("plaszczReprezentacyjny"), new("dywanikFutrzany")
        ];
    }
}