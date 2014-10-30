using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arrow
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        char hastag = '#';
        char dot = '.';
        int signWidth = width * 2 - 1;//9

        int arrowPoint = width - 1;
        int arrowStem = width - 2;
        //arrow base
        for (int k = 1; k < (signWidth / 2) + 1 - (width / 2); k++)
        {
            Console.Write(dot);
        }
        for (int j = (signWidth / 2) + 1 - (width / 2); j <= (signWidth / 2) + 1 + (width / 2); j++)
        {
            Console.Write(hastag);
        }
        for (int k = (signWidth / 2) + 1 + (width / 2); k < signWidth; k++)
        {
            Console.Write(dot);
        }
        Console.WriteLine();
        //arrow body
        for (int row = 0; row < arrowStem; row++)
        {
           for (int i = 1; i <= signWidth; i++)
            {
                if (i == (signWidth / 2) + 1 - (width / 2) || i == (signWidth / 2) + 1 + (width / 2))
                {
                    Console.Write(hastag);
                }
                else
                {
                    Console.Write(dot);     
                }
            }
            Console.WriteLine(); 
        }
        //head base
        for (int k = 0; k < (signWidth / 2) + 1 - (width / 2); k++)
        {
            Console.Write(hastag);
        }
        for (int j = (signWidth / 2) - (width / 2); j <= (signWidth / 2) - 2 + (width / 2); j++)
        {
            Console.Write(dot);
        }
        for (int k = (signWidth / 2) + 1 + (width / 2); k <= signWidth; k++)
        {
            Console.Write(hastag);
        }
        Console.WriteLine();
        //arrow head
        for (int row = 0; row < arrowPoint; row++)
        {
            for (int i = signWidth; i > 0; i--)
            {
                if (i == signWidth - 1 - row || i == 2 + row)
                {
                    Console.Write(hastag);
                }
                else
                {
                    Console.Write(dot);
                }
            }
            Console.WriteLine();
        }
        
    }
}

/*
..#####..1
..#...#..w - 2
..#...#..w - 2
..#...#..w - 2
###...###1
.#.....#.w - 1
..#...#..w - 1
...#.#...w - 1
....#....w - 1
*/