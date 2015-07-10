namespace ConsoleApplication1
{
    using System;

    public class MatrixMultiplication
    {
        public static void Main(string[] args)
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var result = MultiplyMatrixes(firstMatrix, secondMatrix);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write(result[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplyMatrixes(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("Rows of the first matrix must be the same size as cols of the second matrix!");
            }

            var firstMatrixRows = firstMatrix.GetLength(1);
            var newMultipliedMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int row = 0; row < newMultipliedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < newMultipliedMatrix.GetLength(1); col++)
                {
                    for (int firstMatrixRow = 0; firstMatrixRow < firstMatrixRows; firstMatrixRow++)
                    {
                        newMultipliedMatrix[row, col] += firstMatrix[row, firstMatrixRow] * secondMatrix[firstMatrixRow, col];
                    }
                }
            }

            return newMultipliedMatrix;
        }
    }
}