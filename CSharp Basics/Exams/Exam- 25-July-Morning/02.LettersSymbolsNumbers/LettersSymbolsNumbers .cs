using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LettersSymbolsNumbers
{
    static void Main(string[] args)
    {
        int numStrings = int.Parse(Console.ReadLine());
        int sumLetters = 0;
        int sumNumbers = 0;
        int sumSymbols = 0;

        for (int i = 0; i < numStrings; i++)
        {
            string input = Console.ReadLine();
            input = input.ToLower();
            foreach (char item in input)
            {
                if (item == ' ' ||
                    item == '\t' ||
                    item == '\r' ||
                    item == '\n')
                {
                    continue;
                }
                else if (item >= 'a' && item <= 'z')
                {
                    sumLetters += (item - 'a' + 1) * 10;
                }
                else if (item >= '0' && item <= '9')
                {
                    sumNumbers += (item - '0') * 20;
                }
                else
                {
                    sumSymbols += 200;
                }
            }
        }
        Console.WriteLine("{0}\n{1}\n{2}", sumLetters, sumNumbers, sumSymbols);
    }
}