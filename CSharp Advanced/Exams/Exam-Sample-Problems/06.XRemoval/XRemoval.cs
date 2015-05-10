using System;
using System.Collections.Generic;
using System.Linq;

class XRemoval
{
    static void Main(string[] args)
    {
        // Fill matrix;
        var originalMatrix = new List<List<char>>();
        var result = new List<List<char>>();
        string line = Console.ReadLine();
        int longest = 0;
        while (!line.Equals("END"))
        {
            originalMatrix.Add(line.ToList());
            result.Add(line.ToList());
            int currLen = line.Length;
            if (currLen > longest)
            {
                longest = currLen;
            }

            line = Console.ReadLine();
        }

        // Make matrix rectangle;
        for (int i = 0; i < originalMatrix.Count; i++)
        {
            var row = originalMatrix[i];
            if (row.Count < longest)
            {
                while (row.Count < longest)
                {
                    row.Add('п');
                    result[i].Add('п');
                }
            }
        }

        // Search Matrix;
        for (int i = 0; i < originalMatrix.Count - 2; i++)
        {
            for (int j = 0; j < longest - 2; j++)
            {
                if (originalMatrix[i][j].ToString().ToLower().Equals(originalMatrix[i][j + 2].ToString().ToLower()) &&
                    originalMatrix[i][j].ToString().ToLower().Equals(originalMatrix[i + 1][j + 1].ToString().ToLower()) &&
                    originalMatrix[i][j].ToString().ToLower().Equals(originalMatrix[i + 2][j].ToString().ToLower()) &&
                    originalMatrix[i][j].ToString().ToLower().Equals(originalMatrix[i + 2][j + 2].ToString().ToLower()))
                {
                    result[i][j] = 'п';
                    result[i][j + 2] = 'п';
                    result[i + 1][j + 1] = 'п';
                    result[i + 2][j] = 'п';
                    result[i + 2][j + 2] = 'п';
                }
            }
        }

        // Clear result matrix;
        for (int i = 0; i < result.Count; i++)
        {
            while (result[i].IndexOf('п') != -1)
            {
                result[i].Remove('п');
            }
        }

        // Print matrix;
        foreach (var row in result)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}
