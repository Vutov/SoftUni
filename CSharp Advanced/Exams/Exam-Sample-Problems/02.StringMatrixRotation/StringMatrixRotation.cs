using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringMatrixRotation
{
    private static List<List<char>> Rotate(List<List<char>> matrix)
    {
        var result = new List<List<char>>();
        int currRow = 0;
        for (int i = 0; i < matrix[0].Count; i++)
        {
            result.Add(new List<char>());
            for (int j = matrix.Count - 1; j >= 0; j--)
            {
                result[currRow].Add(matrix[j][i]);
            }
            currRow++;
        }

        return result;
    }

    private static void PrintMatrix(List<List<char>> matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("", row));
        }
    }

    static void Main(string[] args)
    {
        int rotation = int.Parse(Console.ReadLine().Replace("Rotate(", "").Replace(")", ""));
        
        // Fill matrix;
        string line = Console.ReadLine();
        var matrix = new List<List<char>>();
        int longest = 0;
        while (!line.Equals("END"))
        {
            matrix.Add(line.ToList());
            int currLen = line.Length;
            if (currLen > longest)
            {
                longest = currLen;
            }

            line = Console.ReadLine();
        }

        // Make matrix rectangle;
        for (int i = 0; i < matrix.Count; i++)
        {
            var row = matrix[i];
            if (row.Count < longest)
            {
                while (row.Count < longest)
                {
                    row.Add(' ');
                }
            }
        }

        // Rotate
        rotation = rotation / 90;
        rotation = rotation % 4;
        for (int i = 0; i < rotation; i++)
        {
            matrix = Rotate(matrix);
        }

        // Print matrix;
        PrintMatrix(matrix);
    }
}
