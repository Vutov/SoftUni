using System;

class NumberOFZerosFacturial
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter value for n:");
        uint n = uint.Parse(Console.ReadLine());
        ulong facturial = 1;
        for (uint i = 1; i <= n; i++)
        {
            facturial *= i;
        }
        int count = new int();
        while (facturial % 10 == 0)
        {
            facturial /= 10;
            count++;
        }
        Console.WriteLine("Facturial of {0} have {1} zeros.", n, count);
    }
}
