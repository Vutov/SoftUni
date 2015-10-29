namespace HeapSort
{
    using System;

    class HeapSort
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void Sort(int[] numbers)
        {
            int heapSize = numbers.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            {
                MaxHeapify(numbers, heapSize, p);
            }

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                int temp = numbers[i];
                numbers[i] = numbers[0];
                numbers[0] = temp;
                heapSize--;
                MaxHeapify(numbers, heapSize, 0);
            }
        }

        private static void MaxHeapify(int[] numbers, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && numbers[left] > numbers[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }

            if (right < heapSize && numbers[right] > numbers[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                int temp = numbers[index];
                numbers[index] = numbers[largest];
                numbers[largest] = temp;

                MaxHeapify(numbers, heapSize, largest);
            }
        }
    }
}