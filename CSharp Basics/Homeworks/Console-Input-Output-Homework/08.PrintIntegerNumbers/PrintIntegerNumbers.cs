using System;

class PrintIntegerNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
}