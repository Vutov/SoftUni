using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Palindromes
{
    
    class Palindromes
    {
        private static bool IsPalidrome(string word)
        {
            int wordLen = word.Length;
            for (int i = 0; i < wordLen; i++)
            {
                if (!word[i].Equals(word[wordLen - 1 - i]))
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var text = Regex.Split(Console.ReadLine(), @"\W+").ToList();
            var palindromes = new SortedSet<string>();
            text.ForEach(word =>
            {
                if (IsPalidrome(word))
                {
                    palindromes.Add(word);
                }
            });

            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
