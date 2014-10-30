using System;

class PointInCircumference
{
    static void Main(string[] args)
    {
        Console.WriteLine("x = ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("y = ");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine("Radius = ");
        int radius = int.Parse(Console.ReadLine());
        int num = (x * x + y * y);
        if (num <= radius)
        {
            Console.WriteLine("The point is inside.");
        }
        else
        {
            Console.WriteLine("The point is outside.");
        }
    }
}