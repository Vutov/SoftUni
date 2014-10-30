using System;
using System.Numerics;

class Cartesian
{
    static void Main(string[] args)
    {
        decimal X = decimal.Parse(Console.ReadLine());
        decimal Y = decimal.Parse(Console.ReadLine());

        if (X == 0 && Y == 0)
        {
            Console.WriteLine(0);
        }
        else if (X == 0)
        {
            Console.WriteLine(5);
        }
        else if (Y == 0)
        {
            Console.WriteLine(6);
        }
        else if (X > 0 && Y > 0)
        {
            Console.WriteLine(1);
        }
        else if (X < 0 && Y > 0)
        {
            Console.WriteLine(2);
        }
        else if (X < 0 && Y < 0)
        {
            Console.WriteLine(3);
        }
        else // if (X > 0 && Y < 0)
        {
            Console.WriteLine(4);
        }
    }
}
