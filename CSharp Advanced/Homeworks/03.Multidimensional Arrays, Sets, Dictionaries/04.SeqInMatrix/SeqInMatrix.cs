using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeqInMatrix
{
    private static void PrintWords(string word, int len)
    {
        var words = new List<string>();
        for (int i = 0; i < len; i++)
        {
            words.Add(word);
        }

        Console.WriteLine(String.Join(", ", words));
    }

    private static void RowSearch(string[,] matrix)
    {
        int maxLen = 1;
        string word = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int currLen = 1;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j].Equals(matrix[i, j + 1]))
                {
                    currLen++;
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        word = matrix[i, j];
                    }
                }
            }
        }

        PrintWords(word, maxLen);
    }

    private static void ColSearch(string[,] matrix)
    {
        int maxLen = 1;
        string word = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int currLen = 1;
            for (int j = 0; j < matrix.GetLength(0) - 1; j++)
            {
                if (matrix[j, i].Equals(matrix[j + 1, i]))
                {
                    currLen++;
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        word = matrix[j, i];
                    }
                }
            }
        }

        PrintWords(word, maxLen);
    }

    private static void DiagonalSearch(string[,] matrix)
    {
        int maxLen = 1;
        string word = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            int currLen = 1;
            for (int j = i; j < matrix.GetLength(0) - 1; j++)
            {
                if (matrix[j, j].Equals(matrix[j + 1, j + 1]))
                {
                    currLen++;
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        word = matrix[j, j];
                    }
                }
            }
        }

        PrintWords(word, maxLen);
    }

    static void Main(string[] args)
    {
        string[,] matrix1 =
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"},
        };
        string[,] matrix2 =
        {
            {"s", "qq", "s"},
            {"pp", "pp", "s"},
            {"pp", "qq", "s"},
        };
        RowSearch(matrix1);
        ColSearch(matrix1);
        DiagonalSearch(matrix1);
        Console.WriteLine("--------");
        RowSearch(matrix2);
        ColSearch(matrix2);
        DiagonalSearch(matrix2);
    }
}
