namespace Dziekanowka.Mechanizm.JezykiObce
{
    public class Fiszki
    {
        private static string[,] numbersBasic = {{"zero","jeden","dwa","trzy","cztery","pięć","sześć","siedem","osiem","dziewięć","dziesięć","jedenaście","dwanaście","trzynaście","czternaście","piętnaście","szesnaście","siedemnaście","osiemnaście","dziewiętnaście","dwadzieścia"},
                                                  {"zero","one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen","twenty"},
                                                  {"cero","uno","dos","tres","cuatro","cinco","seis","siete","ocho","nueve","diez","once","doce","trece","catorce","quince","dieciséis","diecisiete","dieciocho","diecinueve","veinte"} };

        private static string[,] numbersAdvanced = {{"trzydzieści","czterdzieści","pięćdziesiąt","sześćdziesiąt","siedemdziesiąt","osiemdziesiąt","dziewięćdziesiąt","sto","tysiąc","milion","pierwszy","drugi","trzeci","czwarty","piąty","ostatni"},
                                                     {"thirty","forty","fifty","sixty","seventy","eighty","ninety","hundred","thousand","million","first","second","third","fourth","fifth","last"},
                                                     {"treinta","cuarenta","cincuenta","sesenta","setenta","ochenta","noventa","cien","mil","millón","primero","segundo","tercero","cuarto","quinto","último"} };

        private static string[,] descriptiveAdjectives = {{"łatwy","trudny","ważny","różny","taki sam","wolny (dostępny)","zajęty","pełny","pusty","blisko","daleko","możliwy","niemożliwy","duży","mały","długi","okrągły","kwadratowy","kształt","numer","metr","połowa"},
                                                           {"easy","difficult","important","different","same","free (available)","busy","full","empty","near","far","possible","impossible","big","small","long","round","square","shape","number","metre","half"},
                                                           {"fácil","difícil","importante","diferente","mismo","libre","ocupado","lleno","vacío","cerca","lejos","posible","imposible","grande","pequeño","largo","redondo","cuadrado","la forma","el número","el metro","la mitad"} };

        private static string[,] viewsComparisons = {{"zgadzać się","nie zgadzać się","moim zdaniem","myślę, że","mieć rację","mylić się","według mnie","zgoda!","masz rację","to zależy","więcej","mniej","najwięcej","najlepszy","najgorszy","tyle samo","kilka","wiele","mało"},
                                                      {"agree","disagree","in my opinion","I think that","be right","be wrong","in my view","agreed!","you're right","it depends","more","less","most","best","worst","the same amount","a few","a lot","little"},
                                                      {"estar de acuerdo","no estar de acuerdo","en mi opinión","creo que","tener razón","equivocarse","desde mi punto de vista","¡de acuerdo!","tienes razón","depende","más","menos","lo más","el mejor","el peor","la misma cantidad","unos pocos","mucho","poco"} };

        private static string[,] colors = {{"czarny","biały","czerwony","żółty","zielony","niebieski","szary","różowy","pomarańczowy","brązowy","fioletowy","kolor","złoty","srebrny"},
                                            {"black","white","red","yellow","green","blue","grey","pink","orange","brown","purple","colour","gold","silver"},
                                            {"negro","blanco","rojo","amarillo","verde","azul","gris","rosa","naranja","marrón","morado","el color","dorado","plateado"} };

        private static string[,] animalsDomestic = {{"zwierzak domowy","zwierzę","kot","pies","ryba","chomik","papuga","krowa","koń","kaczka","osioł","kurczak","świnia","owca"},
                                                     {"pet","animal","cat","dog","fish","hamster","parrot","cow","horse","duck","donkey","chicken","pig","sheep"},
                                                     {"la mascota","el animal","el gato","el perro","el pez","el hámster","el loro","la vaca","el caballo","el pato","el burro","la gallina","el cerdo","la oveja"} };

