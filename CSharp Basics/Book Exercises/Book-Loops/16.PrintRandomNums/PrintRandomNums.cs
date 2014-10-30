using System;

class PrintRandomNums
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter n:");
        int number = int.Parse(Console.ReadLine());
        int[] numbers = new int[number];
        for (int i = 1; i <= number; i++)
        {
            numbers[i - 1] = i;
        }
        int randomizing = 3 * number;
        Random rng = new Random();
        for (int j = 0; j < randomizing; j++)
        {
            int position = rng.Next(0, number);
            int saver = numbers[0];
            numbers[0] = numbers[position];
            numbers[position] = saver;
        }
        foreach (int digit in numbers)
        {
            Console.WriteLine(digit);
        }
    }
}