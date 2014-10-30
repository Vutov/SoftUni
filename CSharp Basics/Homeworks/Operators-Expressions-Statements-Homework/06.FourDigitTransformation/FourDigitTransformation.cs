using System;

class FourDigitTransformation
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter 4 digit number");
        int number = int.Parse(Console.ReadLine());
        //int number = 2011;
        int sum = new int();
        int digit;
        int[] allDigits = new int[4]; // array
        for (int i = 0; i < 4; i++) // first and second condition
        {
            sum += number % 10;
            digit = number % 10;
            allDigits[i] = digit; //adding to array
            number /= 10;
        }
        Console.WriteLine("The sum of digits is {0}.", sum);
        Console.WriteLine("Digits backwards: "); // 
        for (int i = 0; i < 4; i++)
        {
            Console.Write(allDigits[i]); // index i of array allDigits
        }
        Console.WriteLine("\nLast digit in first place:"); // third condition
        Console.Write(allDigits[0]);
        for (int i = 3; i > 0; i--)
        {
            Console.Write(allDigits[i]);
        }
        Console.WriteLine("\nSecond and third digit are swaped:"); // last condition
        Console.WriteLine("" + allDigits[3] + allDigits[1] + allDigits[2] + allDigits[0]);
    }
}
