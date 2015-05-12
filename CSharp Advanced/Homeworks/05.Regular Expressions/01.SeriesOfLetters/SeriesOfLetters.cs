using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (var ch in input)
            {
                Regex regex = new Regex(ch + "+");
                input = regex.Replace(input, ch.ToString());
            }

            Console.WriteLine(input);
        }
    }
}
