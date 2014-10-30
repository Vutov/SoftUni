using System;

class WeightOnMoon
{
    static void Main(string[] args)
    {
        int weight = int.Parse(Console.ReadLine());
        double weightOnMoon = 0.17 * weight;
        Console.WriteLine(weightOnMoon);
    }
}