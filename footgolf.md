
# Footgolf feladat megoldása

Kiindulási állpotunk az üres konzolos projekt. A feladatot először végig kell olvasni alaposan, hogy lássuk milyen adatszerkezetekre, függvényekre lesz majd szükség. 

A megoldás rendszerüzemeltető hallgatók részére készült, a benne lévő megoldások az elérhető legtöbb pontszámot célozzák adott idő alatt. 

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootGolf
{
    class Program
    {        
        //ide kerül a Versenyzo osztály

        //ide kerül  a pontszámot meghatározó függvény
        
        static void Main(string[] args)
        {
            //lista létrehozása az adatoknak
            //fájl betöltés
            //adatok visszakeresése
            //fájl kiírás
            //statisztika


            Console.ReadKey();
        }
        
        //ide is kerülhet az osztály
    }
}

```
Szükség lesz egy adatszerkezetre, amely a versenyző adatait kezeli. Erre a célra használhatunk struktúrát, vagy osztály. A korábbi megoldásokban túlnyomórészt a struktúrák szerepeltek, ezért most osztályt használunk. Ezt a legtöbb esetben külön fájlba illik tenni, de most a főprogramot is tartalmazó fájlba tesszük (inner class-nak is szokták hívni). A felső kódrészletben megjelöltem, hogy hová kerüljön az osztály. Mehetne a főprogram alá is, a lényeg, hogy a főprogramon **kívül** legyen. 

```C#
 public class Versenyzo
        {
            public string nev;
            public string kategoria;
            public string egyesulet;
            public int[] pontok;

            public Versenyzo(string sor)
            {
                var e = sor.Split(';');
                nev = e[0];
                kategoria = e[1];
                egyesulet = e[2];
                pontok = new int[8];

                for (int i = 3; i < e.Length; i++)
                {
                    pontok[i - 3] = Convert.ToInt16(e[i]);
                }
            }           
        }
