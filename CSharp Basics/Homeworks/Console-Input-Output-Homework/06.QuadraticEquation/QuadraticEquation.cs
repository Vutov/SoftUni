using System;
// float and double's are entered with "," in the console
class QuadraticEquation
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter c:");
        double c = double.Parse(Console.ReadLine());
        double firstRoot = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
        double secondRoot = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
        if (firstRoot.ToString() == "NaN" && secondRoot.ToString() == "NaN")
        {
            Console.WriteLine("no real roots");
        }
        else
        {
            Console.WriteLine("x1 = {0}, x2 = {1}", firstRoot, secondRoot);
        }
    }
}