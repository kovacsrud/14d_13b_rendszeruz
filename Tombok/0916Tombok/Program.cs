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

            Console.WriteLine(osszeg);
            

            Console.ReadKey();
            
        }
    }
}
