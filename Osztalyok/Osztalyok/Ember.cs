using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztalyok
{
    public class Ember
    {
        private string nev;
        private int kor;
        private int magassag;
        private int suly;

        public Ember(string n,int k,int m,int s)
        {
            nev = n;
            kor = k;
            magassag = m;
            suly = s;
        }
        //üres konstruktor
        public Ember()
        {

        }

        public void setNev(string beNev)
        {
            nev = beNev;
        }

        public string getNev()
        {
            return nev;
        }

    }
}
