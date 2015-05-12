using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string emailRegex =
                @"\s([a-zA-Z\d][a-zA-Z\d\.\-_]*[a-zA-Z\d]@(?:[a-zA-Z][a-zA-Z\-]*[a-zA-Z]\.){1,}[a-zA-Z][a-zA-Z\-]*[a-zA-Z])";
            string input = Console.ReadLine();
            var matches = Regex.Matches(input, emailRegex);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}
