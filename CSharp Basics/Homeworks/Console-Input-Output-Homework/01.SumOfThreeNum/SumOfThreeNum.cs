using System;
// float and double's are entered with "," in the console
class SumOfThreeNum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter first number:");
        float numberOne = float.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number:");
        float numberTwo = float.Parse(Console.ReadLine());
        Console.WriteLine("Please enter third number:");
        float numberThree = float.Parse(Console.ReadLine());
        float sum = numberOne + numberTwo + numberThree;
        Console.WriteLine("Sum of numbers: " + sum);
    }
}