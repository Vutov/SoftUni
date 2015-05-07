using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixShuffling
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
        string input = Console.ReadLine();
        while (!input.Equals("END"))
        {
            string[] data = input.Split(' ');
            if (data.Length != 5)
            {
                Console.WriteLine("Invalid input!");
                input = Console.ReadLine();
                continue;
            }

            int firstRow = int.Parse(data[1]);
            int firstCol = int.Parse(data[2]);
            int secondRow = int.Parse(data[3]);
            int secondCol = int.Parse(data[4]);
            if (!data[0].Equals("swap") ||
                firstRow < 0 || firstRow > rows - 1 ||
                firstCol < 0 || firstCol > cols - 1 ||
                secondRow < 0 || secondRow > rows - 1 ||
                secondCol < 0 || secondCol > cols - 1)
            {
                Console.WriteLine("Invalid input!");
                input = Console.ReadLine();
                continue;
            }

            string tmp = matrix[firstRow, firstCol];
            matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
            matrix[secondRow, secondCol] = tmp;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            input = Console.ReadLine();
        }
    }
}
