using System;

class SimpleNumber
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        //int n = 97;
        if (n > 100 || n < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        bool isPrime = true;
        int devider = 2;
        while (devider < 100)
        {
            if (devider != n)
            {
                if (n % devider != 0)
                {
                    devider++;
                }
                else
                {
                    isPrime = false;
                    break;
                }  
            }
            else
            {
                break;
            }
            
        }
        if (isPrime)
        {
            Console.WriteLine("Number {0} is prime.", n);
        }
        else
        {
            Console.WriteLine("Number {0} is NOT prime.", n);
        }

    }
}