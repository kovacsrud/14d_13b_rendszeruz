# Fájlok betöltése, írása C#-ban

```C#
using System.IO;
```
IO névteret be kell tölteni.

A fájl műveleteket try...catch blokkba érdemes rakni, hogy az esetlegesen keletkező kivételeket el lehessen kapni, kezelni.

Először egy FileStream deklarálására van szükség:
```C#
FileStream fajl = new FileStream(@"d:/rud/tesztadat_20k.txt",FileMode.Open);
```

Utána kell egy StreamReader:
```C#
 StreamReader sr = new StreamReader(fajl, Encoding.Default);
```

Ezek után lehet olvasni soronként a fájl végéig
```C#
 while (!sr.EndOfStream)
   {
        Console.WriteLine(sr.ReadLine());
   }
```
Végül a fájlt be kell zárni:
```C#
sr.Close();
```

Ha használjuk a **using** utasítást, akkor nem kell külön lezárni a fájlt, a **using** blokk automatikusan el fogja végezni ezt.

A teljes kód using-al:
```C#
try
            {
                FileStream fajl = new FileStream(@"d:/rud/tesztadat_20k.txt",FileMode.Open);
                

                using (StreamReader sr = new StreamReader(fajl, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
```
A fájl adatainak a feldolgozásához struktúrát, vagy osztályt célszerű használni.

**Struktúra deklaráció**

```C#
struct Ember
        {
            public string vezeteknev;
            public string keresztnev;
            public int szuletesiEv;
            public string szuletesiHely;
        }
```

A fájl sorainak feldolgozása a cikluson belül:
```C#
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
```

**Adott feltételnek megfelelő adatok leválogatása egy új listába**

```C#
var hatvankilenc = emberek.FindAll(x=>x.szuletesiEv==1969);
```

**A kiválogatott adatok fájlba írása**

```C#
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

```

**Összesítések készítése a ToLookup() függvénnyel**

Ezzel a függvénnyel tetszőleges bonyolultságú összesítéseket lehet készíteni. Az összesítés alapja a kulcsnak megadott adatmező, ezeknek az egyenkénti előfordulását (darabszámát) lehet meghatározni könnyen.

pl: az 1969-ben születettek darabszáma vezetéknév szerint csoportosítva:
```C#
var csoport = hatvankilenc.ToLookup(x=>x.vezeteknev).OrderBy(x=>x.Key);
```
**Az eredmény kiíratása**
```C#
 foreach (var c in csoport)
    {
            Console.WriteLine($"Vezetéknév:{c.Key},{c.Count()}.db");
    }
```

**Összesítés több adat alapján**

Ebben az esetben a ToLookUp()-függvénynek több kulcsot adunk meg. Több kulcs megadásához szükséges a **new \{}**!
pl. 69-ben születettek születési hely és keresztnév szerint csoportosítva:
```C#
var szhely = hatvankilenc.OrderBy(x => x.szuletesiHely).ThenBy(x => x.keresztnev).ToLookup(x=>new {x.szuletesiHely,x.keresztnev });
```
**Az eredmény**
```C#
foreach (var sz in szhely)
    {
        Console.WriteLine($"{sz.Key.szuletesiHely},{sz.Key.keresztnev},{sz.Count()}");
    }
```
Összetett kulcs esetény az adatmezők a **Key**-en belül érhetőek el!
pl. **sz.Key.szuletesiHely**
