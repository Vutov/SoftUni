using System;

class ExchangeVar
{
    static void Main(string[] args)
    {
        byte a = 5;
        byte b = 10;
        Console.WriteLine("Before:");
        Console.WriteLine("a is: {0} and b is: {1}.", a, b);
        byte c;
        c = a;
        a = b;
        b = c;
        Console.WriteLine("After:");
        Console.WriteLine("a is: {0} and b is: {1}.", a, b);

    }
}