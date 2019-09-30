using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FajlokAllread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fájlok beolvasása egyéb módokon
            try
            {
                
                var sorok = File.ReadAllLines(@"d:/rud/tesztadat_20k.txt", Encoding.Default);
                
                

                for (int i = 0; i < sorok.Length; i++)
                {
                    //Itt dolgozzuk fel a tömb adatait
                    Console.WriteLine(sorok[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }




            Console.ReadKey();
        }
    }
}
