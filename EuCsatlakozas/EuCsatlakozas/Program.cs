using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuCsatlakozas
{
    class Program
    {
        struct EuAdat
        {
            public string orszag;
            public string datum;

            public EuAdat(string sor)
            {
                var e = sor.Split(';');
                orszag = e[0];
                datum = e[1];
            }
        }

        static void Main(string[] args)
        {
            List<EuAdat> euadatok = new List<EuAdat>();
            try
            {
                var adatsorok = File.ReadAllLines(@"c:/ftproot/eucsatlakozas/eucsatlakozas.txt",Encoding.Default);
                for (int i = 0; i < adatsorok.Length; i++)
                {
                    euadatok.Add(new EuAdat(adatsorok[i]));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }


            Console.WriteLine(euadatok.Count);

            var evmax = euadatok.Find(x => Convert.ToInt32(x.datum.Substring(0, 4)) == euadatok.Max(y=>Convert.ToInt32(y.datum.Substring(0,4))));
            Console.WriteLine(evmax.datum);

            Console.ReadKey();
        }
    }
}
