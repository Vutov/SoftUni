using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InsertionSort
{
    class InsertionSort
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int len = numbers.Count;
            for (int i = len - 1; i > 0; i--)
            {
                int min = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (numbers[j] > numbers[min])
                    {
                        min = j;
                    }
                }
                int swapper = numbers[min];
                numbers[min] = numbers[i];
                numbers[i] = swapper;

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
