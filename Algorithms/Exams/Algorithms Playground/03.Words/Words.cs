namespace _03.Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Words
    {
        private static int total = 0;

        public static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var letters = word.ToCharArray().ToList();
            PermutationsRep(letters);
            Console.WriteLine(total);
        }

        public static void PermutationsRep(List<char> permutations)
        {
            permutations.Sort();
            PermuteRep(permutations, 0, permutations.Count);
        }

        public static void PermuteRep(List<char> permutations, int start, int n)
        {
            var validCombination = true;
            for (int i = 0; i < permutations.Count - 1; i++)
            {
                if (permutations[i] == permutations[i + 1])
                {
                    validCombination = false;
                    break;
                }
            }

            if (validCombination)
            {
                total++;
            }

            //Console.WriteLine(String.Join("", permutations));

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    char swap;
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
