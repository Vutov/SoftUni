using System;

class RandomizeNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        //Set numbers in order 1 to n;
        for (int i = 0; i < n; i++)
        {
            numbers[i] = i + 1;
        }
        //Randomize the numbers;
        Random rng = new Random();
        int len = 3 * n; //To ensure they will be randomized good;
        int swapper; //To swap the positions;
        for (int i = 0; i < len; i++)
        {
            int rand = rng.Next(0, n);
            swapper = numbers[0];
            numbers[0] = numbers[rand];
            numbers[rand] = swapper;
        }
        //Print the randomized numbers;
        for (int i = 0; i < n; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }
}
