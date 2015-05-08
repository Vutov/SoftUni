using System;
using System.Collections.Generic;
using System.Text;

class PlusRemove
{
    static void Main(string[] args)
    {
        //Judge mi dava 88/100 tochki
        //UTF8Encoding utf8 = new UTF8Encoding();
        var matrix = new List<char[]>();
        var finalMatrix = new List<char[]>();
        string input;
        int row = 0;
        while (!((input = Console.ReadLine()) == "END"))
        {
            matrix.Add(new char[input.Length]);
            matrix[row] = input.ToLower().ToCharArray();
            finalMatrix.Add(new char[input.Length]);
            finalMatrix[row] = input.ToCharArray();
            row++;
        }
        for (row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                PlusCheck(matrix, finalMatrix, row, col);
            }
        }
        foreach (var symbolsList in finalMatrix)
        {
            foreach (var symbol in symbolsList)
            {
                if (symbol != 'п')
                {
                    Console.Write(symbol);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine('.');
    }

    private static void PlusCheck(List<char[]> matrix, List<char[]> finalMatrix, int row, int col)
    {
        char symbol = matrix[row][col];
        if ((row - 1 >= 0 && matrix[row - 1].Length > col && matrix[row - 1][col] == symbol) &&
            (row + 1 < matrix.Count && matrix[row + 1].Length > col && matrix[row + 1][col] == symbol) &&
            (col - 1 >= 0 && matrix[row][col - 1] == symbol) &&
            (col + 1 < matrix[row].Length && matrix[row][col - 1] == symbol))
        {
            finalMatrix[row][col] = 'п';
            finalMatrix[row - 1][col] = 'п';
            finalMatrix[row + 1][col] = 'п';
            finalMatrix[row][col - 1] = 'п';
            finalMatrix[row][col + 1] = 'п';
        }
    }
}