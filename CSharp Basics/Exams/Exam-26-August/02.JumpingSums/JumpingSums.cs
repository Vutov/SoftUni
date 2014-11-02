using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JumpingSums
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //string input = "1 2 3 5";
        int[] numbers = Array.ConvertAll(input.Split(' '), int.Parse);
        int jumps = int.Parse(Console.ReadLine());
        //int jumps = 4;
        int maxSum = int.MinValue;

        int len = numbers.Length;
        for (int i = 0; i < len; i++)
        {
            int index = i;
            int currentSum = numbers[index];
            for (int jump = 0; jump < jumps; jump++)
            {
                index += numbers[index];
                if (index > len - 1)
                {
                    index %= len;
                }
                currentSum += numbers[index];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
        Console.WriteLine("max sum = {0}", maxSum);
        
    }
}
