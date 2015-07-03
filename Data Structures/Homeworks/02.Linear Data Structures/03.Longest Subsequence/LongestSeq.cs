using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Longest_Subsequence
{
    class LongestSeq
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ", GetLongestSequence(elements)));
        }

        private static List<int> GetLongestSequence(List<int> elements)
        {
            var currLongestSeq = 1;
            var maxLongesSeq = 1;
            var element = elements[0];

            for (int i = 0; i < elements.Count - 1; i++)
            {
                if (elements[i].Equals(elements[i + 1]))
                {
                    currLongestSeq++;
                    if (currLongestSeq > maxLongesSeq)
                    {
                        element = elements[i];
                        maxLongesSeq = currLongestSeq;
                    }
                }
                else
                {
                    currLongestSeq = 1;
                }
            }

            var result = new List<int>();
            for (int i = 0; i < maxLongesSeq; i++)
            {
                result.Add(element);
            }

            return result;
        }
    }
}
