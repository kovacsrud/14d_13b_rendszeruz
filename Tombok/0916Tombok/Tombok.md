# Tömbök

**Tömb: azonos típusú adatokat tartalmazó adatszerkezet**
Deklarálás
```C#
int[] szamok = new int[5];
```

**deklarálás az elemek megadásával**
```C#
int[] masikSzamok = {1,2,3,4,5};
```
            
**Indexelés:** masikSzamok[0] -> 1


**deklarálás a var kulcsszóval**
```C#
var szamTomb = new int[10];
```

**tömb elemeinek kiíratása**
```C#
for (int i = 0; i < masikSzamok.Length; i++)
    {
        Console.WriteLine(masikSzamok[i]);
    }
```