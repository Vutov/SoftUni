namespace _05.AllPermutations
{
    using System;
    using System.Collections.Generic;

    class Permutations
    {
        static void Main(string[] args)
        {
            // var s = new List<int> {1, 3, 5, 5};
            var s = new List<int> { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            PermutationsRep(s);
        }


        public static void PermutationsRep(List<int> permutations)
        {
            permutations.Sort();
            PermuteRep(permutations, 0, permutations.Count);
        }

        public static void PermuteRep(List<int> permutations, int start, int n)
        {
            Console.WriteLine(string.Join(", ", permutations));

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    var swap = 0;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (permutations[i] != permutations[j])
                        {
                            swap = permutations[i];
                            permutations[i] = permutations[j];
                            permutations[j] = swap;

                            PermuteRep(permutations, i + 1, n);
                        }
                    }

                    swap = permutations[i];
                    for (int k = i; k < n - 1; )
                    {
                        permutations[k] = permutations[++k];
                    }

                    permutations[n - 1] = swap;
                }
            }
        }
    }
}