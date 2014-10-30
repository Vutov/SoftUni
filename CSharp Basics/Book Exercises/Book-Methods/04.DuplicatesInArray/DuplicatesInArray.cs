using System;

class DuplicatesInArray
{
    private static int CountDuplicates(int[] numbers)
    {
        int count = 1;//current count.
        int savedCount = new int();//biggest count seen.
        int len = numbers.Length;
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 1 + i; j < len; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    count++;
                }
            }
            if (count > savedCount)
            {
                savedCount = count;
                count = 1;
            }
            else
            {
                count = 1;
            }
        }
        if (len == 0)
        {
            return 0;
        }
        else if (count > savedCount)
        {
            return count;
        }
        else //len > 0, count < savedCount
        {
            return savedCount;
        }
    }

    
    static void Main(string[] args)
    {
        int[] testArray = { 1, 2, 3, 45, 6, 7, 12, 1, 1 };
        Console.WriteLine(CountDuplicates(testArray));
    }
}