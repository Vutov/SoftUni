using System;

class BiggerNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        if (firstNumber > secondNumber)
        {
            Console.WriteLine("{0} is bigger than {1}.", firstNumber, secondNumber);
        }
        else if (firstNumber == secondNumber)
        {
            Console.WriteLine("{0} and {1} are equal.", firstNumber, secondNumber);
        }
        else
        {
            Console.WriteLine("{1} is bigger than {0}.", firstNumber, secondNumber);
        }
    }
}