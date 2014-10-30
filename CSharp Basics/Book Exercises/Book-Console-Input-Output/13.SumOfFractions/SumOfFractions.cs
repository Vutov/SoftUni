using System;

class SumOfFractions
{
    static void Main(string[] args)
    {
        float one = 1f;
        float devider = 1f;
        double sum = 1; 
        while (one / devider >= 0.001)
        {
            sum += one / devider;
            devider++;
        }
        Console.WriteLine("The result is {0:f3}.", sum);
    }
}