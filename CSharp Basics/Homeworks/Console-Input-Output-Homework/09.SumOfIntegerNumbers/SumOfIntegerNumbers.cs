using System;
// float and double's are entered with "," in the console
class SumOfIntegerNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many number will you enter?");
        double n = double.Parse(Console.ReadLine());
        double sum = new double();
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Please enter number{0} :", i);
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("Sum of the numbers is " + sum);
    }
}
