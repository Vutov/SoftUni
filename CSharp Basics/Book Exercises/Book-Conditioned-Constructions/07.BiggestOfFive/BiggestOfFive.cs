using System;

class BiggestOfFive
{
    static void Main(string[] args)
    {
        int a = 4;
        int b = 1;
        int c = 6;
        int d = 2;
        int e = 8;
        Console.WriteLine(Math.Max((Math.Max(Math.Max(a, b), Math.Max(c, d))), e));
    }
}