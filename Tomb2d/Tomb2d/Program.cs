using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomb2d
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 dimenziós tömbök
            //20 sorból és 20 oszlopból álló 2d tömb deklarációja
            int[,] tomb2d = new int[20, 20];
            Random rand = new Random();

            for (int i = 0; i < tomb2d.GetLength(0); i++)
            {
                for (int j = 0; j < tomb2d.GetLength(1); j++)
                {
                    tomb2d[i, j] = rand.Next(-100, 101);
                }
            }

            for (int i = 0; i < tomb2d.GetLength(0); i++)
            {
                for (int j = 0; j < tomb2d.GetLength(1); j++)
                {
                    if (tomb2d[i,j]<0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (tomb2d[i,j]>0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                                       
                    Console.Write(tomb2d[i,j]+" ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }



            Console.ReadKey();
        }
    }
}
