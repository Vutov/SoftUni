using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    using System.Text.RegularExpressions;

    class P1
    {
        //private static int lastStartNumber = 1;
        static StringBuilder result = new StringBuilder();

        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());

        //        //GetAllCombinations(new List<int>(), 1, n);

        //    GetAllCombinations(0, arr, n);

        //}
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //int n = 3;
            //var arr = new int[n];
            //GetAllCombinations(0, arr, n);
            //Console.WriteLine(result);
            //Console.WriteLine("----");
            GetAllCombination(new List<int>(), 1, n, 0);
            Console.WriteLine(result);
        }

        //private static void GetAllCombinations(int index, int[] arr, int n)
        //{
        //    if (index >= n)
        //    {
        //        //PrintCombination(arr);
        //        return;
        //    }
        //    for (int i = 1; i <= n; i++)
        //    {
        //        arr[index] = i;
        //        if (arr.Sum() <= n)
        //        {
        //            PrintCombination(arr);
        //        }
        //        GetAllCombinations(index + 1, arr, n);
        //        arr[index] = 0;
        //    }
        //}

        private static void PrintCombination(IList<int> ints)
        {
            result.AppendLine(string.Join(" ", ints));
        }

        private static void GetAllCombination(List<int> arr, int startNum, int sum, int currentSum)
        {
            if (currentSum <= sum)
            {
                if (arr.Count > 0)
                {
                    PrintCombination(arr);
                }
            }
            else
            {
                return;
            }

            for (int i = startNum; i <= sum; i++)
            {
                arr.Add(i);
                currentSum += i;
                GetAllCombination(arr, startNum, sum, currentSum);
                var index = arr.LastIndexOf(i);
                arr.RemoveAt(index);
                currentSum -= i;
            }
        }

        //private static void PrintCombination(ICollection<int> ints)
        //{
        //    Console.WriteLine(string.Join(" ", ints));
        //}
    }
}
