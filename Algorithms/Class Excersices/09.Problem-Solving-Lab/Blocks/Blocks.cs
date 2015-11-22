namespace Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Blocks
    {
        public static void Main(string[] args)
        {
            int numberOfLetters = int.Parse(Console.ReadLine());
            var startChar = 'A';
            var letters = new List<char>();
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters.Add(startChar);
                startChar = (char)(startChar + 1);
            }

            var blocksCounter = 0;
            var foundBlocks = new StringBuilder();
            for (int l1 = 0; l1 < numberOfLetters; l1++)
            {
                for (int l2 = l1 + 1; l2 < numberOfLetters; l2++)
                {
                    for (int l3 = l1 + 1; l3 < numberOfLetters; l3++)
                    {
                        if (l2 != l3)
                        {
                            for (int l4 = l1 + 1; l4 < numberOfLetters; l4++)
                            {
                                if (l3 != l4 && l2 != l4)
                                {
                                   var block = string.Format("{0}{1}{2}{3}",
                                        letters[l1],
                                        letters[l2],
                                        letters[l3],
                                        letters[l4]);
                                    foundBlocks.AppendLine(block);
                                    blocksCounter++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Number of blocks: {0}", blocksCounter);
            Console.WriteLine(foundBlocks.ToString().Trim());
        }
    }
}
