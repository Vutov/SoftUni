using System;

class BiggestOfThree
{
    static void Main(string[] args)
    {
        int a = 1;
        int b = 3;
        int c = 2;
        Console.WriteLine(Math.Max(Math.Max(a, b), Math.Max(b, c)));
        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(c);
            }
        }
        else if (b > c)
        {
            if (b > a)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(a);
            }
        }
        else // b > a
        {
            if (b > c)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(c);
            }
        }
    }
}