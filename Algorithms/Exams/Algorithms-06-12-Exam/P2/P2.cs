using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    internal class P2
    {
        private static int lastBridge = -1;
        static HashSet<int> saveIndexes = new HashSet<int>(); 

        public static void Main()
        {
            int[] seq = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int[] seq = "7 3 4 5 3 6 7 2 4 5 6 8 6 8".Split().Select(int.Parse).ToArray();
            int[] bridgesCount = CalcBridgesCount(seq);
            int maxCount = bridgesCount.Max();
            if (maxCount == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (maxCount == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine("{0} bridges found", maxCount);
            }

            //Console.WriteLine(string.Join(" ", seq));
            //Console.WriteLine(string.Join(" ", saveIndexes));
            //var seen = -2;
            //for (int i = bridgesCount.Count() - 1; i > 0 ; i--)
            //{
            //    if (bridgesCount[i] == bridgesCount[i - 1])
            //    {
            //        if (seq[i] != seen)
            //        {
            //            seq[i] = -1;
            //        }
            //    }
            //    else
            //    {
            //        seen = seq[i];
            //    }
            //}

            //if (bridgesCount[0] == bridgesCount[1])
            //{
            //    if (seq[0] != seen)
            //    {
            //        seq[0] = -1;
            //    }
            //}

            var resultSet = new List<string>();
            for (int i = 0; i < seq.Length; i++)
            {
                if (saveIndexes.Contains(i))
                {
                    resultSet.Add("" + seq[i]);
                }
                else
                {
                    resultSet.Add("X");
                }
            }

            Console.WriteLine(string.Join(" ", resultSet));
        }

        private static int[] CalcBridgesCount(int[] seq)
        {
            //Console.WriteLine(string.Join(", ", seq));
            int[] bridgeCounts = new int[seq.Length];

            for (int index = 1; index < seq.Length; index++)
            {
                bridgeCounts[index] = bridgeCounts[index - 1];
                for (int prevIndex = index - 1; prevIndex >= 0; prevIndex--)
                {
                    if (seq[index] == seq[prevIndex] &&
                        bridgeCounts[prevIndex] + 1 >= bridgeCounts[index])
                    {
                        bridgeCounts[index] = bridgeCounts[prevIndex] + 1;
                        var currentBridge = bridgeCounts[prevIndex] + 1;
                        if (currentBridge  > lastBridge)
                        {
                        //    Console.WriteLine(string.Join(", ", bridgeCounts));
                        //    Console.WriteLine(seq[index]);
                            for (int i = index - 1; i >= 0; i--)
                            {
                                if (seq[i] == seq[index])
                                {
                                    saveIndexes.Add(i);
                                    break;
                                }
                            }
                            saveIndexes.Add(index);
                        }
                        lastBridge = bridgeCounts[prevIndex] + 1;
                        break;
                    }
                }
            }
            return bridgeCounts;
        }
    }
}
