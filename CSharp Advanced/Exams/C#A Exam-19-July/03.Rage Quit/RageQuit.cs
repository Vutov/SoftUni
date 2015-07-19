namespace _03.Rage_Quit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class RageQuit
    {
        public static void Main(string[] args)
        {
            var inputString = Console.ReadLine().ToUpper();
            const string InputRegex = @"(\D+)(\d+)";
            var uniqueSymbols = new HashSet<char>();
            var matches = Regex.Matches(inputString, InputRegex);

            foreach (Match match in matches)
            {
                var stringToPrint = match.Groups[1].Value;
                var timesToPrint = int.Parse(match.Groups[2].Value);
                if (timesToPrint != 0)
                {
                    var chars = stringToPrint.ToCharArray().ToList();
                    chars.ForEach(c => uniqueSymbols.Add(c));
                }
            }

            Console.WriteLine("Unique symbols used: {0}", uniqueSymbols.Count);

            foreach (Match match in matches)
            {
                var stringToPrint = match.Groups[1].Value;
                var timesToPrint = int.Parse(match.Groups[2].Value);

                Console.Write(new string('з', timesToPrint).Replace("з", stringToPrint));
            }
        }
    }
}