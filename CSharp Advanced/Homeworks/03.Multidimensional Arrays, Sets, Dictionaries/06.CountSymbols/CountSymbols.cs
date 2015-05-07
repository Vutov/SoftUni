
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class CountSymbols
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var chars = new SortedDictionary<char, int>();
        foreach (var ch in input)
        {
            if (chars.ContainsKey(ch))
            {
                chars[ch]++;
            }
            else
            {
                chars[ch] = 1;
            }
        }

        foreach (var pair in chars)
        {
            Console.WriteLine("{0} : {1} time/s", pair.Key, pair.Value);
        }
    }
}
