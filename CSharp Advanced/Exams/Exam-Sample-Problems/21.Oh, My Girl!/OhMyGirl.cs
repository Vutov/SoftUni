using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21.Oh__My_Girl_
{
    class OhMyGirl
    {
        static void Main(string[] args)
        {
           
            var key = Console.ReadLine();
            var text = Console.ReadLine();
            var allText = "";
            while (!text.Equals("END"))
            {
                allText += text;
                text = Console.ReadLine();
            }

            var digitRegex = @"\d*";
            var lowerCaseRegex = @"[a-z]*";
            var upperCaseRegex = @"[A-Z]*";
            var capture = @"(.{2,6})";
            var keyRegex = Regex.Escape(key[0].ToString());
            for (int i = 1; i < key.Length - 1; i++)
            {
                if (key[i] >= 'a' && key[i] <= 'z')
                {
                    keyRegex += lowerCaseRegex;
                }
                else if (key[i] >= 'A' && key[i] <= 'Z')
                {
                    keyRegex += upperCaseRegex;
                } 
                else if (key[i] >= '0' && key[i] <= '9')
                {
                    keyRegex += digitRegex;
                }
                else
                {
                    keyRegex += Regex.Escape(key[i].ToString());
                }
            }

            keyRegex += Regex.Escape(key[key.Length - 1].ToString());
            var regex = keyRegex + capture + keyRegex;

            var matches = Regex.Matches(allText, regex);
            var message = string.Empty;
            foreach (Match match in matches)
            {
                message += match.Groups[1];
            }

            Console.WriteLine(message);
        }
    }
}
