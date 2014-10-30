using System;

class PrimeChecker
{

    private static bool IsPrime(int number)
    {
        bool isPrime = true;
        int devider = 2; // prime number is divisible without remainder
        //only to itself and 1.
        if (number == 1) // 1 is not prime acording to wikipedia.
        {
            isPrime = false;
            return isPrime;
        }
        while (devider < 100)
        {
            if (devider != number)
            {
                if (number % devider != 0)
                {
                    devider++;
                }
                else // the number can be devided => is not prime
                {
                    isPrime = false;
                    break;
                }
            }
            else // devider == self => it is prime
            {
                break;
            }
        }
        return isPrime;
    }

    private static void PrintIsPrime(int number)
    {
        Console.WriteLine("Number {0} is prime: {1}", number, IsPrime(number));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        int n = int.Parse(Console.ReadLine());
        //int n = 97;
        if (n >= 100) //in case n >= 100.
        {
            throw new ArgumentOutOfRangeException();
        }
        PrintIsPrime(n);
        Console.WriteLine("Condition numbers:");
        PrintIsPrime(1); //test with condition numbers.
        PrintIsPrime(2);
        PrintIsPrime(3);
        PrintIsPrime(4);
        PrintIsPrime(9);
        PrintIsPrime(97);
        PrintIsPrime(51);
        PrintIsPrime(-3);
        PrintIsPrime(0);
    }
}