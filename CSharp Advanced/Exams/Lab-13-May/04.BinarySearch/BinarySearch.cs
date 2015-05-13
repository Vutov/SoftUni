using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BinarySearch
{
    class _BinarySearch
    {
        public static int BinarySearch(List<int> numbers, int min, int max, int item)
        {
            if (item < numbers[0] || item > numbers[numbers.Count - 1])
            {
                return -1;
            }
            int index = min + ((max - min) / 2);
            if (max <= min)
            {
                return index;
            }

            if (item > numbers[index])
            {
                return BinarySearch(numbers, index + 1, max, item);
            }

            return BinarySearch(numbers, min, index, item);
        }

        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int item = int.Parse(Console.ReadLine());
            numbers.Sort();
            Console.WriteLine(BinarySearch(numbers, 0, numbers.Count - 1, item));
        }
    }
}
