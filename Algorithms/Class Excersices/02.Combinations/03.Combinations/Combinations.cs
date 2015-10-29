using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            int n = 3;//int.Parse(Console.ReadLine());
            int k = 2;//int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            GenerateVariations(arr, n);
        }

        private static void GenerateVariations(int[] arr, int n, int start = 1, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(arr, n, i, index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}
