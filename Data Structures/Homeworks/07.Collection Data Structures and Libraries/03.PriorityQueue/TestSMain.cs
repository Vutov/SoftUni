namespace _03.PriorityQueue
{
    using System;

    public class TestsMain
    {
        public static void Main(string[] args)
        {
            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(3, 3);
            priorityQueue.Enqueue(3, 3);
            priorityQueue.Enqueue(4, 4);
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();

            Console.WriteLine(priorityQueue.Peek());
        }
    }
}
