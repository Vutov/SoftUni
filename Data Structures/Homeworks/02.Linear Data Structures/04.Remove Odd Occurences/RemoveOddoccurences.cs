using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Remove_Odd_Occurences
{
    class RemoveOddOccurences
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var result = new Dictionary<int, int>();
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
                if (element.Value % 2 == 1)
                {
                    elements.RemoveAll(e => e == element.Key);
                }
            }

            Console.WriteLine(string.Join(" ", elements));

        }
    }
}
