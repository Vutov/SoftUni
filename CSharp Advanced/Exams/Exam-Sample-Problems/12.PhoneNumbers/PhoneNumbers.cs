using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.PhoneNumbers
{
    class PhoneNumbers
    {
        static void Main(string[] args)
        {
            var regex = @"([A-Z]{1,}[a-zA-Z]*)[^a-zA-Z\+]*?((?:\d+|\+\d)[\d\(\)/\.\- ]*\d+)";

            var allText = string.Empty;
            var text = Console.ReadLine();
            while (!text.Equals("END"))
            {
                allText += text;
                text = Console.ReadLine();
            }

            var foundPairs = Regex.Matches(allText, regex);
            if (foundPairs.Count != 0)
            {
                Console.Write("<ol>");
                foreach (Match foundPair in foundPairs)
                {
                    var number = Regex.Replace(foundPair.Groups[2].ToString(), @"[\(\)/\.\- ]+", "");
                    Console.Write("<li><b>{0}:</b> {1}</li>", foundPair.Groups[1], number);
                }
                Console.Write("</ol>");
            }
            else
            {
                Console.WriteLine("<p>No matches!</p>");
            }
        }
    }
}
