using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountOccurrences
{
    class CountOccurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string key = Console.ReadLine();

            int occurrences = 0;
            int index = text.IndexOf(key);
            while (index != -1)
            {
                occurrences++;
                index = text.IndexOf(key, index + 1);
            }

            Console.WriteLine(occurrences);
        }
    }
}
