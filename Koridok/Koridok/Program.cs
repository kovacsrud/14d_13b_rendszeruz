using System;
using System.Collections.Generic;
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

            Console.ReadKey();
        }
    }
}
