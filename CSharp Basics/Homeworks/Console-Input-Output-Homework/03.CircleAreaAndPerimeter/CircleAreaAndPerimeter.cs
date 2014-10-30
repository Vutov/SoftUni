using System;
// float and double's are entered with "," in the console
class CircleAreaAndPerimeter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter radius:");
        double r = float.Parse(Console.ReadLine());
        double area = Math.PI * Math.Pow(r, 2);
        double perimeter = 2 * Math.PI * r;
        Console.WriteLine("Perimeter = {0:F2}\nArea = {1:F2}", perimeter, area);
    }
}