using System;

class PrimeChecker
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

    static void Main(string[] args)
    {
        Console.WriteLine(IsPrime(0));
        Console.WriteLine(IsPrime(1));
        Console.WriteLine(IsPrime(2));
        Console.WriteLine(IsPrime(3));
        Console.WriteLine(IsPrime(4));
        Console.WriteLine(IsPrime(5));
        Console.WriteLine(IsPrime(323));
        Console.WriteLine(IsPrime(337));
        Console.WriteLine(IsPrime(6737626471));
        Console.WriteLine(IsPrime(117342557809));
        long number = long.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(number));
    }
}
