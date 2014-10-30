using System;

class CatalansNumbers
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Please enter value for n:");
        int n = int.Parse(Console.ReadLine());
        int nFacturial = 1;
        for (int i = 1; i <= n; i++)
        {
            nFacturial *= i;
        }
        int twiceN = 2 * n;
        int twiceNFacturial = 1;
        for (int i = 1; i <= twiceN; i++)
        {
            twiceNFacturial *= i;
        }
        int nPlusOne = n + 1;
        int nPlusOneFacturial = 1;
        for (int i = 1; i <= nPlusOne; i++)
        {
            nPlusOneFacturial *= i;
        }
        Console.WriteLine(twiceNFacturial / (nPlusOneFacturial * nFacturial));
    }
}