        private static string[,] animalsWild = {{"małpa","ptak","ślimak","motyl","mucha","lew","mysz","słoń","pszczoła","wilk","lis","królik","komar","żaba","tygrys"},
                                                 {"monkey","bird","snail","butterfly","fly","lion","mouse","elephant","bee","wolf","fox","rabbit","mosquito","frog","tiger"},
                                                 {"el mono","el pájaro","el caracol","la mariposa","la mosca","el león","el ratón","el elefante","la abeja","el lobo","el zorro","el conejo","el mosquito","la rana","el tigre"} };

        private static string[,] timeUnits = {{"czas","noc","rano","popołudnie","wieczór","pora roku","rok","miesiąc","tydzień","dzień","godzina","minuta","sekunda"},
                                               {"time","night","morning","afternoon","evening","season","year","month","week","day","hour","minute","second"},
                                               {"el tiempo","la noche","la mañana","la tarde","el atardecer","la estación","el año","el mes","la semana","el día","la hora","el minuto","el segundo"} };

        private static string[,] timeAdverbsPrepositions = {{"dzisiaj","wczoraj","jutro","następny","codziennie","nigdy","zawsze","zwykle","czasami","rzadko","ostatnio","podczas","od (czasu)","do (czasu)","temu","przed (czasem)","po (czasie)"},
                                                             {"today","yesterday","tomorrow","next","every day","never","always","usually","sometimes","rarely","recently","during","since","until","ago","before (time)","after (time)"},
                                                             {"hoy","ayer","mañana","siguiente","todos los días","nunca","siempre","normalmente","a veces","raramente","recientemente","durante","desde","hasta","hace","antes de","después de"} };

        private static string[,] timeCalendar = {{"poniedziałek","wtorek","środa","czwartek","piątek","sobota","niedziela","styczeń","luty","marzec","kwiecień","maj","czerwiec","lipiec","sierpień","wrzesień","październik","listopad","grudzień","wiosna","lato","jesień","zima"},
                                                  {"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday","January","February","March","April","May","June","July","August","September","October","November","December","spring","summer","autumn","winter"},
                                                  {"el lunes","el martes","el miércoles","el jueves","el viernes","el sábado","el domingo","enero","febrero","marzo","abril","mayo","junio","julio","agosto","septiembre","octubre","noviembre","diciembre","la primavera","el verano","el otoño","el invierno"} };

        private static string[,] familyCore = {{"rodzina","ojciec","matka","córka","syn","rodzic","mężczyzna","kobieta","mąż","żona","dziecko","brat","siostra","babcia","dziadek"},
                                                {"family","father","mother","daughter","son","parent","man","woman","husband","wife","child","brother","sister","grandmother","grandfather"},
                                                {"la familia","el padre","la madre","la hija","el hijo","el padre/la madre","el hombre","la mujer","el marido","la esposa","el niño","el hermano","la hermana","la abuela","el abuelo"} };

        private static string[,] familyRelationships = {{"wujek","ciocia","chłopiec","dziewczynka","kuzyn","chłopak (sympatia)","dziewczyna (sympatia)","rozwiedziony","żonaty/mężatka","ślub","być razem","wdowa","przyjaciel","urodzić się"},
                                                         {"uncle","aunt","boy","girl","cousin","boyfriend","girlfriend","divorced","married","wedding","be together","widow","friend","be born"},
                                                         {"el tío","la tía","el niño","la niña","el primo","el novio","la novia","divorciado","casado/casada","la boda","estar juntos","la viuda","el amigo","nacer"} };

        private static string[,] kitchen = {{"kroić","smażyć","gotować się (wrzeć)","mieszać","obierać","piec","dodawać","ważyć","siekać","podgrzewać","talerz","widelec","nóż","łyżka","łyżeczka","szklanka","kubek","filiżanka","serwetka","obrus"},
                                             {"cut","fry","boil","mix","peel","bake","add","weigh","chop","heat up","plate","fork","knife","spoon","teaspoon","glass","mug","cup","napkin","tablecloth"},
                                             {"cortar","freír","hervir","mezclar","pelar","hornear","añadir","pesar","picar","calentar","el plato","el tenedor","el cuchillo","la cuchara","la cucharilla","el vaso","la taza","la taza","la servilleta","el mantel"} };

