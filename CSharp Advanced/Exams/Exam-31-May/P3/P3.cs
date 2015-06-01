using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P3
{
    class P3
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

            var regex = @"(?:\$([^$%&']{1,}?)\$)|(?:\%([^$%&']{1,}?)\%)|(?:\&([^$%&']{1,}?)\&)|(?:\'([^$%&']{1,}?)\')";
            var matches = Regex.Matches(data, regex);

            var messages = new List<StringBuilder>();
            foreach (Match match in matches)
            {
                var weight = 0;
                var text = "";

                if (!match.Groups[1].ToString().Equals(""))
                {
                    weight = 1;
                    text = match.Groups[1].Value;
                }

                if (!match.Groups[2].ToString().Equals(""))
                {
                    weight = 2;
                    text = match.Groups[2].Value;
                }

                if (!match.Groups[3].ToString().Equals(""))
                {
                    weight = 3;
                    text = match.Groups[3].Value;
                }

                if (!match.Groups[4].ToString().Equals(""))
                {
                    weight = 4;
                    text = match.Groups[4].Value;
                }

                var message = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        message.Append((char) (text[i] + weight));
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
