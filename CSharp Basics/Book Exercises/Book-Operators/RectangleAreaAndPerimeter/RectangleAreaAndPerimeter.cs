using System;

class RectangleAreaAndPerimeter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the lenght of the rectangle:");
        int length = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the width of the rectangle:");
        int width = int.Parse(Console.ReadLine());
        int area = length * width;
        int perimeter = 2 * (length + width);
        Console.WriteLine("The area of this rectangle is {0} and its perimeter is {1}.",
            area, perimeter);
    }
}