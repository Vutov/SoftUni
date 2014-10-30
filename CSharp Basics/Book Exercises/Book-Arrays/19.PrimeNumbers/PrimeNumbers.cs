using System;
using System.Threading;

class PrimeNumbers
{
    private static bool IsPrime(long number)
    {
        bool isPrime = true;
        long devider = 2; // prime number is divisible without remainder
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
    
    static void Main(string[] args)
    {
        uint count = 0;
        for (long i = 1; i <= 10000000; i++)
        {
            if (IsPrime(i))
            {
                //Thread.Sleep(150);
                Console.WriteLine(i);
                //count++;
            }
        }
        //Console.WriteLine(count);
    }
}


//Напишете програма, която намира всички прости числа в диапазона [1…10 000 000].