        private static string[,] dailyRoutineChores = {{"spóźniać się","ścielić łóżko","czesać się","ścierać kurz","myć","budzić się","spać","śpieszyć się","sprzątać","zmywać naczynia","odkurzać","prasować","wieszać pranie","zamiatać","wynosić śmieci"},
                                                        {"be late","make the bed","comb","dust","wash","wake up","sleep","hurry","clean/tidy up","wash the dishes","vacuum","iron","hang out the laundry","sweep","take out the rubbish"},
                                                        {"llegar tarde","hacer la cama","peinarse","quitar el polvo","lavar","despertarse","dormir","darse prisa","limpiar","fregar los platos","pasar la aspiradora","planchar","tender la ropa","barrer","sacar la basura"} };

        private static string[,] homeFurniture = {{"lodówka","szafa","książka","regał","pralka","zlew","prysznic","wanna","stół","krzesło","łóżko","kanapa","dywan","lustro"},
                                                   {"fridge","wardrobe","book","bookshelf","washing machine","sink","shower","bathtub","table","chair","bed","sofa","carpet","mirror"},
                                                   {"la nevera","el armario","el libro","la estantería","la lavadora","el fregadero","la ducha","la bañera","la mesa","la silla","la cama","el sofá","la alfombra","el espejo"} };

        private static string[,] homeStructure = {{"klucz","pokój","salon","sypialnia","łazienka","kuchnia","okno","ściana","podłoga","parter","drzwi","sufit","otwierać","zamykać","garaż","piwnica","adres","dom","mieszkanie","zasłony"},
                                                   {"key","room","living room","bedroom","bathroom","kitchen","window","wall","floor","ground floor","door","ceiling","open","close","garage","cellar","address","house","flat","curtains"},
                                                   {"la llave","la habitación","el salón","el dormitorio","el baño","la cocina","la ventana","la pared","el suelo","la planta baja","la puerta","el techo","abrir","cerrar","el garaje","el sótano","la dirección","la casa","el piso","las cortinas"} };

        private static string[,] travel = {{"wycieczka","rower","prom","lotnisko","przystanek autobusowy","metro","bagaż","turysta","lot","jechać samochodem","wracać","autobus","pociąg","samochód","samolot","(po)wolny","szybki","skręcać","gubić"},
                                            {"trip","bike","ferry","airport","bus stop","underground","luggage","tourist","flight","drive","come back","bus","train","car","plane","slow","fast","turn","lose"},
                                            {"el viaje","la bicicleta","el ferry","el aeropuerto","la parada de autobús","el metro","el equipaje","el/la turista","el vuelo","conducir","volver","el autobús","el tren","el coche","el avión","lento","rápido","girar","perder"} };

        private static string[,] directionsTravel = {{"bilet","paszport","dworzec","iść","w lewo","w prawo","prosto","na rogu","przejście dla pieszych","skrzyżowanie","zakręt","róg (ulicy)","znak drogowy","chodnik"},
                                                      {"ticket","passport","station","go","left","right","straight ahead","on the corner","pedestrian crossing","crossroads","turn","corner (street)","road sign","pavement"},
                                                      {"el billete","el pasaporte","la estación","ir","a la izquierda","a la derecha","todo recto","en la esquina","el paso de peatones","el cruce","la curva","la esquina","la señal de tráfico","la acera"} };

        private static string[,] foodProduce = {{"jabłko","banan","pomidor","ziemniak","marchewka","cebula","czosnek","ogórek","śliwka","gruszka","brzoskwinia","pomarańcza","cytryna","truskawka","jagoda","malina","owoc","warzywo"},
                                                 {"apple","banana","tomato","potato","carrot","onion","garlic","cucumber","plum","pear","peach","orange","lemon","strawberry","berry","raspberry","fruit","vegetable"},
                                                 {"la manzana","el plátano","el tomate","la patata","la zanahoria","la cebolla","el ajo","el pepino","la ciruela","la pera","el melocotón","la naranja","el limón","la fresa","la baya","la frambuesa","la fruta","la verdura"} };

