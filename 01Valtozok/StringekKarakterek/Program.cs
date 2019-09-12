using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringekKarakterek
{
    class Program
    {
        static void Main(string[] args)
        {
            String szoveg = "Valami szöveg...";

            //String hossza
            Console.WriteLine(szoveg.Length);
            Console.WriteLine(szoveg[0]);
            //Ezzel kezdődik?
            Console.WriteLine(szoveg.StartsWith("Val"));

            //Írásmód változtatása
            Console.WriteLine(szoveg.ToLower());
            Console.WriteLine(szoveg.ToUpper());

            //szövegrész kiemelése
            Console.WriteLine(szoveg.Substring(1,4));

            string datum = "2019-09-12";

            //Feladat: hozzunk létre ev,honap,nap változókat,
            //a datumbol mindegyikbe a megfelelő érték kerüljön

            var ev = datum.Substring(0, 4);
            var honap = datum.Substring(5, 2);
            var nap = datum.Substring(8, 2);

            Console.WriteLine();

            Console.WriteLine($"Ev:{ev},Honap:{honap},Nap:{nap}");

            //Karakter típus
            Char karakter = 'a';

            if (Char.IsLower(karakter))
            {
                karakter = char.ToUpper(karakter);
            }
            Console.WriteLine(karakter);

            //A szöveg hossza:16, az indexek 0-15 közöttiek
            szoveg = "VaLaMI sZÖveG";
            char[] szovegCh = szoveg.ToCharArray();
            //Így is lehetett volna
            //var szovegCh = szoveg.ToCharArray();

            for (int i = 0; i < szovegCh.Length; i++)
            {
                if (Char.IsLower(szovegCh[i]))
                {
                    szovegCh[i] = char.ToUpper(szovegCh[i]);
                } else
                    szovegCh[i] = char.ToLower(szovegCh[i]);
                {

                }
               
            }

            var szoveg2 = new string(szovegCh);
            Console.WriteLine(szoveg);
            Console.WriteLine(szoveg2);

            //írjunk programot ami megadja egy string-ben
            //előforduló számjegyek összegét

            var numbers = "Ebben a 49 szövegben 126 számok vannak 441".ToCharArray();
            var osszeg = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (char.IsDigit(numbers[i]))
                {
                    //A GetNumericValue() double típussal tér vissza,
                    //amit a (int)Char.GetNumericValue(numbers[i]) 
                    //paranccsal kényszerítünk int típusra 
                    //ez a típuskényszerítés (cast-olás)
                    osszeg = osszeg + (int)Char.GetNumericValue(numbers[i]);
                }
            }

            Console.WriteLine(osszeg);


            Console.ReadKey();
        }
    }
}
