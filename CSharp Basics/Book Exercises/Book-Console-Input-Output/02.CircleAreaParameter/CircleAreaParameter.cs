using System;

class CircleAreaParameter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter radius:");
        double r = double.Parse(Console.ReadLine());
        double area = Math.PI * Math.Pow(r, 2);
        double perimeter = 2 * Math.PI * r;
        Console.WriteLine("Area = {0}\nPerimeter = {1}", area, perimeter);
    }
}