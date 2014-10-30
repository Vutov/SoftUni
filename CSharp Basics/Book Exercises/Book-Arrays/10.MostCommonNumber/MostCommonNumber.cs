using System;

class MostCommonNumber
{
    static void Main(string[] args)
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Array.Sort(array);
        int count = 1;
        int savedCount = 0;
        int len = array.Length;
        for (int i = 0; i < len - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                count++;
            }
            else
            {
                if (count > savedCount)
                {
                    savedCount = count;
                }
                count = 1;
            }
        }
        if (savedCount > count)
        {
            count = savedCount;
        }
        Console.WriteLine(count);
    }
}

//Напишете програма, която намира най-често срещания елемент в
//масив. Пример: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (среща се 5
//пъти).