using System;

class FiveAndSevenRemainder
{

    private static bool Devider(int number)
    {
        bool remainder = false;
        if (number % 5 == 0 && number % 7 == 0 && number != 0) //acording to C# 0 % number is 0.
        {
            remainder = true;
        }
        return remainder;
    }

    private static void PrintDevider(int number, bool devider)
    {
        Console.WriteLine("Number {0} can be divided (without remainder) by 7 and 5 in the same time: {1}",
            number, Devider(number));
    }

    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        PrintDevider(number, Devider(number));
        Console.WriteLine("Condition numbers:");
        PrintDevider(3, Devider(3)); //test with condition numbers.
        PrintDevider(0, Devider(0));
        PrintDevider(5, Devider(5));
        PrintDevider(7, Devider(7));
        PrintDevider(35, Devider(35));
        PrintDevider(140, Devider(140));
    }
}