using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ReplaceTags
{
    class ReplaceTags
    {
        static void Main(string[] args)
        {
            //<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>
            string html = Console.ReadLine();
            string regex = @"([\s\S]*?)<a([\s\S]*?)>([\s\S]*?)<\/a>([\s\S]*)";
            var data = Regex.Matches(html, regex);
            foreach (Match match in data)
            {
                Console.WriteLine(match.Groups[1] + "[URL" + match.Groups[2] + "]" +
                    match.Groups[3] + "[/URL]");
            }
        }
    }
}
