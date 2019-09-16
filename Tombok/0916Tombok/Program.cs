using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0916Tombok
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tömb: azonos típusú adatokat tartalmazó adatszerkezet
            //Deklarálás
            int[] szamok = new int[100];

            Random rand = new Random();

            //deklarálás az elemek megadásával
            int[] masikSzamok = {1,2,3,4,5};
            //masikSzamok[0] -> 1

            //deklarálás a var kulcsszóval
            var szamTomb = new int[10];

            //tömb elemeinek kiíratása
            for (int i = 0; i < masikSzamok.Length; i++)
            {
                Console.WriteLine(masikSzamok[i]);
            }

            //tömb elemeinek kiíratása while ciklussal

            var n = 0;
            while (n<masikSzamok.Length)
            {
                Console.WriteLine(masikSzamok[n]);
                n++;
            }
            //foreach ciklus,ebben nem lehet módosítani
            foreach (var i in masikSzamok)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rand.Next(-100, 101);
            }

            //összeg gyűjtése
            var osszeg = 0;

            for (int i = 0; i < szamok.Length; i++)
            {
                osszeg = osszeg + szamok[i];
                //osszeg+=szamok[i];
            }

            //min,max kiválasztás
            var min = Int32.MaxValue;
            var max = Int32.MinValue;

            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i]<min)
                {
                    min = szamok[i];
                }
                if (szamok[i]>max)
                {
                    max = szamok[i];
                }
            }
            //

            var szamDb = 0;

            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i]==49)
                {
                    szamDb++;
                }
            }

            //lineáris keresés
            var keresett = 99;
            bool megvan = false;

            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i]==keresett)
                {
                    Console.WriteLine($"Megvan! indexe:{i}");
                    megvan = true;
                    break;
                } 
            }
            if (!megvan)
            {
                Console.WriteLine($"A keresett elem {keresett} nincs a tömbben!");
            }


            Console.WriteLine(osszeg);
            Console.WriteLine($"Min:{min},Max:{max}");
            Console.WriteLine($"55 darabszáma:{szamDb}");


            //A vizsgán

            Console.WriteLine($"Összeg:{szamok.Sum()},Min:{szamok.Min()},Max:{szamok.Max()}");

            Console.WriteLine(szamok.Contains(keresett));

            Console.WriteLine(szamok.Count(x=>x>0));

            Console.ReadKey();
            
        }
    }
}
