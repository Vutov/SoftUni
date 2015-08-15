namespace _01.Find_Words_in_File
{
    using System;
    using System.Collections.Generic;

    public class FindWords
    {
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var words = new Dictionary<string, int>();
            for (int i = 0; i < rows; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                foreach (var ch in tokens)
                {
                    if (!words.ContainsKey(ch))
                    {
                        words[ch] = 0;
                    }

                    words[ch]++;
                }
            }

            var queryWordCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < queryWordCount; i++)
            {
                var word = Console.ReadLine();
                Console.WriteLine("{0} -> {1}", word, words[word]);
            }
        }
    }
}
