using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Permutations
{

    class Program
    {
        static int permutationsCount = 0;

        static void Main(string[] args)
        {
            var n = 3;
            var s = Enumerable.Range(1, n).ToList();
            PermutationsRep(s);
            Console.WriteLine("Total permutations: " + permutationsCount);
        }


        public static void PermutationsRep(List<int> permutations)
        {
            permutations.Sort();
            PermuteRep(permutations, 0, permutations.Count);
        }

        public static void PermuteRep(List<int> permutations, int start, int n)
        {
            Console.WriteLine(string.Join(", ", permutations));
            permutationsCount++;

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
