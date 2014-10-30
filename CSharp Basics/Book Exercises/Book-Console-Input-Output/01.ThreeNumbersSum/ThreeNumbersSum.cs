using System;

class ThreeNumbersSum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter first number:");
        int numberOne = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number:");
        int numberTwo = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter third number:");
        int numberThree = int.Parse(Console.ReadLine());
        int sum;
        sum = numberOne + numberTwo + numberThree;
        Console.WriteLine("Sum of numbers: " + sum);
    }
}