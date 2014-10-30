using System;

class MaxSumInArray
{
    static void Main(string[] args)
    {
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int len = array.Length;
        int savedSum = 0;
        int maxSum = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                maxSum += array[j];
            }
            if (maxSum > savedSum)
            {
                savedSum = maxSum;
            }
            maxSum = 0;
        }
        if (savedSum > maxSum)
        {
            maxSum = savedSum;
        }
        Console.WriteLine("Max sum is {0}.", maxSum);
    }
}

//Напишете програма, която намира последователност от числа, чиито
//сума е максимална. Пример: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  11