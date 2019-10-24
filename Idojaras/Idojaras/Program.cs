using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idojaras
{
    class Program
    {
        struct IdoJarasAdat
        {
            public int ev;
            public int honap;
            public int nap;
            public int ora;
            public double homerseklet;
            public double szelsebesseg;
            public double paratartalom;

            //Írunk egy konstruktort az adatok feldolgozására
            //itt nincs void, és visszatérési érték sem
            public IdoJarasAdat(string sor)
            {
                var e = sor.Split(';');
                ev = Convert.ToInt32(e[0]);
                honap = Convert.ToInt32(e[1]);
                nap = Convert.ToInt32(e[2]);
                ora = Convert.ToInt32(e[3]);
                homerseklet = Convert.ToDouble(e[4]);
                szelsebesseg = Convert.ToDouble(e[5]);
                paratartalom = Convert.ToDouble(e[6]);

            }

        }

        static void Main(string[] args)
        {
            List<IdoJarasAdat> idojarasAdatok = new List<IdoJarasAdat>();

            try
            {
                //beolvassuk a fájl összes sorát egy string tömbbe
                var sorok = File.ReadAllLines(@"d:/rud/idojaras.csv",Encoding.Default);
                
                //Ha az első sor oszlopneveket tartalmat, akkor azt 
                //nem kell feldolgozni, ilyenkor a for ne 0-ról, hanem 1-től
                //induljon
                for (int i = 1; i < sorok.Length; i++)
                {
                    idojarasAdatok.Add(new IdoJarasAdat(sorok[i]));
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Adatok száma:{idojarasAdatok.Count}");

            //Kérjünk be egy évet,  egy hónapot, egy napot, és listázzuk ki
            //az adott nap adatait

            var ev = Convert.ToInt32(Console.ReadLine());
            var honap = Convert.ToInt32(Console.ReadLine());
            var nap = Convert.ToInt32(Console.ReadLine());

            var lekerdezettNapok = idojarasAdatok.FindAll(x=>x.ev==ev && x.honap==honap && x.nap==nap);

            Console.WriteLine($"Ennyi adat van:{lekerdezettNapok.Count}");

            foreach (var l in lekerdezettNapok)
            {
                Console.WriteLine($"{l.ev},{l.honap},{l.nap},{l.ora},{l.homerseklet},{l.szelsebesseg},{l.paratartalom}");
            }

            //Mekkora volt a min/max hőmérséklet az adott napon?
            var min = lekerdezettNapok.Min(x=>x.homerseklet);
            Console.WriteLine($"A legalacsonyabb hőmérséklet:{min:0.00}");

            var max = lekerdezettNapok.Max(x => x.homerseklet);
            Console.WriteLine($"A legmagasabb hőmérséklet:{max:0.00}");

            var atlagho = lekerdezettNapok.Average(x=>x.homerseklet);
            Console.WriteLine($"Az átlagos hőmérséklet:{atlagho:0.00}");
            
            //Mekkora volt a délutáni átlaghőmérséklet?
            //Ebben az esetben előszök ki kell szűrni a megfelelő
            //adatokat, majd jöhet az átlag (min, max stb)
            var du = lekerdezettNapok.Where(x => x.ora >= 12).Average(x => x.homerseklet);
            Console.WriteLine($"A délutáni átlagos hőmérséklet:{du:0.00}");

            //Melyik volt az adott napon a legmelegebb óra?
            var legmelegebb = lekerdezettNapok.Find(x=>x.homerseklet==lekerdezettNapok.Max(y=>y.homerseklet));
            Console.WriteLine($"A legmelegebb óra:{legmelegebb.ora}");

            var leghidegebb = lekerdezettNapok.Find(x => x.homerseklet == lekerdezettNapok.Min(y => y.homerseklet));
            Console.WriteLine($"A leghidegebb óra:{leghidegebb.ora}");


            



            Console.ReadKey();
        }
    }
}
