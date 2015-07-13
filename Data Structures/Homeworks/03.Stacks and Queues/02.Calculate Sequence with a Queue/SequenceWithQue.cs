namespace _02.Calculate_Sequence_with_a_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceWithQue
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var magicSequence = new Queue<int>();
            var seqNumbers = new List<int>
            {
                n
            };

            magicSequence.Enqueue(n);
            while (seqNumbers.Count < 50)
            {
                var firstItem = magicSequence.Peek() + 1;
                magicSequence.Enqueue(firstItem);
                var secondItem = (magicSequence.Peek() * 2) + 1;
                magicSequence.Enqueue(secondItem);
                var thirdItem = firstItem + 1;
                magicSequence.Enqueue(thirdItem);

                magicSequence.Dequeue();
                seqNumbers.Add(firstItem);
                seqNumbers.Add(secondItem);
                seqNumbers.Add(thirdItem);
            }

            Console.WriteLine(string.Join(", ", seqNumbers.Take(50)));
        }
    }
}
