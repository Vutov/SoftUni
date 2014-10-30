using System;

class ModifyIntegerBit
{

    private static int Modifier(int number, int position, int value)
    {
        int bit;
        if (value == 0)
        {
            bit = number & ~(1 << position); // using & ability ( 1 and 1 -> 1),
        }                                   // ( 0 and 1 -> 0) using ~ only one bit
        else                                // is changed.
        {
            bit = number | (1 << position); // (0 and 0 -> 0) (0 and 1, 1 and 1 -> 1).
        }
        return bit;
    }

    private static void PrintModifier(int number, int position, int value)
    {
        Console.WriteLine("Number {0} with changed bit {1} to value {2} is {3}.",
            number, position, value, Modifier(number, position, value));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the position of the bite");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for the bit (0 or 1)");
        int v = int.Parse(Console.ReadLine());
        PrintModifier(n, p, v);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintModifier(5, 2, 0);
        PrintModifier(0, 9, 1);
        PrintModifier(15, 1, 1);
        PrintModifier(5343, 7, 0);
        PrintModifier(62241, 11, 0);
    }
}