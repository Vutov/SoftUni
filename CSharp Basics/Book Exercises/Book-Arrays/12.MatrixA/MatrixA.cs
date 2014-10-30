using System;

class MatrixA
{
    static void Main(string[] args)
    {
        //int matrixSize = int.Parse(Console.ReadLine());
        int matrixSize = 4;
        int[,] matrix = new int[matrixSize,matrixSize];
        int numInside = 1;
        //set matrix;
        for (int row = 0; row < matrixSize; row++)
		{
            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row, col] = row + numInside;
                numInside += matrixSize;
                string number = "" + matrix[row, col];
                Console.Write("{0} ", number.PadRight(2,' '));
            }
            numInside = 1;
            Console.WriteLine();
		}
    }
}