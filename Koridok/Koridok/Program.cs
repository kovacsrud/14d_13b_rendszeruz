using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridok
{
    class Program
    {
        public struct KorAdat
        {
            public string csapatnev;
            public string versenyzonev;
            public int eletkor;
            public string palyanev;
            public int korido;
            public int kor;

            public KorAdat(string sor)
            {
                var e = sor.Split(';');
                csapatnev = e[0];
                versenyzonev = e[1];
                eletkor = Convert.ToInt32(e[2]);
                palyanev = e[3];
                var k = e[4].Split(':');
                korido = (3600 * Convert.ToInt32(k[0])) + (60 * Convert.ToInt32(k[1])) + Convert.ToInt32(k[2]);
                kor = Convert.ToInt32(e[5]);

            }



        }

        static void Main(string[] args)
        {
            List<KorAdat> koridok = new List<KorAdat>();

            try
            {
                var sorok = File.ReadAllLines(@"c:/ftproot/koridok/autoverseny.csv",Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    koridok.Add(new KorAdat(sorok[i]));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"3.feladat. A fájlban {koridok.Count} sor van.");

            Console.ReadKey();
        }
    }
}
