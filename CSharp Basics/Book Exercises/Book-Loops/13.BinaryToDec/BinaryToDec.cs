using System;

class BinaryToDec
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a binary number:");
        string number = Console.ReadLine();
        int value = Convert.ToInt32(number, 2);
        Console.WriteLine("{0} in decemetric is {1}.", number, value);
    }
}