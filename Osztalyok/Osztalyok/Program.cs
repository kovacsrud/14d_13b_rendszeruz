using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztalyok
{
    class Program
    {
        static void Main(string[] args)
        {
            //példányosítás
            Ember elek = new Ember("Elek",26,176,87);
            //metódus hívás
            //elek.setNev("Elek");

            Console.WriteLine(elek.getNev());  

            Ember ubul = new Ember("Ubul",45,183,91);
            


            Console.ReadKey();
        }
    }
}
