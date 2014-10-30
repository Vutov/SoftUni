using System;

class SelectionSort
{
    
    static void Main(string[] args)
    {
        int[] unsortedArray = { 4, 5, 0, 1, 2, 3, 9, 532, 1312312, 4 };
        int len = unsortedArray.Length;
        int[] sortedArray = new int[len];

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (unsortedArray[j] < unsortedArray[i])
                {
                    int swapper = unsortedArray[i];
                    unsortedArray[i] = unsortedArray[j];
                    unsortedArray[j] = swapper;
                }
            }
        }
        for (int i = len - 1, j = 0; i >= 0; i--, j++)
			{
			    sortedArray[j] = unsortedArray[i];
			}
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(sortedArray[i]);
        }

    }
}
