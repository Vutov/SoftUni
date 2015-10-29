namespace _02.PermutationsIteratively
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Permutations
    {
        static void Main(string[] args)
        {
            int n = 5; //int.Parse(Console.ReadLine());
            var arr = Enumerable.Range(1, n).ToArray();
            var permutations = Permute(arr);
            var permutationCount = 0;
            foreach (var permutation in permutations)
            {
                Console.WriteLine(string.Join(", ", permutation));
                permutationCount++;
            }

            Console.WriteLine("Total permutations: " + permutationCount);
        }


        public static IEnumerable<List<T>> Permute<T>(IList<T> items)
        {
            var indexes = Enumerable.Range(0, items.Count).ToArray();

            yield return indexes.Select(idx => items[idx]).ToList();

            var weights = new int[items.Count];
            var idxUpper = 1;
            while (idxUpper < items.Count)
            {
                if (weights[idxUpper] < idxUpper)
                {
                    var idxLower = idxUpper % 2 * weights[idxUpper];
                    var tmp = indexes[idxLower];
                    indexes[idxLower] = indexes[idxUpper];
                    indexes[idxUpper] = tmp;
                    yield return indexes.Select(idx => items[idx]).ToList();
                    weights[idxUpper]++;
                    idxUpper = 1;
                }
                else
                {
                    weights[idxUpper] = 0;
                    idxUpper++;
                }
            }
        }
    }
}
