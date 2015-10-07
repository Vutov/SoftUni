namespace _05.Shuffle
{
    using System;
    using System.Collections.Generic;

    class FisherYatesShuffle
    {

        static Random rng = new Random();

        static void Shuffle<T>(IList<T> collection)
        {
            int n = collection.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(rng.NextDouble() * (n - i));
                var t = collection[r];
                collection[r] = collection[i];
                collection[i] = t;
            }
        }

        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Shuffle(numbers);
            Console.WriteLine(string.Join(", ", numbers));

            string[] words = { "dot", "net", "perls" };
            Shuffle(words);
            Console.WriteLine(string.Join(", ", words));
        }
    }
}