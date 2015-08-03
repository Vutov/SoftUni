namespace _02.Count_Symbols
{
    using System;
    using System.Linq;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var symbols = new HashTable<char, int>();
            foreach (var ch in input)
            {
                if (!symbols.ContainsKey(ch))
                {
                    symbols[ch] = 0;
                }

                symbols[ch]++;
            }

            var sortedSymbols = symbols.OrderBy(s => s.Key);
            foreach (var symbol in sortedSymbols)
            {
                Console.WriteLine("{0} -> {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
