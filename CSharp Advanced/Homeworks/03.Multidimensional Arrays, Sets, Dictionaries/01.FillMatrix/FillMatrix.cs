using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillMatrix
{
    private static int[,] FirstPattern(int n)
    {
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[j, i] = (j + 1) + i * n;
            }
        }

        return matrix;
    }

    private static int[,] SecondPattern(int n)
    {
        int[,] matrix = new int[n, n];
        int count = 1;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j, i] = count;
                    count++;
                }
            }
            else
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    matrix[j, i] = count;
                    count++;
                }
            }
        }

        return matrix;
    }

    private static void PrintMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] firstMatrix = FirstPattern(n);
        int[,] secondMatrix = SecondPattern(n);
        PrintMatrix(firstMatrix, n);
        Console.WriteLine("---------");
        PrintMatrix(secondMatrix, n);
    }
}

