using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stadion
{
    class Program
    {
        public struct StadionAdat
        {
            public string varos;
            public string nev1;
            public string nev2;
            public int ferohely;

            public StadionAdat(string sor)
            {
                var e = sor.Split(';');
                varos = e[0];
                nev1 = e[1];
                nev2 = e[2];
                ferohely = Convert.ToInt32(e[3]);
            }
                        

        }
        static void Main(string[] args)
        {
            StadionAdat stadion = new StadionAdat();
            List<StadionAdat> stadionok = new List<StadionAdat>();

            try
            {
                var sorok = File.ReadAllLines(@"vb2018.txt",Encoding.Default);

                for (int i = 1; i < sorok.Length; i++)
                {
                    stadionok.Add(new StadionAdat(sorok[i]));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }



            Console.WriteLine($"Feladat 3. :{stadionok.Count}");

            var legkevesebb = stadionok.Find(x=>x.ferohely==stadionok.Min(y=>y.ferohely));

            Console.WriteLine($"Feladat 4:{legkevesebb.varos},{legkevesebb.nev1},{legkevesebb.nev2},{legkevesebb.ferohely}");

            var fatlag = stadionok.Average(x=>x.ferohely);
            Console.WriteLine($"Feladat 5: {fatlag:0.0}");

            var nincsalternativ = stadionok.FindAll(x=>x.nev2!="n.a.").Count;

            Console.WriteLine($"Feladat 6: {nincsalternativ}");

            Console.Write("Adjon meg egy város nevet:");
            var varos = Console.ReadLine();
            while (varos.Length<3)
            {
                Console.Write("Rossz, ismét:");
                varos = Console.ReadLine();
            }

            if (stadionok.Any(x=>x.varos.ToLower()==varos.ToLower()))
            {
                Console.WriteLine($"{varos} városban zajlottak mérkőzések!");
            } else
            {
                Console.WriteLine($"{varos} városban nem zajlottak mérkőzések!");
            }

            var kulonbozoHelyszinek = stadionok.ToLookup(x => x.varos).Count;

            Console.WriteLine($"Feladat 9: {kulonbozoHelyszinek}");

            Console.ReadKey();
        }
    }
}
