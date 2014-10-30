using System;
using System.Numerics;

class PrintFacturial
{
    private static void PrintNFacturial(int number)
    {
        BigInteger facturial = (BigInteger)1;
        for (int i = 1; i <= number; i++)
        {
            facturial *= i;
        }
        Console.WriteLine("{0}! is {1}", number, facturial);
    }


    static void Main(string[] args)
    {
        PrintNFacturial(100);
    }
}
