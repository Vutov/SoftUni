using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Zigzag_Sequence
{
    class ZigzagSequence
    {
        public static void Main(string[] args)
        {
            //var input = "8,3,5,7,0,8,9,10,20,20,20,12,19,11";
            var input = "24,5,31,3,3,342,51,114,52,55,56,58";
            var sequence = input.Split(',').Select(int.Parse).ToArray();
            var longestSeq = LongestZigZag(sequence);
            Console.WriteLine(string.Join(" ", longestSeq));
        }

        public static List<int> LongestZigZag(int[] sequence)
        {
            var seq = new List<int>();
            int[] diff = new int[sequence.Length - 1];

            for (int i = 1; i < sequence.Length; i++)
            {
                diff[i - 1] = sequence[i] - sequence[i - 1];
            }

            int prevsign = Sign(diff[0]);
            seq.Add(sequence[0]);

            for (int i = 1; i < diff.Length; i++)
            {
                int sign = Sign(diff[i]);
                if (prevsign * sign == -1)
                {
                    prevsign = sign;
                    if (seq.Count == 1)
                    {
                        seq.Add(sequence[i]);
                    }
                    seq.Add(sequence[i + 1]);
                }
            }

            return seq;
        }

        public static int Sign(int a)
        {
            if (a == 0)
            {
                return 0;
            }

            return a / Math.Abs(a);
        }
    }
}
