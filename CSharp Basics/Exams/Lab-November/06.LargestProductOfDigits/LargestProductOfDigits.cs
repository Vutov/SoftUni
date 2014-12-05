using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargestProductOfDigits
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int len = input.Length;
        int[] digits = new int[len];
        for (int i = 0; i < len; i++)
        {
            digits[i] = input[i] - '0';
        }
        len -= 5;
        int maxSum = int.MinValue;
        int currentSum = 0;
        for (int i = 0; i < len; i++)
        {
            currentSum =
                digits[i] * digits[i + 1] * digits[i + 2] *
                digits[i + 3] * digits[i + 4] * digits[i + 5];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
            currentSum = 0;
        }
        Console.WriteLine(maxSum);
    }
}
