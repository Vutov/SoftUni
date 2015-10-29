namespace _01.Variations
{
    using System;

    class Variations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            GenerateVariations(arr, n);
        }

        private static void GenerateVariations(int[] arr, int n, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(arr, n, index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}
