using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger twiceNFactorial = 1;
        BigInteger nFactorial = 1;
        BigInteger nPlusOneFactorial = 1;
        int nPlusOne = n + 1;
        int len = 2 * n;

        for (int i = 1; i <= len; i++)
        {
            twiceNFactorial *= i;
            if (i <= n)
            {
                nFactorial *= i;
            }
            if (i <= nPlusOne)
            {
                nPlusOneFactorial *= i;
            }
        }
        BigInteger catalan = twiceNFactorial / (nPlusOneFactorial * nFactorial);
        Console.WriteLine(catalan);
    }
}
// 2n! / ((n + 1)! * n!)