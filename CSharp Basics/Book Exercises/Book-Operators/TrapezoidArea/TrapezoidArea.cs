using System;

class TrapezoidArea
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first side:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second side:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the height:");
        int h = int.Parse(Console.ReadLine());
        int area = ((a + b) / 2) * h;
        Console.WriteLine("The area of this trapezoid is {0}.", area);
    }
}