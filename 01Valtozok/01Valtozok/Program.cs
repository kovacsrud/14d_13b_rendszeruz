using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Valtozok
{
    class Program
    {
        static void Main(string[] args)
        {
            //Szöveg
            string szoveg = "Valami szöveg";
            //karakter
            char karakter = 'g';
            //egész számok
            int szam = 345;
            short masikSzam = 235;
            byte bajt = 221;
            //logikai
            bool logikai = false;

            //lebegőpontos számok
            float egyszeres = 15.6634249364646463462f;
            double ketszeres = 15.6634249364646463462;
            decimal dec = 15.6634249364646463462m;

            Console.WriteLine(egyszeres);
            Console.WriteLine(ketszeres);
            Console.WriteLine(dec);


            Console.ReadKey();

        }
    }
}
