using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class Program
    {
        public struct Domain
        {
            public string domain;
            public string ipaddress;
            public string[] domainLevels;

            public Domain(string adatsor)
            {
                domainLevels = new string[5];
                var e = adatsor.Split(';');
                domain = e[0];
                ipaddress = e[1];
                //a domain részeit a tömbbe rakjuk
                var d = e[0].Split('.');
                for (int i = 0; i < d.Length; i++)
                {
                    domainLevels[i] = d[i];
                }
            }

        }
        public static string DomainLevel(Domain d,int level)
        {
            return d.domainLevels[level-1] ;
        }


        static void Main(string[] args)
        {
            String tesztadat = "eee.ee.zu;188.189.190.1";

            Domain domain = new Domain(tesztadat);
            Console.WriteLine(domain.domain);
            Console.WriteLine(domain.ipaddress);

            for (int i = 0; i < domain.domainLevels.Length; i++)
            {
                if (domain.domainLevels[i]==null)
                {
                    Console.WriteLine("Nincs");
                }
                else
                {
                    Console.WriteLine(domain.domainLevels[i]);
                    
                }
                
            }

            //domain level tesztelése
            Console.WriteLine(DomainLevel(domain,4));

            Console.ReadKey();
        }
    }
}
