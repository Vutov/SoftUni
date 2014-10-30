using System;

class Rectangles
{
    private static double Area(double length, double width)
    {
        double area = length * width;
        return area;
    }

    private static double Perimeter(double length, double width)
    {
        double perimeter = 2 * (length + width);
        return perimeter;
    }

    private static void PrintResult(double length, double width)
    {
        Console.WriteLine("The perimeter of this rectangle is {0} and its area is {1}.",
            Perimeter(length, width), Area(length, width));
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Enter the lenght of the rectangle:");
        double length = double.Parse(Console.ReadLine());
        //The use of "." will result an error. Proper way to enter the value is "3,4".
        Console.WriteLine("Enter the width of the rectangle:");
        double width = double.Parse(Console.ReadLine());
        PrintResult(length, width);
        Console.WriteLine("Condition numbers:");
        PrintResult(3, 4); //test with condition numbers.
        PrintResult(2.5, 3);
        PrintResult(5, 5);
    }
}