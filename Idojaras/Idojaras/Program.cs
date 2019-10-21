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

            Console.WriteLine(idojarasAdatok.Count);


            Console.ReadKey();
        }
    }
}