        private static string[,] foodMeals = {{"mięso","ryż","ryba","kurczak","makaron","chleb","jajko","mleko","sok","herbata","woda","kawa","śniadanie","obiad","kolacja","jeść","pić","ciasto","głodny","spragniony","sól","deser","ser żółty","masło","zupa","jedzenie","gotować"},
                                               {"meat","rice","fish","chicken","pasta","bread","egg","milk","juice","tea","water","coffee","breakfast","dinner","supper","eat","drink","cake","hungry","thirsty","salt","dessert","cheese","butter","soup","food","cook"},
                                               {"la carne","el arroz","el pescado","el pollo","la pasta","el pan","el huevo","la leche","el zumo","el té","el agua","el café","el desayuno","la comida","la cena","comer","beber","el pastel","hambriento","sediento","la sal","el postre","el queso","la mantequilla","la sopa","la comida","cocinar"} };

        private static string[,] speakBasics = {{"imię","nad","obok","pomiędzy","przed","ale","też","pod","w","na","za","i, oraz","do widzenia","dziękuję","Jak się masz?","dobry wieczór","dzień dobry (przed południem)","dzień dobry (po południu)","przepraszam (za coś)","przepraszam (z zapytaniem)","proszę (o coś)","ponieważ","dlatego","jeśli","chociaż","więc","żeby"},
                                                {"name","over","next to","between","in front of","but","too","under","in","on","behind","and","goodbye","thank you","How are you?","good evening","good morning","good afternoon","sorry","excuse me","please","because","therefore","if","although","so","in order to"},
                                                {"el nombre","encima de","al lado de","entre","delante de","pero","también","debajo de","en","en","detrás de","y","adiós","gracias","¿Cómo estás?","buenas noches","buenos días","buenas tardes","lo siento","perdón","por favor","porque","por eso","si","aunque","así que","para"} };

        private static string[,] pronounsBasics = {{"ja","ty (wy)","to","on","ona","my","oni (one)","tak","nie","mieć","dobry","cześć","zły","chcieć","brać","robić (np. ciasto, zupę)"},
                                                    {"I","you","it","he","she","we","they","yes","no","have","good","hello","bad","want","take","make"},
                                                    {"yo","tú (vosotros)","eso","él","ella","nosotros","ellos (ellas)","sí","no","tener","bueno","hola","malo","querer","tomar","hacer"} };

        private static string[,] questionsVerbs = {{"wspaniały","Ile? (policzalne)","Kto?","Co?","znać, wiedzieć","Gdzie?","Jak?","mówić, przemawiać","nie ma za co","Dlaczego?","mieszkać","być","robić (np. zakupy, ćwiczenie)","Ile? (niepoliczalne)","Kiedy?","dawać"},
                                                   {"great","How many?","Who?","What?","know","Where?","How?","speak","you are welcome","Why?","live","be","do","How much?","When?","give"},
                                                   {"genial","¿Cuántos?","¿Quién?","¿Qué?","saber","¿Dónde?","¿Cómo?","hablar","de nada","¿Por qué?","vivir","ser","hacer","¿Cuánto?","¿Cuándo?","dar"} };

        private static string[,] city = {{"ogród","droga","park","pole","stolica","ulica","gospodarstwo","plac","sąsiad","most","miasto","wioska","poczta","tereny wiejskie","kościół","biblioteka","muzeum","bank"},
                                          {"garden","road","park","field","capital","street","farm","square","neighbour","bridge","city","village","post office","countryside","church","library","museum","bank"},
                                          {"el jardín","el camino","el parque","el campo","la capital","la calle","la granja","la plaza","el vecino","el puente","la ciudad","el pueblo","la oficina de correos","el campo","la iglesia","la biblioteca","el museo","el banco"} };

