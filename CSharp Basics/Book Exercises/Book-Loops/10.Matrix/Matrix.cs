using System;

class Matrix
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter value for n:");
        int n = int.Parse(Console.ReadLine());
        int col = n;
        int row = n;
        int count = new int();
        for (int i = 1; i <= col; i++)
        {
            for (int j = 1; j <= row; j++)
            {
                Console.Write(j + count + " ");
            }
            count++;
            Console.WriteLine();
        }
    }
}