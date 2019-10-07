# Osztály (class)

Olyan egysége a programnak, amely jól meghatározott határokkal rendelkezik.
Adat tagokat, illetve metódusokat (függvény) tartalmaz.

**Egy osztály létrehozása 4 adattaggal**

```C#
public class Ember
    {
        public string nev;
        public int kor;
        public int magassag;
        public int suly;
    }
```
**A főprogramban az osztályból példányokat kell létrehozni**
```C#
Ember elek = new Ember();
elek.nev = "Elek";
elek.kor = 25;

Ember ubul = new Ember();
ubul.nev = "Ubul";
```
**Az osztályban a konstruktorral az osztály kezdeti értékeit lehet beállítani**
```C#
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

        public void setNev(string beNev)
        {
            nev = beNev;
        }

        public string getNev()
        {
            return nev;
        }

    }
```