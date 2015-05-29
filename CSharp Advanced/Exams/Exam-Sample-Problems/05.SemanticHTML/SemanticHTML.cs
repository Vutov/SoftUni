using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.SemanticHTML
{
    class SemanticHTML
    {
        static void Main(string[] args)
        {
            var regex = @"(<div.+?(?:id|class)\s*=\s*""(.*?)"".*?>)[\w\W]*(<\/div>\s*<!--\s*\2\s*-->)";

            string allText = "";
            var line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                allText += "\n" + line;
                line = Console.ReadLine();
            }

            var matches = Regex.Matches(allText, regex);
            while (matches.Count != 0)
            {
                foreach (Match match in matches)
                {
                    var opening = match.Groups[1].ToString();
                    var tag = match.Groups[2].ToString();
                    var closing = match.Groups[3].ToString();

                    opening = Regex.Replace(opening, @"(id|class)\s*=\s*""(.*?)""", "");
                    opening = opening.Replace("div", tag);
                    closing = Regex.Replace(closing, @"\s*<!--\s*" + tag + @"\s*-->", "");
                    closing = closing.Replace("div", tag);
                    opening = Regex.Replace(opening, @"\s+", " ");
                    opening = Regex.Replace(opening, @"\s+>", ">");
                    closing = Regex.Replace(closing, @"\s+", " ");
                    closing = Regex.Replace(closing, @"\s+>", ">");
                    allText = allText.Replace(match.Groups[1].ToString(), opening);
                    allText = allText.Replace(match.Groups[3].ToString(), closing);

                }

                matches = Regex.Matches(allText, regex);
            }
            
            Console.WriteLine(allText);
        }
    }
}
