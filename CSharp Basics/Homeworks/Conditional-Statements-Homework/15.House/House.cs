using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class House
{
    static void Main(string[] args)
    {
        //int n = 9;
        int n = int.Parse(Console.ReadLine());
        char star = '*';
        char dot = '.';
        int height = n;
        int width = n;
        int roofHeight = height / 2;
        int floorHeight = height / 2 - 1;
        //roof
        for (int i = 0; i < roofHeight; i++)
        {
            for (int row = 0; row < width; row++)
            {
                if (row == (width / 2) + i || row == (width / 2) - i)
                {
                    Console.Write(star);
                }
                else
                {
                    Console.Write(dot);
                }
                
            }
            Console.WriteLine();
        }
        //floors.
        for (int i = 0; i < width; i++)
        {
            Console.Write(star);
        }
        Console.WriteLine();
        for (int i = 0; i < floorHeight; i++)
        {
            for (int row = 0; row < width; row++)
            {
                if (row == n / 4 || row == width - 1 - n / 4)
                {
                    Console.Write(star);
                }
                else
                {
                    Console.Write(dot);
                } 
            }
            Console.WriteLine();
        }
        //first floor.
        for (int i = 0; i < width; i++)
        {
            if (i >= n / 4 && i <= width - 1 - n / 4)
            {
                Console.Write(star);
            }
            else
            {
                Console.Write(dot);
            } 
        }
        Console.WriteLine();
    }
}