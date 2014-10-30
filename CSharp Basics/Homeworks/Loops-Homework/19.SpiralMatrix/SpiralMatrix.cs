using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int y = 0;
        int x = 0;
        int direction = 1;
        double len = (int) Math.Pow(n, 2);//Total cells;

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
            //Set number in the cell;
            matrix[y, x] = i;

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
        //Print matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
 /*Write a program that reads from the console a positive integer
 * number n (1 ≤ n ≤ 20) and prints a matrix holding the numbers
 * from 1 to n*n in the form of square spiral like in the examples below.*/
