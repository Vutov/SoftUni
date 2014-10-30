using System;

class StrangeSequence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter value for n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for x:");
        int x = int.Parse(Console.ReadLine());
        int factorial = 1;
        double sum = 1;
        int power = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += (factorial / Math.Pow(x, power));
            power++;
        }
        Console.WriteLine("{0:F}", sum);
    }
}
