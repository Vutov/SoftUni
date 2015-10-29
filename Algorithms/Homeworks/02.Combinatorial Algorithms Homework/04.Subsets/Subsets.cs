namespace _04.Subsets
{
    using System;

    class Subsets
    {
        static void Main(string[] args)
        {
            var items = new[] { "test", "rock", "fun" };
            var k = 2;
            var arr = new string[k];

            GetAllCombinations(items, arr);
        }

        private static void GetAllCombinations(string[] items, string[] arr, int index = 0, int startNum = 0)
        {
            if (index >= arr.Length)
            {
                PrintCombination(arr);
                return;
            }
            for (int i = startNum; i < items.Length; i++)
            {
                arr[index] = items[i];
                GetAllCombinations(items, arr, index + 1, i + 1);
            }
        }

        private static void PrintCombination(string[] ints)
        {
            Console.WriteLine("({0})", string.Join(" ", ints));
        }
    }
}
