using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CombinationsWithoutRepetition
{
    class CombinationsWihtoutRepetitions
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            bool[] used = new bool[n + 1];

            GenerateVariations(arr, used, n);
        }

        private static void GenerateVariations(int[] arr, bool[] used, int n, int start = 1, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = i;
                        used[i] = true;
                        GenerateVariations(arr, used, n, i, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}