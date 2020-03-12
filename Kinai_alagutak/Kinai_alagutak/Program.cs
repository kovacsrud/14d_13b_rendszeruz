using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinai_alagutak
{
    class Program
    {
        struct Alagut
        {
            public string AlagutNev;
            public int AlagutHossz;
            public string AtadasEve;
            public string TartAz;

            public Alagut(string sor)
            {
                var e = sor.Split(';');
                AlagutNev = e[0];
                AlagutHossz = Convert.ToInt32(e[1]);
                AtadasEve = e[2];
                TartAz = e[3];

            }
        }
        static void Main(string[] args)
        {
            List<Alagut> alagutak = new List<Alagut>();
            try
            {
                var sorok = File.ReadAllLines(@"CNtunnels.txt",Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    alagutak.Add(new Alagut(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Feladat 3: a forrás allományban {alagutak.Count} alagút van.");

            var legrovidebb = alagutak.Find(x=>x.AlagutHossz==alagutak.Min(y=>y.AlagutHossz)).AlagutNev;
            Console.WriteLine($"Feladat 4: a legrövidebb alagút:{legrovidebb}");

            var epitesalatt = alagutak.FindAll(x=>x.AtadasEve.ToLower()=="uc".ToLower()).Count;
            Console.WriteLine($"Feladat 5: {epitesalatt} db alagút van építés alatt.");

            Console.Write("Adjon meg egy tartományt:");
            var tartomany = Console.ReadLine();
            while (tartomany.Length!=2)
            {
                Console.Write("2 karakter legyen az a tartomány:");
                tartomany = Console.ReadLine();
            }

            var leghosszabb = alagutak.FindAll(x=>x.TartAz.ToLower()==tartomany.ToLower());

            if (leghosszabb.Count>0)
            {
                var adatok = leghosszabb.Find(x=>x.AlagutHossz==leghosszabb.Max(y=>y.AlagutHossz));
                Console.WriteLine($"A {tartomany} leghosszabb alagútja:{adatok.AlagutHossz},{adatok.AlagutNev},{adatok.AtadasEve}");
            } else
            {
                Console.WriteLine("Hibás tartomány!");
            }

            Console.ReadKey();
        }
    }
}
