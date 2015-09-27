using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VariationsWithoutRepetition
{
    class WithoutRepetition
    {
        static void Main(string[] args)
        {
            int n = 3;//int.Parse(Console.ReadLine());
            int k = 2;//int.Parse(Console.ReadLine());
            var arr = new int[k];
            var used = new bool[n + 1];

            GenerateVariations(arr, used, n);
        }

        private static void GenerateVariations(int[] arr, bool[] used, int n, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = i;
                        used[i] = true;
                        GenerateVariations(arr, used, n, index + 1);
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
