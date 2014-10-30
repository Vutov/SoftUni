using System;

class MatrixB
{
    static void Main(string[] args)
    {
        //int matrixSize = int.Parse(Console.ReadLine());
        int matrixSize = 4;
        int[,] matrix = new int[matrixSize, matrixSize];
        int numInside = 1;
        bool flipper = true;
        //set matrix;
        for (int row = 0; row < matrixSize; row++)
        {
            if (flipper)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[col, row] = numInside;
                    numInside++;
                    flipper = false;
                }
            }
            else
            {
                for (int col = matrixSize - 1; col >= 0; col--)
                {
                    matrix[col, row] = numInside;
                    numInside++;
                    flipper = true;
                }
            }
        }
        for (int i = 0; i < matrixSize; i++)
		{
			 for (int j = 0; j < matrixSize; j++)
			 {
                 string number = "" + matrix[i, j];
                Console.Write("{0} ", number.PadRight(2, ' '));
             }
            Console.WriteLine();
        }
	}
}                
