using System;

class FibonacciNumbers
{
    private static int Fib(int number)
    {
        int firstNum = 0;
        int secondNum = 1;
        int nextNum = firstNum + secondNum;
        for (int i = 1; i < number; i++)
        {
            firstNum = secondNum;
            secondNum = nextNum;
            nextNum = firstNum + secondNum;
        }
        return nextNum;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(Fib(0));
        Console.WriteLine(Fib(1));
        Console.WriteLine(Fib(2));
        Console.WriteLine(Fib(3));
        Console.WriteLine(Fib(4));
        Console.WriteLine(Fib(5));
        Console.WriteLine(Fib(6));
        Console.WriteLine(Fib(11));
        Console.WriteLine(Fib(25));
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Fib(number));
    }
}
