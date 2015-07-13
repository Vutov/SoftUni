namespace _07.Linked_Queue
{
    using System;

    public class LinkedQueueTests
    {
        public static void Main(string[] args)
        {
            var testQue = new LinkedQueue<int>();
            testQue.Enqueue(1);
            testQue.Enqueue(2);
            testQue.Enqueue(3);
            testQue.Enqueue(4);
            Console.WriteLine();
            var testArr = testQue.ToArray();
            foreach (var i in testArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine(testQue.Dequeue());
            Console.WriteLine();
            testQue.Enqueue(100);
            Console.WriteLine(testQue.Dequeue());
            Console.WriteLine();
            testArr = testQue.ToArray();
            foreach (var i in testArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
