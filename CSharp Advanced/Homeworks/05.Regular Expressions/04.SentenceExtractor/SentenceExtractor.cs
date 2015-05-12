using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.SentenceExtractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string sentance = Console.ReadLine();
            string regex = @"[\w\W]*?\b" + word + @"\b[\w\W]*?[?\.!]";
            var matches = Regex.Matches(sentance, regex);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