        private static string[,] school = {{"egzamin","ocena","znaczyć","ołówek","książka","szkoła","uczeń","słowo","uczyć","uczyć się","rozumieć","język","matematyka","zdać","nie zdać","historia","geografia","przerwa","pisać","tablica","klasa","długopis","praca domowa","zeszyt","nauczyciel","uniwersytet","ćwiczenie"},
                                            {"exam","mark","mean","pencil","book","school","student","word","teach","learn","understand","language","maths","pass","fail","history","geography","break","write","blackboard","class","pen","homework","copybook","teacher","university","exercise"},
                                            {"el examen","la nota","significar","el lápiz","el libro","la escuela","el alumno","la palabra","enseñar","aprender","entender","el idioma","las matemáticas","aprobar","suspender","la historia","la geografía","el descanso","escribir","la pizarra","la clase","el bolígrafo","los deberes","el cuaderno","el profesor","la universidad","el ejercicio"} };

        private static string[,] appearance = {{"przystojny","stary","młody","ładny","elegancki","wysoki","niski","czysty","prosty","kręcony","brudny","piękny","brzydki","gruby","szczupły"},
                                                {"handsome","old","young","pretty","elegant","tall","short","clean","straight","curly","dirty","beautiful","ugly","fat","slim"},
                                                {"guapo","viejo","joven","bonito","elegante","alto","bajo","limpio","liso","rizado","sucio","hermoso","feo","gordo","delgado"} };

        private static string[,] nature = {{"przyroda","niebo","chmura","słońce","księżyc","jezioro","rzeka","morze","drzewo","liść","kwiat","roślina","trawa","las","góra","gorąco","ciepło","zimno","wiatr","pogoda","deszcz","śnieg","burza"},
                                            {"nature","sky","cloud","sun","moon","lake","river","sea","tree","leaf","flower","plant","grass","forest","mountain","hot","warm","cold","wind","weather","rain","snow","storm"},
                                            {"la naturaleza","el cielo","la nube","el sol","la luna","el lago","el río","el mar","el árbol","la hoja","la flor","la planta","la hierba","el bosque","la montaña","caliente","cálido","frío","el viento","el tiempo","la lluvia","la nieve","la tormenta"} };

        private static string[,] bodyBasic = {{"głowa","włosy","ucho","oko","nos","ząb","usta","twarz","szyja","ramię","brzuch","plecy","ręka","noga","kolano","stopa","palec u nogi","palec u ręki","broda"},
                                               {"head","hair","ear","eye","nose","tooth","lips","face","neck","arm","stomach","back","hand","leg","knee","foot","toe","finger","beard"},
                                               {"la cabeza","el pelo","la oreja","el ojo","la nariz","el diente","los labios","la cara","el cuello","el brazo","el estómago","la espalda","la mano","la pierna","la rodilla","el pie","el dedo del pie","el dedo","la barba"} };

        private static string[,] bodyDetailed = {{"czoło","brew","rzęsy","policzek","podbródek","łokieć","nadgarstek","ramię (bark)","biodro","udo","łydka","kostka","klatka piersiowa","skóra","paznokieć","język","gardło","serce","płuca","mięsień","kość"},
                                                  {"forehead","eyebrow","eyelashes","cheek","chin","elbow","wrist","shoulder","hip","thigh","calf","ankle","chest","skin","nail","tongue","throat","heart","lungs","muscle","bone"},
                                                  {"la frente","la ceja","las pestañas","la mejilla","la barbilla","el codo","la muñeca","el hombro","la cadera","el muslo","la pantorrilla","el tobillo","el pecho","la piel","la uña","la lengua","la garganta","el corazón","los pulmones","el músculo","el hueso"} };

        private static string[,] clothesMaterials = {{"kurtka","skarpetka","pasek","okulary","szalik","rękawiczka","but","spodnie","parasol","koszulka","sukienka","czapka","kapelusz","spódnica","koszula","płaszcz","przymierzać","rozmiar","drewno","metal","plastik","szkło","bawełna","wełna","skóra"},
                                                      {"jacket","sock","belt","glasses","scarf","glove","shoe","trousers","umbrella","T-shirt","dress","cap","hat","skirt","shirt","coat","try on","size","wood","metal","plastic","glass","cotton","wool","leather"},
                                                      {"la chaqueta","el calcetín","el cinturón","las gafas","la bufanda","el guante","el zapato","los pantalones","el paraguas","la camiseta","el vestido","la gorra","el sombrero","la falda","la camisa","el abrigo","probarse","la talla","la madera","el metal","el plástico","el vidrio","el algodón","la lana","el cuero"} };

