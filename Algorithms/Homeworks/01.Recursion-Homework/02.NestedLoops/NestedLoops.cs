using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NestedLoops
{
    class NestedLoops
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            GetAllCombinations(0, arr, n);
        }

        private static void GetAllCombinations(int index, int[] arr, int n)
        {
            if (index >= n)
            {
                PrintCombination(arr);
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                GetAllCombinations(index+1, arr, n);
            }
        }

        private static void PrintCombination(int[] ints)
        {
            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
