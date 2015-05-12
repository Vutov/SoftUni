using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        private static void Main(string[] args)
        {
            string regex = @"<p>([\w\W]*?)<\/p>";
            var innerText = Regex.Matches(Console.ReadLine(), regex);
            StringBuilder deciphered = new StringBuilder();
            foreach (Match match in innerText)
            {
                string text = match.Groups[1].ToString();
                foreach (var ch in text)
                {
                    if (ch >= 'a' && ch <= 'm')
                    {
                        deciphered.Append((char)(ch + 13));
                    }
                    else if (ch >= 'n' && ch <= 'z')
                    {
                        deciphered.Append((char)(ch - 13));
                    }
                    else if (ch >= '0' && ch <= '9')
                    {
                        deciphered.Append(ch);
                    }
                    else
                    {
                        deciphered.Append(' ');
                    }
                }
            }

            Regex pattern = new Regex("\\s+");
            string result = pattern.Replace(deciphered.ToString(), " ");
            Console.WriteLine(result);
        }

    }
}

