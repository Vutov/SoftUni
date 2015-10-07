namespace Merge_Sort
{
    using System;

    public class MergeSort
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(", ", numbers));
        }
        public static void Sort(int[] numbers, int left, int right)
        {
            if (right > left)
            {
                var mid = (right + left) / 2;
                Sort(numbers, left, mid);
                Sort(numbers, (mid + 1), right);
                Merge(numbers, left, (mid + 1), right);
            }
        }

        public static void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] container = new int[numbers.Length];
            var leftEnd = (mid - 1);
            var pos = left;
            var numElements = (right - left + 1);

            while (left <= leftEnd && mid <= right)
            {
                if (numbers[left] <= numbers[mid])
                {
                    container[pos++] = numbers[left++];
                }
                else
                {
                    container[pos++] = numbers[mid++];
                }
            }

            while (left <= leftEnd)
            {
                container[pos++] = numbers[left++];
            }

            while (mid <= right)
            {
                container[pos++] = numbers[mid++];
            }

            for (var i = 0; i < numElements; i++)
            {
                numbers[right] = container[right];
                right--;
            }
        }
    }
}