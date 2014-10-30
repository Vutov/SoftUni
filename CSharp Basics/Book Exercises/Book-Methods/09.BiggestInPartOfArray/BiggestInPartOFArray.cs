using System;

class BiggestInPartOFArray
{
    private static int FindBiggest(int[] array, int startIndex, int endIndex)
    {
        int len = array.Length;
        if (startIndex < 0 || startIndex > len - 1 || endIndex < startIndex || endIndex >= len)
        {
            throw new ArgumentOutOfRangeException("Index is out of range! Check your input and try again.");   
        }
        if (endIndex == 0)
        {
            endIndex = len - 1;//if 0 - no end index given
        }
        int biggest = int.MinValue;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (array[i] > biggest)
            {
                biggest = array[i];
            }
        }
        if (biggest == int.MinValue)
        {
            return 0;
        }
        else
        {
            return biggest;
        }
        
    }
    
    static void Main(string[] args)
    {
        int[] testArray = { 1, 2, 3, 5, 15, 67, 1, 2, 3, 5, 5 };
        // 0 and 0 for max range
        Console.WriteLine(FindBiggest(testArray, 3, 80));
    }
}