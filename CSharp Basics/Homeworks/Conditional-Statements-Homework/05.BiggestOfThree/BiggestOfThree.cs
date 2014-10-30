using System;

class BiggestOfThree
{
    static void Main(string[] args)
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        Console.WriteLine(Math.Max(Math.Max(a, b), Math.Max(b, c)));
    }
}