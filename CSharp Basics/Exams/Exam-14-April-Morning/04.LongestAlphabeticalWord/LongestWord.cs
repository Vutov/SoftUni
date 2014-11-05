using System;

class LongestWord
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        int size = int.Parse(Console.ReadLine());
        //string word = "nakov";
        //int size = 3;
        int wordLength = word.Length;
        int wordIndex = 0;
        char[,] matrix = new char[size, size];
        //set the word in the matrix;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                matrix[x, y] = word[wordIndex];
                wordIndex++;
                if (wordIndex >= wordLength)
                {
                    wordIndex = 0;
                }
            }
        }
        //test matrix;
        /*for (int i = 0; i < size; i++)
        {
            for (int k = 0; k < size; k++)
            {
                Console.Write(matrix[i, k]);
            }
            Console.WriteLine();
        }*/
        string max = "";
        string saved = "";
        
        
        //Search left;
        for (int x = 0; x < size; x++)
        {
            for (int y = size - 1; y > 1; y--)
            {
                char letter = matrix[x, y];
                char nextLetter = matrix[x, y - 1];

                if (letter < nextLetter)
                {
                    if (max.Length == 0)
                    {
                        max = letter + "" + nextLetter;
                    }
                    else
                    {
                        max += nextLetter;
                    }
                }
                else
                {
                    if (max.Length > saved.Length)
                    {
                        saved = max;
                    }
                    else if (max.Length == saved.Length)
                    {
                        if (max.CompareTo(saved) <= 0)
                        {
                            saved = max;
                        }
                    }
                    max = "";
                }
            }
            if (max.Length > saved.Length)
            {
                saved = max;
            }
            max = "";
        }
        //Search right;
        max = "";
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size - 1; y++)
            {
                char letter = matrix[x, y];
                char nextLetter = matrix[x, y + 1];

                if (letter < nextLetter)
                {
                    if (max.Length == 0)
                    {
                        max = letter + "" + nextLetter;
                    }
                    else
                    {
                        max += nextLetter;
                    }
                }
                else
                {
                    if (max.Length > saved.Length)
                    {
                        saved = max;
                    }
                    else if (max.Length == saved.Length)
                    {
                        if (max.CompareTo(saved) <= 0)
                        {
                            saved = max;
                        }
                    }
                    max = "";
                }
            }
            if (max.Length > saved.Length)
            {
                saved = max;
            }
            max = "";
        }
        //Search up;
        max = "";
        for (int x = 0; x < size; x++)
        {
            for (int y = size - 1; y > 1; y--)
            {
                char letter = matrix[y, x];
                char nextLetter = matrix[y - 1, x];

                if (letter < nextLetter)
                {
                    if (max.Length == 0)
                    {
                        max = letter + "" + nextLetter;
                    }
                    else
                    {
                        max += nextLetter;
                    }
                }
                else
                {
                    if (max.Length > saved.Length)
                    {
                        saved = max;
                    }
                    else if (max.Length == saved.Length)
                    {
                        if (max.CompareTo(saved) <= 0)
                        {
                            saved = max;
                        }
                    }
                    max = "";
                }
            }
            if (max.Length > saved.Length)
            {
                saved = max;
            }
            max = "";
        }
        //Search down;
        max = "";
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size - 1; y++)
            {
                char letter = matrix[y, x];
                char nextLetter = matrix[y + 1, x];

                if (letter < nextLetter)
                {
                    if (max.Length == 0)
                    {
                        max = letter + "" + nextLetter;
                    }
                    else
                    {
                        max += nextLetter;
                    }
                }
                else
                {
                    if (max.Length > saved.Length)
                    {
                        saved = max;
                    }
                    else if (max.Length == saved.Length)
                    {
                        if (max.CompareTo(saved) <= 0)
                        {
                            saved = max;
                        }
                    }
                    max = "";
                }
            }
            if (max.Length > saved.Length)
            {
                saved = max;
            }
            max = "";
        }
        if (size == 1 || word.Length == 1)
        {
            Console.WriteLine(word[0]);
        }
        else
        {
            Console.WriteLine(saved);
        }
        
    }
}
// unicodove za alfareda
//matrica za vkarvane na danni.