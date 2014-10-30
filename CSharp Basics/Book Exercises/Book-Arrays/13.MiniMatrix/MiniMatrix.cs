using System;

class MiniMatrix
{
    static void Main(string[] args)
    {
        //to do - stuff read from console.
        int matrixCol = 5;
        int matrixRow = 7;
        //int[,] matrix = new int[col, row];
        int[,] matrix = 
        {
            {3, 4, 8, 9, 2},
            {2, 9, 7, 6, 3},
            {6, 8, 7, 6, 1},
            {3, 2, 4, 1, 5},
            {2, 5, 9, 1, 3},
            {2, 3, 2, 1, 2},
            {3, 4, 2, 1, 0}
        };
        int maxSum = 0;
        int savedSum = 0;
        int[,] savedNums = new int[3, 3];
        for (int row = 0; row < matrixRow - 3; row++)
        {
            
            for (int col = 0; col < matrixCol - 3; col++)
            {
                //first row;
                maxSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                //second row;
                maxSum += matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                //third row;
                maxSum += matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (maxSum > savedSum)
                {
                    savedSum = maxSum;
                    maxSum = 0;
                    //saving the 3x3 matrix;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            savedNums[i,j] = matrix[row + i, col + j];
                        }    
                    }
                }
                maxSum = 0;
            } 
        }
        //if maxSum is ever needed.
        //if (savedSum > maxSum)
        //{
        //    maxSum = savedSum;
        //}
        //Print result;
        for (int i = 0; i < 3; i++)
		{
			for (int g = 0; g < 3; g++)
			{
			    Console.Write(savedNums[i,g] + " ");
			}
            Console.WriteLine();
		}
    }
}

//Да се напише програма, която създава правоъгълна матрица с размер
//n на m. Размерността и елементите на матрицата да се четат от
//конзолата. Да се намери подматрицата с размер (3,3), която има
//максимална сума.
//4 8 9
//9 7 6
//8 7 6
