using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            using (var wordsReader = new StreamReader("../../words.txt"))
            {
                using (var textReader = new StreamReader("../../text.txt"))
                {
                    using (var writer = new StreamWriter("../../result.txt"))
                    {
                        var words = new List<string>();
                        var word = wordsReader.ReadLine();
                        while (word != null)
                        {
                            words.Add(word);
                            word = wordsReader.ReadLine();
                        }

                        var text = textReader.ReadToEnd().ToLower();

                        var result = new SortedDictionary<int, string>();
                        words.ForEach(x =>
                        {
                            var regex = @"\b" + x.ToLower() + @"\b";
                            var match = Regex.Matches(text, regex);
                            result.Add(match.Count, x);
                        });

                        foreach (var foundWord in result.Reverse())
                        {
                            writer.WriteLine("{0} - {1}", foundWord.Value, foundWord.Key);
                        }
                    }
                }
            }

            Console.WriteLine("File done");
        }
    }
}
