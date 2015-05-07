using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main(string[] args)
    {
        int[] dementions = Regex.Split(Console.ReadLine(), "\\s+").Select(int.Parse).ToArray();
        var matrix = new List<List<int>>();

        //Fill matrix;
        for (int i = 0; i < dementions[0]; i++)
        {
            matrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }

        //Find biggest sum;
        int maxSum = int.MinValue;
        int[] pos = new int[2];
        for (int i = 0; i < dementions[0] - 2; i++)
        {
            int currSum = 0;
            for (int j = 0; j < dementions[1] - 2; j++)
            {
                currSum =
                    matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] +
                    matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2] +
                    matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    pos[0] = i;
                    pos[1] = j;
                }
            }
        }

        //Print sum;
        Console.WriteLine("Sum = {0}",maxSum);
        for (int i = pos[0]; i < pos[0] + 3; i++)
        {
            for (int j = pos[1]; j < pos[1] + 3; j++)
            {
                Console.Write("{0,3}",matrix[i][j]);
            }
            Console.WriteLine();
        }
    }
}
