using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        string hexadecimal = Convert.ToString(number, 16);
        hexadecimal = hexadecimal.ToUpper();
        Console.WriteLine("{0} in binary is {1}.", number, hexadecimal);
    }
}