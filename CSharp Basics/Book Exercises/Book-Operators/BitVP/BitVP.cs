using System;

class BitVP
{
    static void Main(string[] args)
    {
        //int n = 35;
        //int p = 2;
        //int v = 1;
        Console.WriteLine("n =");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("p =");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("v =");
        int v = int.Parse(Console.ReadLine());
        if (v != 0 && v != 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (v == 1)
        {
            n = n | (1 << p);
        }
        else
        {
            n = n & (~(1 << p));
        }
        Console.WriteLine("The new number is {0}.", n);
    }
}