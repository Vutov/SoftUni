namespace Circular_Queue
{
    using System;

    public class CircularQueue<T>
    {
        private const int InitialCapacity = 4;

        private int head;
        private int tail;
        private T[] elements;

        public CircularQueue()
        {
            this.elements = new T[InitialCapacity];
            this.head = 0;
            this.tail = 0;
        }

        public CircularQueue(int capacity)
            : this()
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.tail] = element;
            this.tail = (this.tail + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue don't have elements");
            }

            var firstElement = this.elements[this.head];
            this.elements[this.head] = default(T);
            this.head = (this.head + 1) % this.elements.Length;
            this.Count--;

            return firstElement;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentElement = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.elements[currentElement];
                currentElement = (currentElement + 1) % this.elements.Length;
            }

            return resultArray;
        }

        private void Resize()
        {
            var resizedElements = new T[this.elements.Length * 2];
            var currentElement = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                resizedElements[i] = this.elements[currentElement];
                currentElement = (currentElement + 1) % this.elements.Length;
            }

            this.head = 0;
            this.tail = this.Count;

            this.elements = resizedElements;
        }
    }

    public class Example
    {
        public static void Main()
        {
            var queue = new CircularQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            var first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            queue.Enqueue(-7);
            queue.Enqueue(-8);
            queue.Enqueue(-9);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            queue.Enqueue(-10);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}