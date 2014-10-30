using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    private static bool IsPrime(long number)
    {
        bool isPrime = true;
        long devider = 2;
        if (number == 1 || number == 0)
        {
            isPrime = false;
            return isPrime;
        }
        while (devider <= Math.Sqrt(number))
        {
            if (number % devider != 0)
            {
                devider++;
            }
            else
            {
                isPrime = false;
                break;
            }
        }
        return isPrime;
    }
    
    private static List<int> FindPrimesInRange(int startNum, int endNum) 
    {
        List<int> primesInRange = new List<int>();

        for (int number = startNum; number <= endNum; number++)
        {
            if (IsPrime(number))
            {
                primesInRange.Add(number);
            }
        }
        return primesInRange;
    }

    private static void PrintPrimes(int startNum, int endNum)
    {
        List<int> primes = FindPrimesInRange(startNum, endNum);
        int len = primes.Count;

        for (int i = 0; i < len; i++)
        {
            if (i == len - 1)//last
            {
                Console.Write(primes[i] + ".");
            }
            else
            {
                Console.Write(primes[i] + ", ");
            }
        }
        if (len == 0)
        {
            Console.WriteLine("(empty list)");
        }
        else
        {
            Console.WriteLine();
        }
    }
    
    
    static void Main(string[] args)
    {
        PrintPrimes(0, 10);
        PrintPrimes(5, 11);
        PrintPrimes(100, 200);
        PrintPrimes(250, 950);
        PrintPrimes(100, 50);
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());
        PrintPrimes(startNum, endNum);
    }
}