        private static string[,] countries = {{"Wielka Brytania (Zjednoczone Królestwo)","Japończyk, japoński","Japonia","Rosjanin, rosyjski","Rosja","Kanadyjczyk, kanadyjski","Kanada","Amerykanin, amerykański","Stany Zjednoczone Ameryki","Australijczyk, australijski","Australia","Grek, grecki","Niemiec, niemiecki","Niemcy","Francuz, francuski","Francja","Hiszpan, hiszpański","Hiszpania","Włoch, włoski","Włochy","Polak, polski","Polska","Europa","Azja","narodowość","kraj"},
                                              {"United Kingdom","Japanese","Japan","Russian","Russia","Canadian","Canada","American","United States of America","Australian","Australia","Greek","German","Germany","French","France","Spanish","Spain","Italian","Italy","Polish","Poland","Europe","Asia","nationality","country"},
                                              {"el Reino Unido","japonés","Japón","ruso","Rusia","canadiense","Canadá","estadounidense","los Estados Unidos de América","australiano","Australia","griego","alemán","Alemania","francés","Francia","español","España","italiano","Italia","polaco","Polonia","Europa","Asia","la nacionalidad","el país"} };

        private static string[,] leisureHolidays = {{"relaksować się","śpiewać","pływać","przyjęcie, impreza","bawić się","zainteresowania","robić zdjęcia","wakacje","malować","słuchać","czytać","kino","teatr","koncert","oglądać","uprawiać sporty","biegać","tańczyć","plaża","piasek","fala","kąpiel słoneczna","krem do opalania","opalać się","zamek z piasku"},
                                                     {"relax","sing","swim","party","play","hobbies","take photos","holiday","paint","listen","read","cinema","theatre","concert","watch","do sports","run","dance","beach","sand","wave","sunbathing","sunscreen","to sunbathe","sandcastle"},
                                                     {"relajarse","cantar","nadar","la fiesta","jugar","los intereses","hacer fotos","las vacaciones","pintar","escuchar","leer","el cine","el teatro","el concierto","ver","hacer deporte","correr","bailar","la playa","la arena","la ola","el baño de sol","la crema solar","tomar el sol","el castillo de arena"} };

        private static string[,] sportsMusic = {{"piłka nożna","koszykówka","tenis","pływanie","siatkówka","narciarstwo","jazda konna","gitara","pianino","skrzypce","grać na (instrumencie)","mecz","drużyna","trener"},
                                                 {"football","basketball","tennis","swimming","volleyball","skiing","horse riding","guitar","piano","violin","play (an instrument)","match","team","coach"},
                                                 {"el fútbol","el baloncesto","el tenis","la natación","el voleibol","el esquí","la equitación","la guitarra","el piano","el violín","tocar (un instrumento)","el partido","el equipo","el entrenador"} };

        private static string[,] technologyMedia = {{"internet","hasło","konto","aplikacja","wiadomość","e-mail","link","ładować (telefon)","wifi","strona internetowa","przeglądarka","klikać","logować się","wylogowywać się","pobierać","wysyłać","media społecznościowe","aktualizować","telewizja","radio","gazeta","wiadomości (news)","reklama","program (telewizyjny)"},
                                                     {"internet","password","account","app","message","email","link","charge (phone)","wifi","website","browser","click","log in","log out","download","send","social media","update","television","radio","newspaper","news","advertisement","TV programme"},
                                                     {"el internet","la contraseña","la cuenta","la aplicación","el mensaje","el correo electrónico","el enlace","cargar (el teléfono)","el wifi","el sitio web","el navegador","hacer clic","iniciar sesión","cerrar sesión","descargar","enviar","las redes sociales","actualizar","la televisión","la radio","el periódico","las noticias","el anuncio","el programa"} };

