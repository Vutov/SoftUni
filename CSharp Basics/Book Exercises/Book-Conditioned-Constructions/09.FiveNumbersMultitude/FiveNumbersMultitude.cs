using System;

class FiveNumbersMultitude
{
    static void Main(string[] args)
    {
        int[] numbers = { 3, -2, 1, 1, 8 };
        //int[] numbers = { 3, 1, -7, 35, 22 };
        int len = numbers.Length;
        for (int i = 0; i < len; i++)
        {
            int sum = 0;
            for (int j = 0 + i; j < len - i; j++)
            {
                sum += numbers[j];
                if (sum == 0)
                {
                    for (int k = i; k <= j; k++)
                    {
                        Console.WriteLine(numbers[k]);
                    }
                }
            }
        }
    }
}