using System;

class PointInFigures
{
    private static bool IsInsideCircle(double x, double y)
    {
        bool isInsideCircle = false;
        double radius = Math.Pow(1.5, 2); // using a^2 + b^2 = c^2
        double num = (Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2)); // using a^2 + b^2 = c^2
        //x and y - 1 is because the centre of the circle is 1, 1.
        //other way is to add to the radius
        if (num <= radius)
        {
            isInsideCircle = true;
        }
        return isInsideCircle;
    }

    private static bool IsInsideRectangle(double x, double y)
    {
        bool isInsideRectangle = false;
        if (x >= -1 && x <= 5 && y <= 1 && y >= -1) // rectangle has coordinats:
            // x is in range -1 to 5 and y is 1 to -1
            // than the point is outside it.
        {
            isInsideRectangle = true;
        }
        return isInsideRectangle;
    }

    private static bool Condition(double x, double y)
    {
        bool isInsideCircle = IsInsideCircle(x, y);
        bool isInsideRectangle = IsInsideRectangle(x, y);
        if (isInsideCircle == true && isInsideRectangle == true)
        {// if it is inside the rectangle and the circle it is not allowed, 
         //however in that case true && true == true, so we need to return false.
            return false;    
        }
        else
        {
            return isInsideCircle && !isInsideRectangle; // ! is used, if the first is
        //true than no matter what is the second it will be true, however if the second
        //is true, than acording to the condition of the problem the return value has to
        //be false. So the ! makes the second value false in all the times when the first
        //is false.
        }
       
    }

    private static void PrintCondition(double x, double y)
    {
        Console.WriteLine("Point x = " + x + "y = " + y + "is inside K & outside of R: " +
            (Condition(x, y)));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("x = ");
        double num1 = double.Parse(Console.ReadLine());
        Console.WriteLine("y = ");
        double num2 = double.Parse(Console.ReadLine());
        //the point has to be within the circle and out of the rectangle
        PrintCondition(num1, num2);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintCondition(1, 2);
        PrintCondition(2.5, 2);
        PrintCondition(0, 1);
        PrintCondition(2.5, 1);
        PrintCondition(2, 0);
        PrintCondition(4, 0);
        PrintCondition(2.5, 1.5);
        PrintCondition(2, 1.5);
        PrintCondition(1, 2.5);
        PrintCondition(-100, -100);

    }
}