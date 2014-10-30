using System;

class MaxKN
{
    static void Main(string[] args)
    {
        //n array
        int n = int.Parse(Console.ReadLine());
        int[] arrayN = new int[n];
        int k = int.Parse(Console.ReadLine());
        //adding to arrayN
        for (int i = 0; i < n; i++)
        {
            arrayN[i] = int.Parse(Console.ReadLine());
        }

        int savedSum = 0;
        int maxSum = 0;
        int[] bestNums = new int[k];
        int[] savedNums = new int[k];
        for (int i = 0; i <= n - k; i++)
        {
            if (maxSum > savedSum) //saving best so far
            {
                savedSum = maxSum;
                maxSum = 0;
                for (int j = 0; j < k; j++)
                {
                    savedNums[j] = bestNums[j];
                }
            }
            else
            {
                maxSum = 0;
            }
            for (int j = 0; j < k; j++)
            {
                maxSum += arrayN[i + j];
                bestNums[j] = arrayN[i + j];
            }
        }
        if (savedSum > maxSum)
        {
            Console.Write("Max sum: {0} of numbers: ", savedSum);
            for (int i = 0; i < k; i++)
            {
                Console.Write(savedNums[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.Write("Max sum: {0} of numbers: ", maxSum);
            for (int i = 0; i < k; i++)
            {
                Console.Write(bestNums[i] + " ");
            }
            Console.WriteLine();
        }
        
    }
}


//Да се напише програма, която чете от конзолата две цели числа N и K (K<N),
//и масив от N елемента. Да се намерят тези K поредни елемента, които имат максимална сума.