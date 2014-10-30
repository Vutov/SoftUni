using System;

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter length of the line: ");
        int n = int.Parse(Console.ReadLine());  
        ulong firstNumber = 0;
        ulong secondNumber = 1;
        ulong nextNumber = new int();
        Console.WriteLine("First {0} of Fibonacci numbers", n);
        for (int i = 0; i < n; i++)
        {
            Console.Write(firstNumber + " ");
            nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
        }
        Console.WriteLine();
    }
}