using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpiralMatrix
{
    static void Main(string[] args)
    {
        //Modified 19.SpiralMatrix from Loops-Homework
        int n = int.Parse(Console.ReadLine());
        string word = Console.ReadLine();
        word = word.ToLower();
        int count = -1;
        char[,] matrix = new char[n, n];
        int y = 0;
        int x = 0;
        int direction = 1;
        double len = (int)Math.Pow(n, 2);//Total cells;

        for (int i = 1; i <= len; i++)
        {
            //Check if going out of the matrix or cell used -> change directions;
            if (direction == 1 && (x > n - 1 || matrix[y, x] != 0))
            {
                direction = 2;
                x--;
                y++;
            }
            else if (direction == 2 && (y > n - 1 || matrix[y, x] != 0))
            {
                direction = 3;
                y--;
                x--;
            }
            else if (direction == 3 && (x < 0 || matrix[y, x] != 0))
            {
                direction = 4;
                x++;
                y--;
            }
            else if (direction == 4 && (y < 0 || matrix[y, x] != 0))
            {
                direction = 1;
                y++;
                x++;
            }
            //Set letter in the cell;
            count++;
            if (count == word.Length)
            {
                count = 0;
            }
            matrix[y, x] = word[count];

            //Keep going in the current direction;
            if (direction == 1)//Right;
            {
                x++;
            }
            else if (direction == 2)//Down;
            {
                y++;
            }
            else if (direction == 3)//Left;
            {
                x--;
            }
            else //4 -> Up;
            {
                y--;
            }
        }
        //Print matrix;
        //for (int row = 0; row < n; row++)
        //{
        //    for (int col = 0; col < n; col++)
        //    {
        //        Console.Write("{0,4}", matrix[row, col]);
        //    }
        //    Console.WriteLine();
        //}

        //Get weights;
        int bextRowNum = 0;
        int bextRowSum = 0;
        for (int row = 0; row < n; row++)
        {
            int currentRowSum = 0;
            for (int col = 0; col < n; col++)
            {
                char letter = matrix[row, col];
                currentRowSum += letterWeight(letter);
            }
            if (currentRowSum > bextRowSum)
            {
                bextRowSum = currentRowSum;
                bextRowNum = row;
            }
        }

        //Result;
        Console.WriteLine("{0} - {1}", bextRowNum, bextRowSum);
    }

    private static int letterWeight(char letter)
    {
        int weight = (letter - 'a' + 1) * 10;

        return weight;
    }
}
