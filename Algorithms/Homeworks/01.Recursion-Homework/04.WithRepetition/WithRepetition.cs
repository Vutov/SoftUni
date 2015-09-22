using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WithRepetition
{
    class WithRepetition
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var arr = new int[k];

            GetAllCombinations(0, arr, 1, n);
        }

        private static void GetAllCombinations(int index, int[] arr, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                PrintCombination(arr);
                return;
            }
            for (int i = startNum; i <= endNum; i++)
            {
                arr[index] = i;
                GetAllCombinations(index + 1, arr, i + 1, endNum);
            }
        }

        private static void PrintCombination(int[] ints)
        {
            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
