using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listak
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lista: generikus adattípus, bármilyen típusú elemet tartalmazhat
            List<string> nevek = new List<string>();

            nevek.Add("Zénó");
            nevek.Add("Ubul");
            nevek.Add("Lajos");
            nevek.Add("Ignác");



            Console.WriteLine(nevek.Count);
            Console.WriteLine(nevek[0]);

            //Bejárás, listázás for-al
            for (int i = 0; i < nevek.Count; i++)
            {
                Console.WriteLine(nevek[i]);
            }

            //a lista elemei nem módosíthatóak foreach ciklussal!
            foreach (var n in nevek)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine(nevek.Contains("Zénó"));
            nevek.Clear();


            Console.ReadKey();
        }
    }
}
