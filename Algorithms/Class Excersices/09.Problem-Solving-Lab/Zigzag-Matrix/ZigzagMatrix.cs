namespace Zigzag_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZigzagMatrix
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());

            int[][] matrix = new int[numberOfRows][];
            ReadMatrix(numberOfRows, matrix);

            int[,] maxPaths = new int[numberOfRows, numberOfColumns];
            int[,] previusRowIndex = new int[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                maxPaths[row, 0] = matrix[row][0];
            }

            for (int col = 1; col < numberOfColumns; col++)
            {
                for (int row = 0; row < numberOfRows; row++)
                {
                    int previousMax = 0;
                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < numberOfRows; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previusRowIndex[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row - 1; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previusRowIndex[row, col] = i;
                            }
                        }
                    }

                    maxPaths[row, col] = previousMax + matrix[row][col];
                }
            }

            //for (int i = 0; i < numberOfRows; i++)
            //{
            //    for (int j = 0; j < numberOfColumns; j++)
            //    {
            //        Console.Write(previusRowIndex[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            var currentRowIndex = GetLastRowIndexOfPath(maxPaths, numberOfColumns);
            var path = RecoverMaxPath(numberOfColumns, matrix, currentRowIndex, previusRowIndex);
            Console.WriteLine("{0} = {1}", path.Sum(), string.Join(" + ", path));
        }

        private static void ReadMatrix(int numberOfRows, int[][] matrix)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static int GetLastRowIndexOfPath(int[,] maxPaths, int numberOfColumns)
        {
            int currentRowIndex = -1;
            int globalMax = 0;
            for (int row = 0; row < maxPaths.GetLength(0); row++)
            {
                if (maxPaths[row, numberOfColumns - 1] > globalMax)
                {
                    globalMax = maxPaths[row, numberOfColumns - 1];
                    currentRowIndex = row;
                }
            }

            return currentRowIndex;
        }

        private static List<int> RecoverMaxPath(
            int numberOfColumns,
            int[][] matrix,
            int rowIndex,
            int[,] previousRowIndex)
        {
            var path = new List<int>();
            int colIndex = numberOfColumns - 1;

            while (colIndex >= 0)
            {
                path.Add(matrix[rowIndex][colIndex]);
                rowIndex = previousRowIndex[rowIndex, colIndex];
                colIndex--;
            }

            path.Reverse();

            return path;
        }
    }
}