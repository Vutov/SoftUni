using System;

class FiveSpecialLetters
{
    private static string ClearDuplicates(string sequence)
    {
        int countA = 0;
        int countB = 0;
        int countC = 0;
        int countD = 0;
        int countE = 0;
        string clearedSeq = "";

        foreach (char letter in sequence)
        {
            switch (letter)
            {
                case 'a':
                    if (countA == 0)
                    {
                        clearedSeq += letter;
                    }
                    countA++;
                    break;
                case 'b':
                    if (countB == 0)
                    {
                        clearedSeq += letter;
                    }
                    countB++;
                    break;
                case 'c':
                    if (countC == 0)
                    {
                        clearedSeq += letter;
                    }
                    countC++;
                    break;
                case 'd':
                    if (countD == 0)
                    {
                        clearedSeq += letter;
                    }
                    countD++;
                    break;
                case 'e':
                    if (countE == 0)
                    {
                        clearedSeq += letter;
                    }
                    countE++;
                    break;
                //No default needed, only a - e can be here;
            }
        }
        return clearedSeq;
    }

    private static int GetWeight(string sequence)
    {
        int len = sequence.Length;
        int totalWeight = 0;
        for (int i = 0; i < len; i++)
        {
            char letter = sequence[i];
            int weight = 0;
            switch (letter)
            {
                case 'a':
                    weight = 5;
                    break;
                case 'b':
                    weight = -12;
                    break;
                case 'c':
                    weight = 47;
                    break;
                case 'd':
                    weight = 7;
                    break;
                case 'e':
                    weight = -32;
                    break;
                //No default needed, only a - e can be here;
            }
            totalWeight += (i + 1) * weight;
        }
        return totalWeight;
    }
    
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        string word = "";
        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        int count = 0;
        string result = "";

        for (int d1 = 0; d1 < 5; d1++)
        {
            for (int d2 = 0; d2 < 5; d2++)
            {
                for (int d3 = 0; d3 < 5; d3++)
                {
                    for (int d4 = 0; d4 < 5; d4++)
                    {
                        for (int d5 = 0; d5 < 5; d5++)
                        {
                            word += "" + letters[d1] + letters[d2] + letters[d3] +
                                letters[d4] + letters[d5];
                            int weight = GetWeight(ClearDuplicates(word));
                            if (weight >= start && weight <= end)
                            {
                                result += "" + word + " ";
                                count++;
                            }
                            word = "";//clear the word before next one;
                        }
                    }
                }
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(result);
        }

    }
}

//5 loops
//filter
//weight