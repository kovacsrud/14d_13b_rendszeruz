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
            string nev;
            string osztaly;
            int elsoNap;
            int utolsoNap;
            int mulasztottOrak;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            Console.ReadKey();
        }
    }
}
