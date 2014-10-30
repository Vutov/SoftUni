using System;

class StringMatrix
{
    static void Main(string[] args)
    {
        string[,] words =
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"}
        };
        int savedCount = 0;
        int wordCount = 1;
        string savedWord = "";
        //search by row;
        for (int row = 0; row < words.GetLength(0); row++)
        {
            for (int col = 0; col < words.GetLength(1) - 1; col++)
            {
                //Console.WriteLine(words[row, col]);
                if (words[row, col] == words[row, col + 1])
                {
                    wordCount++;
                }
                else
                {
                    wordCount = 1;
                }
                if (wordCount > savedCount)
                {
                    savedCount = wordCount;
                }
            }
            wordCount = 1;
        }
        //search by col;
        for (int row = 0; row < words.GetLength(1); row++)
        {
            for (int col = 0; col < words.GetLength(0) - 1; col++)
            {
                //Console.WriteLine(words[col, row]);
                if (words[col, row] == words[col + 1, row])
                {
                    wordCount++;
                }
                else
                {
                    wordCount = 1;
                }
                if (wordCount > savedCount)
                {
                    savedCount = wordCount;
                }
            }
            wordCount = 1;
        }
        //diagonal
        //for (int g = 0; g < words.GetLength(0); g++)
        //{
        //    for (int i = 0; i < words.GetLength(0); i++)
        //    {
        //    Console.WriteLine(words[i + g, i - g]);
        //    }
        //}
        


        
    }
}


/*Да се напише програма, която намира най-дългата последователност
от еднакви string елементи в матрица. Последователност в матрица
дефинираме като елементите са на съседни и са на същия ред,колона
или диагонал.
ha fifi ho hi
fo ha hi xx
xxx ho ha xx
*/