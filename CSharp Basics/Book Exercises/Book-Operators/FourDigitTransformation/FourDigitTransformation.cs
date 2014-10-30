using System;

class FourDigitTransformation
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        //int number = 2011;
        int sum = new int();
        int digit;
        int[] digits = new int[4];
        for (int i = 0; i < 4; i++)
        {
            sum += number % 10;
            digit = number % 10;
            digits[i] = digit;
            number /= 10;
        }
        Console.WriteLine("The sum of digits is {0}.", sum);
        Console.WriteLine("Digits backwards: ");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(digits[i]);
        }
        Console.WriteLine("\nLast digit in first place:");
        Console.Write(digits[0]);
        for (int i = 3; i > 0; i--)
        {
            Console.Write(digits[i]);
        }
        Console.WriteLine("\nSecond and third digit are swaped:");
        Console.WriteLine("" + digits[3] + digits[1] + digits[2] + digits[0]);
    }
}