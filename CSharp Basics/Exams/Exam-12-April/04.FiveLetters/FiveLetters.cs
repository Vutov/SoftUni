using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FiveLetters
{

    private static string clearDuplicates(string letters)
    {
        string finalLet = "";
        int countA = 0;
        int countB = 0;
        int countC = 0;
        int countD = 0;
        int countE = 0;
        foreach (char letter in letters)
        {
            switch (letter)
            {
                case 'a':
                    if (countA < 1)
                    {
                        finalLet += 'a';
                    }
                    countA++;
                    break;
                case 'b':
                    if (countB < 1)
                    {
                        finalLet += 'b';
                    }
                    countB++;
                    break;
                case 'c':
                    if (countC < 1)
                    {
                        finalLet += 'c';
                    }
                    countC++;
                    break;
                case 'd':
                    if (countD < 1)
                    {
                        finalLet += 'd';
                    }
                    countD++;
                    break;
                case 'e':
                    if (countE < 1)
                    {
                        finalLet += 'e';
                    }
                    countE++;
                    break;
            }
        }
        return finalLet;
    }

    private static int getWeight(string letters)
    {
        int weight = 0;
        int index = 0;
        foreach (char letter in letters)
        {
            index++;
            switch (letter)
            {
                case 'a':
                    weight += (5 * index);
                    break;
                case 'b':
                    weight += (-12 * index);
                    break;
                case 'c':
                    weight += (47 * index);
                    break;
                case 'd':
                    weight += (7 * index);
                    break;
                case 'e':
                    weight += (-32 * index);
                    break;
            }
        }
        return weight;
    }

    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int count = 0;
        string result = "";
        string[] letters = { "a", "b", "c", "d", "e" };
        int len = letters.Length;
        for (int d1 = 0; d1 < len; d1++)
        {
            for (int d2 = 0; d2 < len; d2++)
            {
                for (int d3 = 0; d3 < len; d3++)
                {
                    for (int d4 = 0; d4 < len; d4++)
                    {
                        for (int d5 = 0; d5 < len; d5++)
                        {
                            string word = "" + letters[d1] + letters[d2] + letters[d3] + letters[d4] + letters[d5];
                            int weight = getWeight(clearDuplicates(word));
                            if (weight >= start && weight <= end)
                            {
                                result += word + " ";
                                count++;
                            }
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