using System;

class ConvertToBinary
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2);
        Console.WriteLine(binary);
    }
}