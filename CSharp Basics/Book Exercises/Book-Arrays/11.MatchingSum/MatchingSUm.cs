using System;

class MatchingSum
{
    static void Main(string[] args)
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        //int neededSum = 8;
        int neededSum = int.Parse(Console.ReadLine());
        int len = array.Length;
        int actualSum = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                actualSum += array[j];
                if (actualSum == neededSum)
                {
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(array[k] + " ");
                    }
                    Console.WriteLine();
                }
            }
            actualSum = 0;
        }
    }
}


//Да се напише програма, която намира последователност от числа в
//масив, които имат сума равна на число, въведено от конзолата (ако
//има такава). Пример: {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}.