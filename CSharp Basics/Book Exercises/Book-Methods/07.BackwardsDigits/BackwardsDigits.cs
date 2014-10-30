using System;

class BackwardsDigits
{
    private static void PrintDigitsBackwards(int number)
    {
        while (number != 0)
        {
            int digit = number % 10;
            number /= 10;
            Console.Write(digit);
        }
        Console.WriteLine();
    }
    
    static void Main(string[] args)
    {
        int number = 256;
        PrintDigitsBackwards(number);
    }
}