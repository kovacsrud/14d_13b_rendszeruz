# Változók

A memória egy adott része, amely egy névvel van azonosítva.

## Érték típusok

- egész számok
- nem egész számok
- szövegek
- karakterek
- logikai értékek

### Nem egész típusok
- float
- double
- decimal

**Pénzügyi alkalmazásokhoz kell a decimal, a többi esetben megfelelő a double, vagy a float**

## Referencia típusú változók

 - tömbök
 - objektumok stb.

**Példák**

```c#
            //Szöveg
            string szoveg = "Valami szöveg";
            //karakter
            char karakter = 'g';
            //egész számok
            int szam = 345;
            short masikSzam = 235;
            byte bajt = 221;
            //logikai
            bool logikai = false;

            //lebegőpontos számok
            float egyszeres = 15.6634249364646463462f;
            double ketszeres = 15.6634249364646463462;
            decimal dec = 15.6634249364646463462m;
```

## String típus

A string típus értéke nem változtatható meg.

**String kezelő műveletek**
 - String hossza
Console.WriteLine(szoveg.Length);

 - Ezzel kezdődik?
 ```C#
  Console.WriteLine(szoveg.StartsWith("Val"));
```

 - Írásmód változtatása
```C#
   Console.WriteLine(szoveg.ToLower());
   Console.WriteLine(szoveg.ToUpper());
```

 - szövegrész kiemelése
```C#   
   Console.WriteLine(szoveg.Substring(1,4));
```
**év, hónap, nap kinyerése dátumot tartalmazó string-ből**
```C#
string datum = "2019-09-12";

var ev = datum.Substring(0, 4);
var honap = datum.Substring(5, 2);
var nap = datum.Substring(8, 2);
```

Ha karakterenként kell alakítani, akkor CharArray()-é (karaktertömb) kell alakítani a stringet.

