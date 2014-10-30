using System;

class MaxLine
{
    static void Main(string[] args)
    {
        int[] line = {2, 3, 5, 6, 7, -1, 9, 5, -1, -1 };
        int sameNumCount = 1;
        int maxCount = 1;
        int? lastSameNum = null;
        int len = line.Length;
        for (int i = 0; i < len - 1; i++)
        {
            if (line[i] == line[i + 1])
            {
                sameNumCount++;
                if (maxCount < sameNumCount)
                {
                    lastSameNum = line[i];
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
        for (int i = 0; i < maxCount; i++)
        {
            result += lastSameNum + " ";
        }
        Console.WriteLine(result);
    }
}

//Напишете програма, която намира максимална редица от последова-телни 
//еднакви елементи в масив. Пример: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.