        private static string[,] feelings = {{"zmęczony","bać się","płakać","śmiać się","uśmiechać się","zdenerwowany","senny","zły (na kogoś)","smutny","szczęśliwy","nienawidzić","kochać","lubić","dumny","nudny","zaskakiwać","uczucie","myśleć","martwić się","rozczarowany","zaskoczony","zestresowany","zrelaksowany","zazdrosny"},
                                             {"tired","be scared","cry","laugh","smile","nervous","sleepy","angry","sad","happy","hate","love","like","proud","boring","surprise","feeling","think","worry","disappointed","surprised","stressed","relaxed","jealous"},
                                             {"cansado","tener miedo","llorar","reír","sonreír","nervioso","tener sueño","enfadado","triste","feliz","odiar","amar","gustar","orgulloso","aburrido","sorprender","el sentimiento","pensar","preocuparse","decepcionado","sorprendido","estresado","relajado","celoso"} };

        private static string[,] shopping = {{"portfel","centrum handlowe","księgarnia","piekarnia","drogi","tani","płacić","bankomat","sklep","sprzedawać","pieniądze","targ","cena","koszyk","półka","reszta","kupować","zakupy"},
                                              {"wallet","shopping center","bookshop","bakery","expensive","cheap","pay","cashpoint","shop","sell","money","market","price","basket","shelf","change","buy","shopping"},
                                              {"la cartera","el centro comercial","la librería","la panadería","caro","barato","pagar","el cajero automático","la tienda","vender","el dinero","el mercado","el precio","la cesta","la estantería","el cambio","comprar","las compras"} };

        private static string[,] moneyDining = {{"zamawiać","rachunek","kelner","menu","napiwek","stolik (rezerwacja)","rezerwacja","danie","przystawka","danie główne","konto bankowe","przelew","oszczędzać","pożyczać","rachunek (do zapłacenia)","gotówka","karta kredytowa","karta debetowa","oprocentowanie","kredyt","zadłużenie","wydawać (pieniądze)","budżet","waluta"},
                                                 {"order","bill","waiter","menu","tip","table (reservation)","reservation","dish","starter","main course","bank account","transfer","save (money)","borrow","bill (to pay)","cash","credit card","debit card","interest rate","loan","debt","spend (money)","budget","currency"},
                                                 {"pedir","la cuenta","el camarero","el menú","la propina","la mesa (reserva)","la reserva","el plato","el entrante","el plato principal","la cuenta bancaria","la transferencia","ahorrar","pedir prestado","la factura","el efectivo","la tarjeta de crédito","la tarjeta de débito","el tipo de interés","el préstamo","la deuda","gastar","el presupuesto","la moneda"} };

        private static string[,] professions = {{"muzyk","malarz","naukowiec","policjant","strażak","pielęgniarka","architekt","sekretarka","mechanik","informatyk","programista","inżynier","aktor","artysta","lekarz","dziennikarz","sprzedawca","fryzjer","prawnik"},
                                                 {"musician","painter","scientist","police officer","fireman","nurse","architect","secretary","mechanic","IT specialist","computer programmer","engineer","actor","artist","doctor","journalist","shop assistant","hairdresser","lawyer"},
                                                 {"el músico","el pintor","el científico","el policía","el bombero","la enfermera","el arquitecto","la secretaria","el mecánico","el informático","el programador","el ingeniero","el actor","el artista","el médico","el periodista","el vendedor","el peluquero","el abogado"} };

        private static string[,] officeComputer = {{"dzwonić","kopiować","ekran","plik, dokument","klawiatura","telefon komórkowy","drukować","zapisywać","włączać","wyłączać","praca","biuro","komputer","szef","CV","rozmowa kwalifikacyjna","umowa o pracę","pensja","urlop","zwolnienie (z pracy)","awans","doświadczenie (zawodowe)"},
                                                    {"phone","copy","screen","file","keyboard","mobile phone","print","save","turn on","turn off","work","office","computer","boss","CV","job interview","employment contract","salary","holiday leave","dismissal","promotion","experience"},
                                                    {"llamar","copiar","la pantalla","el archivo","el teclado","el móvil","imprimir","guardar","encender","apagar","el trabajo","la oficina","el ordenador","el jefe","el currículum","la entrevista de trabajo","el contrato de trabajo","el salario","las vacaciones","el despido","el ascenso","la experiencia"} };

