using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiszkiklasy
{
    public struct Fiszki
    {
        public static string[,] numbers = {{"zero","jeden","dwa","trzy","cztery","pięć","sześć","siedem","osiem","dziewięć","dziesięć","jedenaście","dwanaście","trzynaście","czternaście",
    "piętnaście","szesnaście","siedemnaście","osiemnaście","dziewiętnaście","dwadzieścia","trzydzieści","czterdzieści","pięćdziesiąt","sześćdziesiąt","siedemdziesiąt","osiemdziesiąt",
    "dziewięćdziesiąt","sto","tysiąc","milion","połowa","numer","metr" },
    {"zero","one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen","twenty",
    "thirty","forty","fifty","sixty","seventy","eighty","ninety","hundred","thousand","million","half","number","metre"} };
        public static string[,] colors = { {"czarny","biały","czerwony","żółty","zielony","niebieski","szary","różowy","pomarańczowy","brązowy","fioletowy","duży","mały","długi","kolor",
    "okrągły","złoty","srebrny","kwadratowy","kształt"},
    {"black","white","red","yellow","green","blue","grey","pink","orange","brown","purple","big","small","long","colour","round","gold","silver","square","shape"} };
        public static string[,] animals = { {"zwierzak domowy","zwierzę","kot","pies","ryba","chomik","krowa","koń","kaczka","osioł","małpa","ptak","papuga","kurczak","ślimak","motyl",
    "mucha","lew","mysz","słoń","pszczoła","wilk","lis","królik","komar","żaba","świnia","tygrys","owca" },{"pet","animal","cat","dog","fish","hamster","cow","horse","duck","donkey",
    "monkey","bird","parrot","chicken","snail","butterfly","fly","lion","mouse","elephant","bee","wolf","fox","rabbit","mosquito","frog","pig","tiger","sheep" } };
        public static string[,] time = { {"czas","noc","rano","popołudnie","wieczór","pora roku","rok","miesiąc","tydzień","dzień","godzina","minuta","sekunda","poniedziałek","wtorek",
    "środa","czwartek","piątek","sobota","niedziela","styczeń","luty","marzec","kwiecień","maj","czerwiec","lipiec","sierpień","wrzesień","październik","listopad","grudzień","wiosna",
    "lato","jesień","zima","dzisiaj","wczoraj","jutro","następny","codziennie","nigdy"},{"time","night","morning","afternoon","evening","season","year","month","week","day","hour",
    "minute","second","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday","January","February","March","April","May","June","July","August","September","October",
    "November","December","spring","summer","autumn","winter","today","yesterday","tomorrow","next","every day","never"} };
        public static string[,] family = { {"rodzina","ojciec","matka","córka","syn","wujek","ciocia","brat","siostra","babcia","dziadek","rodzic","mężczyzna","kobieta","mąż","żona",
    "dziecko","chłopiec","dziewczynka","kuzyn","chłopak (sympatia)","dziewczyna (sympatia)","rozwiedziony","żonaty/mężatka","ślub","być razem","wdowa","przyjaciel","urodzić się"},
    {"family","father","mother","daughter","son","uncle","aunt","brother","sister","grandmother","grandfather","parent","man","woman","husband","wife","child","boy","girl","cousin",
    "boyfriend","girlfriend","divorced","married","wedding","be together","widow","friend","be born"} };
        public static string[,] home = { {"klucz","pokój","lodówka","salon","sypialnia","łazienka","kuchnia","szafa","książka","regał","pralka","zlew","prysznic","wanna","stół","krzesło",
    "łóżko","kanapa","okno","ściana","podłoga","parter","drzwi","sufit","dywan","otwierać","zamykać","garaż","piwnica","lustro","adres","dom","mieszkanie","zasłony"},
    {"key","room","fridge","living room","bedroom","bathroom","kitchen","wardrobe","book","bookshelf","washing machine","sink","shower","bathtub","table","chair","bed",
    "sofa","window","wall","floor","ground floor","door","ceiling","carpet","open","close","garage","cellar","mirror","address","house","flat","curtains"} };
        public static string[,] tournee = { {"wycieczka","rower","prom","lotnisko","przystanek autobusowy","metro","bagaż","turysta","lot","jechać samochodem","wracać","autobus","pociąg",
    "samochód","samolot","(po)wolny","szybki","skręcać","gubić","bilet","paszport","dworzec","iść"},
    {"trip","bike","ferry","airport","bus stop","underground","luggage","tourist","flight","drive","come back","bus","train","car","plane","slow","fast","turn","lose","ticket",
    "passport","station","go"} };
        public static string[,] food = { {"jabłko","banan","pomidor","ziemniak","marchewka","cebula","czosnek","ogórek","mięso","ryż","ryba","kurczak","makaron","chleb","śliwka","gruszka",
    "brzoskwinia","pomarańcza","cytryna","jajko","mleko","sok","herbata","woda","kawa","śniadanie","obiad","kolacja","truskawka","jagoda","malina","jeść","pić","owoc","warzywo",
    "ciasto","głodny","spragniony","sól","deser","ser żółty","masło","zupa","jedzenie","gotować"},{"apple","banana","tomato","potato","carrot","onion","garlic","cucumber","meat","rice",
    "fish","chicken","pasta","bread","plum","pear","peach","orange","lemon","egg","milk","juice","tea","water","coffee","breakfast","dinner","supper","strawberry","berry","raspberry",
    "eat","drink","fruit","vegetable","cake","hungry","thirsty","salt","dessert","cheese","butter","soup","food","cook"} };
        public static string[,] speak = { {"imię","nad","obok","pomiędzy","przed","ale","też","pod","w","na","za","i, oraz","do widzenia","dziękuję","Jak się masz?","dobry wieczór",
    "dzień dobry (przed południem)","dzień dobry (po południu)","przepraszam (za coś)","przepraszam (z zapytaniem)","proszę (o coś)","ja","ty (wy)","to","on","ona","my","oni (one)",
    "tak","nie","mieć","dobry","cześć","zły","chcieć","brać","robić","wspaniały","Ile? (policzalne)","Kto?","Co?","znać, wiedzieć","Gdzie?","Jak?","mówić, przemawiać","nie ma za co",
    "Dlaczego?","mieszkać","być","robić","Ile? (niepoliczalne)","Kiedy?","dawać"},{"name","over","next to","between","in front of","but","too","under","in","on","behind","and",
    "goodbye","thank you","How are you?","good evening","good morning","good afternoon","sorry","excuse me","please","I","you","it","he","she","we","they","yes","no","have","good",
    "hello","bad","want","take","make","great","How many?","Who?","What?","know","Where?","How?","speak","you are welcome","Why?","live","be","robić","How much?","When?","give"} };
        public static string[,] city = { {"ogród","droga","park","pole","stolica","ulica","gospodarstwo","plac","sąsiad","most","miasto","wioska","poczta","tereny wiejskie","kościół",
    "biblioteka","muzeum","bank"},
    {"garden","road","park","field","capital","street","farm","square","neighbour","bridge","city","village","post office","countryside","church","library","museum","bank"} };
        public static string[,] school = { {"egzamin","ocena","znaczyć","ołówek","książka","szkoła","uczeń","słowo","uczyć","uczyć się","rozumieć","język","matematyka","zdać","nie zdać",
    "historia","geografia","przerwa","pisać","tablica","klasa","długopis","praca domowa","zeszyt","nauczyciel","uniwersytet","ćwiczenie"},
    {"exam","mark","mean","pencil","book","school","student","word","teach","learn","understand","language","maths","pass","fail","history","geography","break","write","blackboard",
    "class","pen","homework","copybook","teacher","university","exercise"} };
        public static string[,] feature = { {"przystojny","stary","młody","ładny","elegancki","wysoki","niski","czysty","prosty","kręcony","brudny","piękny","brzydki","gruby","szczupły"},
    {"handsome","old","young","pretty","elegant","tall","short","clean","straight","curly","dirty","beautiful","ugly","fat","slim"} };
        public static string[,] nature = { {"przyroda","niebo","chmura","słońce","księżyc","jezioro","rzeka","morze","drzewo","liść","kwiat","roślina","trawa","las","góra","gorąco",
    "ciepło","zimno","wiatr","pogoda","deszcz","śnieg","burza"},{"nature","sky","cloud","sun","moon","lake","river","sea","tree","leaf","flower","plant","grass","forest","mountain",
    "hot","warm","cold","wind","weather","rain","snow","storm"} };
        public static string[,] body = { {"głowa","włosy","ucho","oko","nos","ząb","usta","twarz","szyja","ramię","brzuch","plecy","ręka","noga","kolano","stopa","palec u nogi",
    "palec u ręki","broda"},{"head","hair","ear","eye","nose","tooth","lips","face","neck","arm","stomach","back","hand","leg","knee","foot","toe","finger","beard" } };
        public static string[,] clothes = { {"kurtka","skarpetka","pasek","okulary","szalik","rękawiczka","but","spodnie","parasol","koszulka","sukienka","czapka","kapelusz","spódnica",
    "koszula","płaszcz","przymierzać","rozmiar"},
    {"jacket","sock","belt","glasses","scarf","glove","shoe","trousers","umbrella","T-shirt","dress","cap","hat","skirt","shirt","coat","try on","size"} };
        public static string[,] countries = { {"Wielka Brytania (Zjednoczone Królestwo)","Japończyk, japoński","Japonia","Rosjanin, rosyjski","Rosja","Kanadyjczyk, kanadyjski","Kanada",
    "Amerykanin, amerykański","Stany Zjednoczone Ameryki","Australijczyk, australijski","Australia","Grek, grecki","narodowość","kraj"}, {"United Kingdom","Japanese","Japan","Russian",
    "Russia","Canadian","Canada","American","United States of America","Australian","Australia","Greek","nationality","country"} };
        public static string[,] toilet = { {"spóźniać się","ścielić łóżko","czesać się","ścierać kurz","myć","budzić się","spać","śpieszyć się"},{"be late","make the bed","comb","dust",
    "wash","wake up","sleep","hurry"} };
        public static string[,] relax = { {"relaksować się","śpiewać","pływać","przyjęcie, impreza","bawić się","zainteresowania","robić zdjęcia","wakacje","malować","słuchać","czytać",
    "kino","teatr","koncert","oglądać","uprawiać sporty","biegać","tańczyć"}, {"relax","sing","swim","party","play","hobbies","take photos","holiday","paint","listen","read","cinema",
    "theatre","concert","watch","do sports","run","dance"} };
        public static string[,] feelings = { {"zmęczony","bać się","płakać","śmiać się","uśmiechać się","zdenerwowany","senny","zły (na kogoś)","smutny","szczęśliwy","nienawidzić",
    "kochać","lubić","dumny","nudny","zaskakiwać","uczucie","myśleć","martwić się"}, {"tired","be scared","cry","laugh","smile","nervous","sleepy","angry","sad","happy","hate","love",
    "like","proud","boring","surprise","feeling","think","worry"} };
        public static string[,] shopping = { {"portfel","centrum handlowe","księgarnia","piekarnia","drogi","tani","płacić","bankomat","sklep","sprzedawać","pieniądze","targ","cena",
    "koszyk","półka","reszta","kupować","zakupy"},{"wallet","shopping center","bookshop","bakery","expensive","cheap","pay","cashpoint","shop","sell","money","market","price","basket",
    "shelf","change","buy","shopping" } };
        public static string[,] job = { {"muzyk","malarz","naukowiec","policjant","strażak","pielęgniarka","architekt","sekretarka","mechanik","informatyk","programista","inżynier",
    "aktor","artysta","lekarz","dziennikarz","sprzedawca","fryzjer","prawnik","dzwonić","kopiować","ekran","plik, dokument","klawiatura","telefon komórkowy","drukować","zapisywać",
    "włączać","wyłączać","praca","biuro","komputer","szef"},{"musician","painter","scientist","police officer","fireman","nurse","architect","secretary","mechanic","IT specialist",
    "computer programmer","engineer","actor","artist","doctor","journalist","shop assistant","hairdresser","lawyer","phone","copy","screen","file","keyboard","mobile phone","print",
    "save","turn on","turn off","work","office","computer","boss"} };
        public static string[,] character = { {"arogancki","radosny","nieśmiały","szalony","uparty","inteligentny","spokojny","towarzyski","odważny","miły","sympatyczny","uczciwy",
    "mądry","cierpliwy","samolubny"},{"rude","cheerful","shy","crazy","stubborn","intelligent","calm","outgoing","brave","nice","friendly","honest","clever","patient","selfish" } };
        public static string[,] health = { {"pigułka, tabletka","choroba","chory","zdrowy","lekarstwo","karetka","apteka","łamać","kaszel","przeziębić się","grypa","gorączka",
    "umawiać się (na wizytę)","ból","boleć","ból głowy","ból gardła","czuć się","szpital"},{"pill","illness","sick","healthy","medicine","ambulance","pharmacy","break","cough",
    "catch a cold","flu","fever","make an appointment","pain","hurt","headache","sore throat","feel","hospital" } };
        public static string[][,] kategorie = { numbers, colors, animals, time, family, home, tournee, food, speak, city, school, feature, nature, body, clothes, countries, toilet,
            relax, feelings, shopping, job, character, health };
        public static void ListaSlowek(string[,] kategoria)
        {
            for (int i = 0; i < kategoria.GetLength(1); i++)
            {
                Console.WriteLine($"{kategoria[0, i]}\t\t{kategoria[1, i]}");
            }
        }
        public static string[,] WyborKategorii(ConsoleKey klawisz)
        {
            switch (klawisz)
            {
                case ConsoleKey.A:
                    return kategorie[0];
                case ConsoleKey.B:
                    return kategorie[1];
                case ConsoleKey.C:
                    return kategorie[2];
                case ConsoleKey.D:
                    return kategorie[3];
                case ConsoleKey.E:
                    return kategorie[4];
                case ConsoleKey.F:
                    return kategorie[5];
                case ConsoleKey.G:
                    return kategorie[6];
                case ConsoleKey.H:
                    return kategorie[7];
                case ConsoleKey.I:
                    return kategorie[8];
                case ConsoleKey.J:
                    return kategorie[9];
                case ConsoleKey.K:
                    return kategorie[10];
                case ConsoleKey.L:
                    return kategorie[11];
                case ConsoleKey.M:
                    return kategorie[12];
                case ConsoleKey.N:
                    return kategorie[13];
                case ConsoleKey.O:
                    return kategorie[14];
                case ConsoleKey.P:
                    return kategorie[15];
                case ConsoleKey.Q:
                    return kategorie[16];
                case ConsoleKey.R:
                    return kategorie[17];
                case ConsoleKey.S:
                    return kategorie[18];
                case ConsoleKey.T:
                    return kategorie[19];
                case ConsoleKey.U:
                    return kategorie[20];
                case ConsoleKey.V:
                    return kategorie[21];
                case ConsoleKey.W:
                    return kategorie[22];
                default:
                    return kategorie[0];
            }
        }

    }
}