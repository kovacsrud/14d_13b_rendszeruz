
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
        

        static void Main(string[] args)
        {
     


            Console.ReadKey();
        }
    }
}

```
Szükség lesz egy adatszerkezetre, amely a versenyző adatait kezeli. Erre a célra használhatunk struktúrát, vagy osztály. A korábbi megoldásokban túlnyomórészt a struktúrák szerepeltek, ezért most osztályt használunk. Ezt a legtöbb esetben külön fájlba illik tenni, de most a főprogramot is tartalmazó fájlba tesszük (inner class-nak is szokták hívni).

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
