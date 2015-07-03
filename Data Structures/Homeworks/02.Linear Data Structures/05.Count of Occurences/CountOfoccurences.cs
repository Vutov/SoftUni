using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Count_of_Occurences
{
    class CountOfoccurences
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var result = new SortedDictionary<int, int>();
            elements.ForEach(e =>
            {
                if (!result.ContainsKey(e))
                {
                    result[e] = 0;
                }

                result[e]++;
            });

            foreach (var element in result)
            {
                Console.WriteLine("{0} -> {1} times", element.Key, element.Value);
            }
        }
    }
}
