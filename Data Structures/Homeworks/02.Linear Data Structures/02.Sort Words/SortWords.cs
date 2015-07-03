using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sort_Words
{
    class SortWords
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                var elements = input.Split(' ').ToList();
                elements.Sort();
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
