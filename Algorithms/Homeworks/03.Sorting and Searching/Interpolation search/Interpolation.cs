namespace Interpolation_search
{
    using System;

    class Interpolation
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 4, 5, 1, 0, 10, -10 };
            Array.Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(InterpolationSearch(numbers, 10));
            Console.WriteLine(InterpolationSearch(numbers, 15));
        }

        public static int InterpolationSearch(int[] x, int searchValue)
        {
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                if (x[mid] < searchValue)
                {
                    low = mid + 1;
                }
                else if (x[mid] > searchValue)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (x[low] == searchValue)
            {
                return low;
            }

            return -1; // Not found
        }
    }
}
