using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddOrEvenCounter
{
    static void Main(string[] args)
    {
        int countSets = int.Parse(Console.ReadLine());
        int numPerSet = int.Parse(Console.ReadLine());
        string word = Console.ReadLine(); //what to count
        bool countOdd = false;
        if (word == "odd")
        {
            countOdd = true;
        }
        int oddCount = 0;
        int evenCount = 0;
        int savedSetOdd = 0;
        int savedSetEven = 0;
        for (int i = 0; i < countSets; i++)
        {
            int currentOddCount = 0;
            int currentEvenCount = 0;
            for (int num = 0; num < numPerSet; num++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 1)//odd
                {
                    currentOddCount++;
                }
                else // even
                {
                    currentEvenCount++;
                }
            }
            if (countOdd)
            {
                if (currentOddCount > oddCount)
                {
                    oddCount = currentOddCount;
                    savedSetOdd = i;
                }
                currentOddCount = 0;
            }
            else
            {
                if (currentEvenCount > evenCount)
                {
                    evenCount = currentEvenCount;
                    savedSetEven = i;
                }
                currentEvenCount = 0;
            }
        }
        string setWord = "";
        if (countOdd)
        {
            if (oddCount > 0)
            {
                switch (savedSetOdd)
                {
                    case 0: setWord = "First"; break;
                    case 1: setWord = "Second"; break;
                    case 2: setWord = "Third"; break;
                    case 3: setWord = "Fourth"; break;
                    case 4: setWord = "Fifth"; break;
                    case 5: setWord = "Sixth"; break;
                    case 6: setWord = "Seventh"; break;
                    case 7: setWord = "Eight"; break;
                    case 8: setWord = "Ninth"; break;
                    case 9: setWord = "Tenth"; break;
                }
                Console.WriteLine("{0} set has the most {1} numbers: {2}", setWord, word, oddCount);
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
        else
        {
            if (evenCount > 0)
            {
                switch (savedSetEven)
                {
                    case 0: setWord = "First"; break;
                    case 1: setWord = "Second"; break;
                    case 2: setWord = "Third"; break;
                    case 3: setWord = "Fourth"; break;
                    case 4: setWord = "Fifth"; break;
                    case 5: setWord = "Sixth"; break;
                    case 6: setWord = "Seventh"; break;
                    case 7: setWord = "Eight"; break;
                    case 8: setWord = "Ninth"; break;
                    case 9: setWord = "Tenth"; break;
                }
                Console.WriteLine("{0} set has the most {1} numbers: {2}", setWord, word, evenCount);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}