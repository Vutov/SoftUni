namespace InsertionSort
{
    using System;

    public class InsertionSort
    {
        public static void Main(string[] args)
        {
            var numbers = new[] { 4, 5, 1, 0, 10, -1 };

            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}