        private static string[,] character = {{"arogancki","radosny","nieśmiały","szalony","uparty","inteligentny","spokojny","towarzyski","odważny","miły","sympatyczny","uczciwy","mądry","cierpliwy","samolubny"},
                                               {"rude","cheerful","shy","crazy","stubborn","intelligent","calm","outgoing","brave","nice","friendly","honest","clever","patient","selfish"},
                                               {"arrogante","alegre","tímido","loco","testarudo","inteligente","tranquilo","sociable","valiente","amable","simpático","honesto","listo","paciente","egoísta"} };

        private static string[,] health = {{"pigułka, tabletka","choroba","chory","zdrowy","lekarstwo","karetka","apteka","łamać","kaszel","przeziębić się","grypa","gorączka","umawiać się (na wizytę)","ból","boleć","ból głowy","ból gardła","czuć się","szpital"},
                                            {"pill","illness","sick","healthy","medicine","ambulance","pharmacy","break","cough","catch a cold","flu","fever","make an appointment","pain","hurt","headache","sore throat","feel","hospital"},
                                            {"la pastilla","la enfermedad","enfermo","sano","el medicamento","la ambulancia","la farmacia","romper","la tos","resfriarse","la gripe","la fiebre","pedir cita","el dolor","doler","el dolor de cabeza","el dolor de garganta","sentirse","el hospital"} };

        private static string[,] emergencies = {{"Pomocy!","pożar","niebezpieczeństwo","wzywać (pomoc/policję)","alarm","wypadek","policja","straż pożarna","ratować","uciekać","ostrożnie!","zagrożenie"},
                                                 {"Help!","fire","danger","call (for help/police)","alarm","accident","police","fire brigade","save/rescue","escape","careful!","threat"},
                                                 {"¡Socorro!","el incendio","el peligro","llamar (a la policía)","la alarma","el accidente","la policía","los bomberos","salvar","escapar","¡cuidado!","la amenaza"} };

        private static string[,] celebrations = {{"Boże Narodzenie","Wielkanoc","urodziny","prezent","świętować","życzenia","choinka","fajerwerki","Nowy Rok","imieniny","gratulacje","zapraszać","gość","tort urodzinowy"},
                                                  {"Christmas","Easter","birthday","present","celebrate","wishes","Christmas tree","fireworks","New Year","name day","congratulations","invite","guest","birthday cake"},
                                                  {"la Navidad","la Pascua","el cumpleaños","el regalo","celebrar","los deseos","el árbol de Navidad","los fuegos artificiales","el Año Nuevo","el santo","las felicidades","invitar","el invitado","la tarta de cumpleaños"} };

        private static string[,] verbsActions = {{"potrzebować","szukać","znajdować","pomagać","zaczynać","kończyć","kontynuować","przestawać","pamiętać","zapominać","próbować","wyjaśniać","pytać","odpowiadać","wybierać","decydować się","obiecywać","mieć nadzieję"},
                                                  {"need","look for","find","help","start","finish","continue","stop","remember","forget","try","explain","ask","answer","choose","decide","promise","hope"},
                                                  {"necesitar","buscar","encontrar","ayudar","empezar","terminar","continuar","parar","recordar","olvidar","intentar","explicar","preguntar","responder","elegir","decidir","prometer","esperar"} };

        private static string[][,] kategorie = { numbersBasic, numbersAdvanced, descriptiveAdjectives, viewsComparisons, colors, animalsDomestic, animalsWild,
            timeUnits, timeAdverbsPrepositions, timeCalendar, familyCore, familyRelationships, kitchen, dailyRoutineChores, homeFurniture, homeStructure,
            travel, directionsTravel, foodProduce, foodMeals, speakBasics, pronounsBasics, questionsVerbs, city, school, appearance, nature,
            bodyBasic, bodyDetailed, clothesMaterials, countries, leisureHolidays, sportsMusic, technologyMedia, feelings, shopping, moneyDining,
            professions, officeComputer, character, health, emergencies, celebrations, verbsActions };
    }
}