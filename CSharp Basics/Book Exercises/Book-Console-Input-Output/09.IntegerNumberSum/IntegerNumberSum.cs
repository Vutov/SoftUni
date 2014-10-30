using System;

class IntegerNumberSum
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many number will you enter?");
        int n = int.Parse(Console.ReadLine());
        int sum = new int();
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Please enter number{0} :", i);
            int number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("Sum of the numbers is " + sum);
    }
}