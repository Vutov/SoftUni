using System;

class Disk
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int radius = int.Parse(Console.ReadLine());
        int center = size / 2;
        char dot = '.';
        char star = '*';

        for (int row = -center; row <= center; row++)
        {
            for (int col = -center; col <= center; col++)
            {   
                //Is it inside the circle;
                if (Math.Pow(row, 2) + Math.Pow(col, 2) <= Math.Pow(radius, 2))
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
}