using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Generate_Combinations_Iteratively
{
    class CombinationsIteratively
    {
        static void Main(string[] args)
        {
            int n = 5;
            int k = 3;
            foreach (int[] combinations in Combinations(k, n))
            {
                Console.WriteLine(string.Join(", ", combinations));
            }
        }

        public static IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
