using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string regex = @"\b([a-zA-Z]\w{2,24})\b";
            var validUserames = Regex.Matches(Console.ReadLine(), regex);
            int maxLen = 0;
            var usernames = new string[2];
            for (int i = 0; i < validUserames.Count - 1; i++)
            {
                int curLen = validUserames[i].Length + validUserames[i + 1].Length;
                if (curLen > maxLen)
                {
                    maxLen = curLen;
                    usernames[0] = validUserames[i].ToString();
                    usernames[1] = validUserames[i + 1].ToString();
                }
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
