using System;

class MathSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        double sum = 1d;
        ulong factorial = 1u;
        double rooted = 0d;

        for (uint i = 1; i <= n; i++)
        {
            factorial *= i;
            rooted = Math.Pow(x, i);
            sum += (factorial / rooted);
        }
        Console.WriteLine("{0:F5}", sum);
    }
}
//Write a program that, for a given two integer numbers n and x,
//calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn.
//Use only one loop. Print the result with 5 digits after the decimal point.
