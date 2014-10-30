using System;
using System.Numerics;

class FactorialDevidedByFactorial
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        BigInteger nFacturial = 1;
        BigInteger kFacturial = 1;
        int len = Math.Max(n, k);
        for (int i = 1; i <= len; i++)
        {
            if (i <= n)
            {
                nFacturial *= i;
            }
            if (i <= k)
            {
                kFacturial *= i;
            }
        }
        BigInteger result = nFacturial / kFacturial;
        Console.WriteLine(result);
    }
}

/*Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
Use only one loop. Examples:
 
n	k	n! / k!	   
5	2	60	   
6	5	6	   
8	3	6720	 
*/