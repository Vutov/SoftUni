using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class FunWithMatrix
{
    static void Main(string[] args)
    {
        double startingNumber = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        
        //Make the matrix;
        double[,] funMatrix = new double[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                funMatrix[row, col] = startingNumber;
                startingNumber += step;
            }
        }

        //Test;
        //for (int i = 0; i < 4; i++)
        //{
        //    for (int k = 0; k < 4; k++)
        //    {
        //        Console.Write(funMatrix[i, k] + " ");
        //    }
        //    Console.WriteLine();
        //}

        //Commands;
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "Game Over!")
            {
                break;
            }
            string[] commands = command.Split(' ');
            int row = int.Parse(commands[0]);
            int col = int.Parse(commands[1]);
            double num = double.Parse(commands[3]);
            //Console.WriteLine("---------BEFORE---------");
            //Console.WriteLine(funMatrix[row, col]);
            switch (commands[2])
            {
                case "multiply": funMatrix[row, col] = funMatrix[row, col] * num; break;
                case "sum": funMatrix[row, col] = funMatrix[row, col] + num; break;
                case "power": funMatrix[row, col] = Math.Pow(funMatrix[row, col], num); break;
            }
            //Console.WriteLine("--------AFTER---------");
            //Console.WriteLine(funMatrix[row, col]);
        }

        //Sums;
        //Row sum;
        double maxRowSum = double.MinValue;
        int bestRow = 0;
        for (int row = 0; row < 4; row++)
        {
            double currentRowSum = 0;
            for (int col = 0; col < 4; col++)
            {
                currentRowSum += funMatrix[row, col];
            }
            if (currentRowSum > maxRowSum)
            {
                maxRowSum = currentRowSum;
                bestRow = row;
            }
        }

        //Col sum;
        double maxColSum = double.MinValue;
        int bestCol = 0;
        for (int col = 0; col < 4; col++)
        {
            double currentColSum = 0;
            for (int row = 0; row < 4; row++)
            {
                currentColSum += funMatrix[row, col];
            }
            if (currentColSum > maxColSum)
            {
                maxColSum = currentColSum;
                bestCol = col;
            }
        }

        //Left-Diagonal;
        double leftDiagonal = funMatrix[0, 0] + funMatrix[1, 1] + 
            funMatrix[2, 2] + funMatrix[3, 3];

        //Right-Diagonal;
        double rightDiagonal = funMatrix[3, 0] + funMatrix[2, 1] +
            funMatrix[1, 2] + funMatrix[0, 3];

        //Getting the biggest;
        double biggestSum = Math.Max(Math.Max(maxRowSum, maxColSum), Math.Max(leftDiagonal, rightDiagonal));

        //Print;
        if (biggestSum == maxRowSum)
        {
            Console.WriteLine("ROW[{0}] = {1:F}", bestRow, maxRowSum);
        }
        else if (biggestSum == maxColSum)
        {
            Console.WriteLine("COLUMN[{0}] = {1:F}", bestCol, maxColSum);
        }
        else if (biggestSum == leftDiagonal)
        {
            Console.WriteLine("LEFT-DIAGONAL = {0:F}", leftDiagonal);
        }
        else //RightDiagonal;
        {
            Console.WriteLine("RIGHT-DIAGONAL = {0:F}", rightDiagonal);
        }
    }
}