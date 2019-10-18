# Milyen kifejezéseket érdemes használni az egyes típusfeladatoknál?

**Minden esetben törekedni kell lista létrehozására, és ebbe tölteni az adatokat**
Ha van listánk, akkor az elemek száma:
```C#
 Console.WriteLine($"Feladat x. :{listanev.Count}");
```

**Feltétel szerinti lekérdezés, darabszám meghatározással**

Ha egy elemet kérdezünk le (Find-ot kell használni):
```C#
var legkevesebb = stadionok.Find(x=>x.ferohely==stadionok.Min(y=>y.ferohely));
```

Ha több elem lesz az eredmény (FindAll-t kell használni):
```C#
var nincsalternativ = stadionok.FindAll(x=>x.nev2!="n.a.");
```

**Tartalmaz-e a lista az adott feltételnek megfelelő elemet?**
lista.Any()-t kell használni
Ebben az esetben csak egy igen/nem értékre van szükség legtöbbször, és nem magára az elemre.
```C#

            if (stadionok.Any(x=>x.varos.ToLower()==varos.ToLower()))
            {
                Console.WriteLine($"{varos} városban zajlottak mérkőzések!");
            } else
            {
                Console.WriteLine($"{varos} városban nem zajlottak mérkőzések!");
            }
```
**Csoportosítás egy vagy több adatmező szerint**
lista.ToLookup(x=>x.MelyAdatSzertinCsoportositunk);
```C#
var kulonbozoHelyszinek = stadionok.ToLookup(x => x.varos);
```

