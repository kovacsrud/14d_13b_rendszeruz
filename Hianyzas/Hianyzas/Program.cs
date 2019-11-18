using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hianyzas
{
    class Program
    {
        struct Hianyzas
        {
            public string nev;
            public string osztaly;
            public int elsoNap;
            public int utolsoNap;
            public int mulasztottOrak;

            public Hianyzas(string adatsor)
            {
                var e = adatsor.Split(';');
                nev = e[0];
                osztaly = e[1];
                elsoNap = Convert.ToInt32(e[2]);
                utolsoNap = Convert.ToInt32(e[3]);
                mulasztottOrak = Convert.ToInt32(e[4]);
            }
        }
        static void Main(string[] args)
        {
            List<Hianyzas> hianyzasok = new List<Hianyzas>();

            try
            {
                var sorok = File.ReadAllLines(@"c:/ftproot/Hianyzasok/szeptember.csv",Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    Hianyzas hianyzas = new Hianyzas(sorok[i]);
                    hianyzasok.Add(hianyzas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"1.feladat:{hianyzasok.Count} db adat van.");

            Console.WriteLine($"2.feladat, összes mulasztás:{hianyzasok.Sum(x=>x.mulasztottOrak)}");

            Console.Write("Adjon meg egy napot:");
            var nap = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adjon meg egy tanuló nevét:");
            var nev = Console.ReadLine();

            var hianyzotte = hianyzasok.FindAll(x=>x.nev==nev && nap>=x.elsoNap && nap<=x.utolsoNap);

            if (hianyzotte.Count>0)
            {
                Console.WriteLine("Hiányzott");
            } else
            {
                Console.WriteLine("Nem hiányzott");
            }



            Console.ReadKey();
        }
    }
}
