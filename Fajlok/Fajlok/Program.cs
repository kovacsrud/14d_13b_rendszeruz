using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fajlok
{
    class Program
    {
        struct Ember
        {
            public string vezeteknev;
            public string keresztnev;
            public int szuletesiEv;
            public string szuletesiHely;
        }
        static void Main(string[] args)
        {
            Ember ember = new Ember();
            List<Ember> emberek = new List<Ember>();

            try
            {
                FileStream fajl = new FileStream(@"d:/rud/tesztadat_20k.txt",FileMode.Open);
                

                using (StreamReader sr = new StreamReader(fajl, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        //a fájl egy sorának feldolgozása tömbbe
                        var e = sr.ReadLine().Split(',');
                        ember.vezeteknev = e[0];
                        ember.keresztnev = e[1];
                        //konvertálni kell számra
                        ember.szuletesiEv = Convert.ToInt32(e[2]);
                        ember.szuletesiHely = e[3];

                        emberek.Add(ember);
                           
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Adatsorok száma:{emberek.Count}");

            var hatvankilenc = emberek.FindAll(x=>x.szuletesiEv==1969);
            //adott feltételnek megfelelő adatok megszámolása
            var mennyi = emberek.Count(x=>x.szuletesiEv==1969);

            Console.WriteLine(hatvankilenc.Count);

            foreach (var h in hatvankilenc)
            {
                Console.WriteLine($"{h.vezeteknev},{h.keresztnev},{h.szuletesiEv},{h.szuletesiHely}");
            }

            try
            {
                FileStream outFajl = new FileStream(@"d:/h9.txt",FileMode.Create);
                using (StreamWriter sw=new StreamWriter(outFajl,Encoding.Default))
                {
                    foreach (var h in hatvankilenc)
                    {
                        sw.WriteLine($"{h.vezeteknev},{h.keresztnev},{h.szuletesiEv},{h.szuletesiHely}");
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
