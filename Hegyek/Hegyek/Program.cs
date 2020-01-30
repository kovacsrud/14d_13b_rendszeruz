using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hegyek
{
    class Program
    {
        struct hegy
        {
            public string hegycsucs;
            public string hegysegnev;
            public int magassag;

            public hegy(string sor)
            {
                var e = sor.Split(';');
                hegycsucs = e[0];
                hegysegnev = e[1];
                magassag = Convert.ToInt32(e[2]);
            }

        }

        static void Main(string[] args)
        {
            List<hegy> hegyek = new List<hegy>();

            try
            {
                var sorok = File.ReadAllLines(@"hegyekMo.txt", Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    hegyek.Add(new hegy(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Feladat 3. {hegyek.Count}.adatsor található a fájlban.");

            //átlagmagasság meghatározása
            var atlagmagassag = hegyek.Average(x=>x.magassag);
            Console.WriteLine($"Feladat 4. Az átlag magasság:{atlagmagassag}");

            //legmagasabb hegy
            var legmagasabb = hegyek.Find(x=>x.magassag==hegyek.Max(y=>y.magassag));

            Console.WriteLine($"Feladat 5. A legmagasabb hegycsúcs adatai,magasság:{legmagasabb.magassag},hegy:{legmagasabb.hegycsucs},hegység:{legmagasabb.hegysegnev}");

            //legmagasabb hegy Findall-al

            var lgmagasabb= hegyek.FindAll(x => x.magassag == hegyek.Max(y => y.magassag));

            foreach (var i in lgmagasabb)
            {
                Console.WriteLine($"Feladat 5. A legmagasabb hegycsúcs adatai,magasság:{i.magassag},hegy:{i.hegycsucs},hegység:{i.hegysegnev}");
            }

            Console.Write("Adjon meg egy magasságot:");
            var bemagassag = Convert.ToInt32(Console.ReadLine());

            if (hegyek.Any(x=>x.magassag>bemagassag && x.hegysegnev=="Börzsöny"))
            {
                Console.WriteLine($"Van a {bemagassag}-nál magasabb csúcs!");
            } else
            {
                Console.WriteLine($"Nincs a {bemagassag}-nál magasabb csúcs!");
            }

            //hegycsúcsok száma
            var hegycsucsstat = hegyek.ToLookup(x=>x.hegysegnev);

            Console.WriteLine($"Feladat 8, hegycsúcs statisztika");

            foreach (var i in hegycsucsstat)
            {
                Console.WriteLine($"{i.Key},{i.Count()} db.");
            }

            var bukk = hegyek.FindAll(x=>x.hegysegnev=="Bükk-vidék");

            try
            {
                FileStream fajl = new FileStream(@"bukk-videk.txt", FileMode.Create);

                using (StreamWriter writer=new StreamWriter(fajl,Encoding.Default))
                {
                    string fejlec = $"Hegycsúcs neve;Magasság láb";
                    writer.WriteLine(fejlec);

                    foreach (var i in bukk)
                    {
                        writer.WriteLine($"{i.hegycsucs};{i.magassag*3.280839895:0.00}");
                    }

                }
                Console.WriteLine("Kiírás kész!");   
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
