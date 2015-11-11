namespace _01.Group_Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class GroupPermutations
    {
        private static readonly Dictionary<char, int> Letters = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var permutations = new List<char>();
            foreach (var character in input)
            {
                if (!Letters.ContainsKey(character))
                {
                    Letters.Add(character, 0);
                    permutations.Add(character);
                }

                Letters[character] += 1;
            }

            permutations.Sort();

            PermuteRep(permutations, 0, permutations.Count);
        }

        public static void PermuteRep(IList<char> permutations, int start, int count)
        {
            Print(permutations);

            if (start < count)
            {
                for (int i = count - 2; i >= start; i--)
                {
                    char swap;
                    for (int j = i + 1; j < count; j++)
                    {
                        if (permutations[i] != permutations[j])
                        {
                            swap = permutations[i];
                            permutations[i] = permutations[j];
                            permutations[j] = swap;

                            PermuteRep(permutations, i + 1, count);
                        }
                    }

                    swap = permutations[i];
                    for (int k = i; k < count - 1; )
                    {
                        permutations[k] = permutations[++k];
                    }

                    permutations[count - 1] = swap;
                }
            }
        }

        private static void Print(IEnumerable<char> permutations)
        {
            var result = new StringBuilder();
            foreach (var permutation in permutations)
            {
                result.Append(new string(permutation, Letters[permutation]));
            }

            Console.WriteLine(result);
        }
    }
}