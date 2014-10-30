using System;

class RandomNumbersInRange
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        max += 1;//max in random is exclusive;
        Random rng = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomNum = rng.Next(min, max);
            Console.Write(randomNum + " ");
        }
        Console.WriteLine();
    }
}
//Write a program that enters 3 integers n, min and max (min ≤ max) 
//and prints n random numbers in the range [min...max]. Examples:
