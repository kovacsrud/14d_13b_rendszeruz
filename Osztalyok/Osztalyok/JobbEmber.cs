using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztalyok
{
    public class JobbEmber
    {
        
        public string Nev { get; set; }
        public int Kor { get; set; }
        public int Magassag { get; set; }
        public int Suly { get; set; }

        public JobbEmber(string nev, int kor, int magassag, int suly)
        {
            Nev = nev;
            Kor = kor;
            Magassag = magassag;
            Suly = suly;
        }


    }
}
