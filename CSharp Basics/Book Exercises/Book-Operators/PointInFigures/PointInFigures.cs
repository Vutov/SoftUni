using System;
// v doma6noto q ima dobre obqsnena i re6ena doma6tno nomer 3!
class PointInFigures
{
    static void Main(string[] args)
    {
        Console.WriteLine("x = ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("y = ");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine("Radius = ");
        int radius = int.Parse(Console.ReadLine());
        bool isInsideCircumference = false;
        double num = (Math.Pow(x, 2) + (Math.Pow(y, 2));
        if (num <= Math.Pow(radius, 2))
        {
            isInsideCircumference = true;
        }
        bool isInsideRectangle = false;
        if (x > -1 && x < 5 && y > 1 && y < 5)
        {
            isInsideRectangle = true;
        }
        if (isInsideCircumference && isInsideRectangle)
        {
            Console.WriteLine("The point is inside both circumference and rectangle.");
        }
        else
        {
            Console.WriteLine("The point is outside.");
        }
    }
}