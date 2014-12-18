using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tetris
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] dementions = input.Split(' ');
        int row = int.Parse(dementions[0]);
        int col = int.Parse(dementions[1]);

        string[] rows = new string[row];
        for (int i = 0; i < row; i++)
        {
            rows[i] = Console.ReadLine();
        }

        //I;
        int countI = 0;
        if (row >= 4)
        {
            for (int i = 0; i < row - 3; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if (rows[i][k] == 'o' && rows[i + 1][k] == 'o'
                        && rows[i + 2][k] == 'o' && rows[i + 3][k] == 'o')
                    {
                        countI++;
                    }
                }
            }
        }
        ////L;
        int countL = 0;
        if (row >= 3 && col >= 2)
        {
            for (int i = 0; i < row - 2; i++)
            {
                for (int k = 0; k < col - 1; k++)
                {
                    if (rows[i][k] == 'o' && rows[i + 1][k] == 'o'
                        && rows[i + 2][k] == 'o' && rows[i + 2][k + 1] == 'o')
                    {
                        countL++;
                    }
                }
            }
        }
        //J;
        int countJ = 0;
        if (row >= 3 && col >= 2)
        {
            for (int i = 0; i < row - 2; i++)
            {
                for (int k = 1; k < col; k++)
                {
                    if (rows[i][k] == 'o' && rows[i + 1][k] == 'o'
                        && rows[i + 2][k] == 'o' && rows[i + 2][k - 1] == 'o')
                    {
                        countJ++;
                    }
                }
            }
        }
        //O;
        int countO = 0;
        if (row >= 2 && col >= 2)
        {
            for (int i = 0; i < row - 1; i++)
            {
                for (int k = 0; k < col - 1; k++)
                {
                    if (rows[i][k] == 'o' && rows[i][k + 1] == 'o'
                        && rows[i + 1][k] == 'o' && rows[i + 1][k + 1] == 'o')
                    {
                        countO++;
                    }
                }
            }
        }
        //S;
        int countS = 0;
        if (row >= 2 && col >= 3)
        {
            for (int i = 0; i < row - 1; i++)
            {
                for (int k = 1; k < col - 1; k++)
                {
                    if (rows[i][k] == 'o' && rows[i][k + 1] == 'o'
                        && rows[i + 1][k] == 'o' && rows[i + 1][k - 1] == 'o')
                    {
                        countS++;
                    }
                }
            }
        }
        //Z;
        int countZ = 0;
        if (row >= 2 && col >= 3)
        {
            for (int i = 0; i < row - 1; i++)
            {
                for (int k = 0; k < col - 2; k++)
                {
                    if (rows[i][k] == 'o' && rows[i][k + 1] == 'o'
                        && rows[i + 1][k + 1] == 'o' && rows[i + 1][k + 2] == 'o')
                    {
                        countZ++;
                    }
                }
            }
        }
        //T;
        int countT = 0;
        if (row >= 2 && col >= 3)
        {
            for (int i = 0; i < row - 1; i++)
            {
                for (int k = 0; k < col - 2; k++)
                {
                    if (rows[i][k] == 'o' && rows[i][k + 1] == 'o'
                        && rows[i][k + 2] == 'o' && rows[i + 1][k + 1] == 'o')
                    {
                        countT++;
                    }
                }
            }
        }
        //Result;
        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", countI, countL, countJ, countO,
            countZ, countS, countT);


    }
}
