
using System;

class MaxProgressingLine
{
    static void Main(string[] args)
    {
        int[] line = { 3, 2, 3, 4, 2, 2, 4 };
        int sameNumCount = 1;
        int maxCount = 1;
        int? lastSameNum = null;
        int len = line.Length;
        for (int i = 0; i < len - 1; i++)
        {
            if (line[i] == line[i + 1] - 1)// -1 to check if 2 + 1 = 3
            {
                sameNumCount++;
                if (maxCount < sameNumCount)
                {
                    lastSameNum = line[i + 1];// to get the last of the line
                }
            }
            else
            {
                if (maxCount < sameNumCount)
                {
                    maxCount = sameNumCount;
                }
                sameNumCount = 1;

            }
        }
        if (maxCount < sameNumCount)
        {
            maxCount = sameNumCount;
        }
        string result = "";
        for (int i = maxCount - 1; i >= 0; i--)
        {
            result += (lastSameNum - i) + " ";
        }
        Console.WriteLine(result);
    }
}

//Напишете програма, която намира максималната редица от последователни нарастващи 
//елементи в масив. Пример: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.