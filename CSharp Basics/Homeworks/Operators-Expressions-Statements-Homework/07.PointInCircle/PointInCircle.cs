using System;

class PointInCircle
{

    private static bool IsInsideCircle(double x, double y)
    {
        bool isInsideCircle = false;
        double radius = Math.Pow(2, 2); // using a^2 + b^2 = c^2
        double num = (Math.Pow(x, 2) + Math.Pow(y, 2)); // using a^2 + b^2 = c^2
        //x and y - 1 is because the centre of the circle is 1, 1.
        //other way is to add to the radius
        if (num <= radius)
        {
            isInsideCircle = true;
        }
        return isInsideCircle;
    }

    private static void PrintIsInside(double x, double y)
    {
        Console.WriteLine("(" + x + "," + y + ") is inside: " + IsInsideCircle(x, y));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("x = ");
        double num1 = double.Parse(Console.ReadLine());
        Console.WriteLine("y = ");
        double num2 = double.Parse(Console.ReadLine());
        PrintIsInside(num1, num2);
        Console.WriteLine("Condition numbers:");
        PrintIsInside(0, 1); //test with condition numbers.
        PrintIsInside(-2, 0);
        PrintIsInside(-1, 2);
        PrintIsInside(1.5, -1);
        PrintIsInside(-1.5, -1.5);
        PrintIsInside(100, -30);
        PrintIsInside(0, 0);
        PrintIsInside(0.2, -0.8);
        PrintIsInside(-0.9, -1.93);
        PrintIsInside(1, 1.655); 

    }
}