```
Az osztályunk feladata, hogy a beérkező adatokat feldolgozza és tárolja. A bejövő adat a fájlból beolvasott sor, amit a határoló karakter mentén feldarabolunk, majd az adatmezőkbe teszünk. Különlegesség más feladatokhoz képest, hogy itt van 8 adat, amelyek a versenyző által elért pontokat jelentik, ezeket egy tömbbe tesszük. Az osztály konstruktora gondoskodik az adatok feldolgozásáról.
A **nev,kategoria,egyesulet** adatok egyszerű stringek, a **pontok** értékei kerülnek a tömbbe. Ezt **for** ciklussal érdemes. Felmerülhet a kérdés, hogy lehet-e egyenként is? Lehet, de plusz munka, plusz hibalehetőség, és mi van, ha 2639 adat van? Szóval jobb a **for**.

Ha kész az osztály, akkor irány a főprogram! Először létre kell hozni egy listát az adatok tárolására. A lista elemtípusa a **Versenyzo**, tehát a lista ezen osztály példányait fogja tárolni.

```C#
List<Versenyzo> versenyzok = new List<Versenyzo>();
```

Ezt követően a szokásos szerkezetben betöltjük a fájlt és feldolgozzuk az adatait, feltöltjük a listát. Jelen esetben a szöveges fájlban nincsenek oszlopnevek, ezért az első sort is feldolgozzuk.

```C#
try
{
    var sorok = File.ReadAllLines(@"fob2016.txt",Encoding.Default);

         for (int i = 0; i < sorok.Length; i++)
         {
             versenyzok.Add(new Versenyzo(sorok[i]));
         }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

A fájl feltöltéséhez a **File.ReadAllLines** metódust használjuk. Így nem kell FileStream, ill, StreamReader  osztályokat létrehozni, a **ReadAllLines** megnyit, olvas, bezár, eltakarít maga után.

Ezen a ponton kész a **versenyzok** listánk, fel van töltve adatokkal, kezdődhet a feladat kérdéseinek megválaszolása.

Feladat 3:
Határozza meg és írja ki a képernyőre a minta szerint, hogy hány versenyző indult összesen a két kategóriában a bajnokságon!

Egyszerű, annyi versenyző indult, ahány elem van a listán, azaz a lista elemszáma adja meg a választ.

```C#
Console.WriteLine($"3.Feladat:, Összesen induló versenyzők száma:{versenyzok.Count}");
```

Feladat 4:
Határozza meg és írja ki a képernyőre a minta szerint a női versenyzők arányát az összes versenyzőszámhoz  képest!  A  százalékos  értéket  két  tizedesjegy  pontossággal  jelenítse meg!

Itt már érdemes a LINQ segítségét igénybe venni, hiszen időt és munkát lehet így megtakarítani. 
Először meg kell határozni a női versenyzők számát. A FindAll kigyűjti a megfelelő elemeket egy új listába, és annak még az elemszámát vesszük. Mivel szövegeket hasonlítunk össze, érdemes kisbetűsre (vagy nagybetűsre) alakítani mindkettőt az összehasonlítás előtt.

```C#
var noiVersenyzokSzama = versenyzok.FindAll(x => x.kategoria.ToLower() == "noi".ToLower()).Count;
```
Ezt követően tudjuk meghatározni az arányt. Ezt már be lehet csomagolni a kiíró utasításba. Az eredményt Double típusra kell castolni, és két tizedessel százalékos formában megjeleníteni, ezért a **:0.00%**.

```C#
Console.WriteLine($"4.feladat:{(Double)noiVersenyzokSzama / versenyzok.Count:0.00%}");
```
Feladat 5:
Készítsen függvényt vagy jellemzőt, amivel meghatározza egy versenyzőnek a bajnokságban (8 fordulóban) elért egyéni összpontszámát!
Az összpontszám számítását a következő szabályok alapján végezze: 

 - A versenyző legrosszabb két eredménye kiesik az összpontszámból. A maradék hat pontszámot össze kell adni. 
 - Ha  a  versenyző  legrosszabb  egy  vagy  két  eredménye  nem  nulla,  akkor  a versenyzőnek  az  összpontszámába  bele  kell  számítani  azt  a  10  pont  bónuszt, amelyet ezekben a fordulókban megkapott. Például: „50;50;20;50;30;50;50;50” pontok esetén a „20” és a „30” pont kiesik, de mivel a kieső pontszámok nem nullák, ezért az indulásért járó 10-10 pont bónuszt megkapja, így összpontszáma: 6 × 50 + 10 +10 = 320. 
 
 A függvényt a megfelelő helyre kell tenni!! Miért is statikus?  Ez egyébként nem a legszebb megoldás, sokkal jobb lett volna az osztályba írni egy metódust, ami visszatér az összpontszámmal. Házi feladat ennek megvalósítása!

```C#
public static int Osszpontszam(int[] pontok)
{
    var osszpont = 0;
    Array.Sort(pontok);

    for (int i = 0; i < pontok.Length-2; i++)
       {
           osszpont += pontok[i];
        }
    
    if (pontok[pontok.Length-2]!=0)
        {
            osszpont += 10;
        }
    if (pontok[pontok.Length - 1] != 0)
        {
            osszpont += 10;
        }

            return osszpont;
}
```

Feladat 6:
Határozza meg és  írja ki a  minta szerint  a 2016-os footgolf  bajnokság legtöbb  pontot szerzett női bajnokát! Feltételezheti, hogy legalább egy női induló volt a bajnokságon, és nem alakult ki holtverseny.

Figyelem, a főprogramban folytatjuk!
A feladatot lefordítva: keressük a legtöbb pontot szerzett női játékost. Megint tud segíteni a LINQ. Mivel itt egyetlen előfordulást keresünk, a Find-ot használjuk (milyen mellékhatása lehet, ha a Find nem talál semmit?)

```C#
var noiBajnok = versenyzok.Find(x => x.kategoria.ToLower() == "noi".ToLower() && Osszpontszam(x.pontok) == versenyzok.Max(y => Osszpontszam(y.pontok)));

Console.WriteLine($"6. feladat: A bajnok női versenyző:{noiBajnok.nev},{Osszpontszam(noiBajnok.pontok)}");
```

Feladat 7.
Készítsen  szöveges  állományt osszpontFF.txt  néven,  amelybe  kiírja  a  felnőtt  férfi kategóriában indult versenyzők nevét és a bajnokságban elért összpontszámát! A sorokban az adatokat pontosvesszővel válassza el egymástól a minta szerint! 

Szűrünk, majd a kiszűrt adatokat fájlba írjuk. Itt a legjobb a **FileStream, StreamWriter** osztályokat használni. 
Nagyon fontos, hogy ha kimarad a fájl lezárása (**Close()**), akkor egy sérült fájl lesz az eredmény!!

```C#
try
{
    FileStream fajl = new FileStream(@"osszpontFF.txt", FileMode.Create);
    StreamWriter writer = new StreamWriter(fajl, Encoding.Default);
    var ferfiVersenyzok = versenyzok.FindAll(x => x.kategoria.ToLower() == "Felnott ferfi".ToLower());

            foreach (var i in ferfiVersenyzok)
            {
                writer.WriteLine($"{i.nev};{Osszpontszam(i.pontok)}");
            }
    
    writer.Close();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
Egy jobb megoldás, ha a StreamWriter-t **using** blokkban használjuk, ebben az esetben nem kell a kézzel elvégzett lezárás, a **using** blokk gondoskodik a lezárásról.

```C#
try
{
    FileStream fajl = new FileStream(@"osszpontFF.txt", FileMode.Create);
    using (StreamWriter writer = new StreamWriter(fajl, Encoding.Default)) { 
        
          var ferfiVersenyzok = versenyzok.FindAll(x => x.kategoria.ToLower() == "Felnott ferfi".ToLower());

          foreach (var i in ferfiVersenyzok)
            {
                writer.WriteLine($"{i.nev};{Osszpontszam(i.pontok)}");
            }
     }

     }
       catch (Exception ex)
     {

     Console.WriteLine(ex.Message);
}
```
