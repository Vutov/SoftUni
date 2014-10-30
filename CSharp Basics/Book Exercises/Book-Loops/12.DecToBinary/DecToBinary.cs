using System;

class DecToBinary
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2);
        Console.WriteLine("{0} in binary is {1}.", number, binary);
    }
}