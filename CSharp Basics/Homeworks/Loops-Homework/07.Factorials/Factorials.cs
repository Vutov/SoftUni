using System;
using System.Numerics;

class Factorials
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        BigInteger nFacturial = 1;
        BigInteger kFacturial = 1;
        BigInteger diffFacturial = 1; //lenght n - k;
        int diff = n - k;
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
            if (i <= diff)
            {
                diffFacturial *= i;
            }
        }
        BigInteger result = nFacturial / ( kFacturial * diffFacturial);
        Console.WriteLine(result);
    }
}
/*In combinatorics, the number of ways to choose k different
 * members out of a group of n different elements (also known
 * as the number of combinations) is calculated by the following formula:
 
For example, there are 2598960 ways to withdraw 5 cards out of a 
 * standard deck of 52 cards. Your task is to write a program that
 * calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100).
 * Try to use only two loops. Examples:
 
n	k	n! / (k! * (n-k)!)	   
3	2	3	   
4	2	6	   
10 	6	210	   
52	5	2598960	 
*/