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
