# Két dimenziós tömbök

Ez a tömb egy táblázatként fogható fel, sorokra, oszlopokra tagolódik.
**Deklaráció**
```C#
 int[,] tomb2d = new int[20, 20];
```

**Feltöltés értékekkel (pl. véletlen számok)**

```C#
 Random rand = new Random();

for (int i = 0; i < tomb2d.GetLength(0); i++)
    {
        for (int j = 0; j < tomb2d.GetLength(1); j++)
                {
                    tomb2d[i, j] = rand.Next(-100, 101);
                }
    }
```
