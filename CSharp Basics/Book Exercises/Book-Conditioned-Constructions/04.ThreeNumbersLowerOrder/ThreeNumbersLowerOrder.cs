using System;

class ThreeNumbersLowerOrder
{
    static void Main(string[] args)
    {
        int a = 1;
        int b = 4;
        int c = 7;
        Console.WriteLine(Math.Max(Math.Max(a, b), Math.Max(b, c)));
        Console.WriteLine(Math.Min(Math.Max(a, b), Math.Min(b, c)));
        Console.WriteLine(Math.Min(Math.Min(a, b), Math.Max(b, c)));
        Console.WriteLine("-------------");
        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }
        else if (b > c)
        {
            if (b > a)
            {
                Console.WriteLine(b);
                Console.WriteLine(a);
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
            }
        }
        else // b > a
        {
            if (b > c)
            {
                Console.WriteLine(b);
                Console.WriteLine(c);
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
        }
    }
}