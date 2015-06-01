using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P3
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            StringBuilder allText = new StringBuilder();
            while (!line.Equals("burp"))
            {
                allText.Append(line);
                line = Console.ReadLine();
            }

            string data = Regex.Replace(allText.ToString(), @"\s+", " ");

            var regex = @"(\$|%|&|')([^\$%&']+)\1";
            var matches = Regex.Matches(data, regex);

            var messages = new List<StringBuilder>();
            foreach (Match match in matches)
            {
                var key = match.Groups[1].Value.ToString();
                var text = match.Groups[2].Value.ToString();
                var weight = 0;
                switch (key)
                {
                    case "$":
                        weight = 1;
                        break;
                    case "%":
                        weight = 2;
                        break;
                    case "&":
                        weight = 3;
                        break;
                    case "'":
                        weight = 4;
                        break;
                }

                var message = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        message.Append((char)(text[i] + weight));
                    }
                    else
                    {
                        message.Append((char)(text[i] - weight));
                    }
                }

                messages.Add(message);
            }

            Console.WriteLine(string.Join(" ", messages));
        }
    }
}