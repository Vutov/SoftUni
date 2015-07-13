namespace _07.Linked_Queue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; set; }

        public void Enqueue(T element)
        {
            var node = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.NextNode = node;
                node.PrevNode = this.tail;
                this.tail = node;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var firstNode = this.head;
            this.head = this.head.NextNode;

            this.Count--;
            return firstNode.Value;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var nextNode = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = nextNode.Value;
                nextNode = nextNode.NextNode;
            }

            return result;
        }

        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PrevNode { get; set; }
        }
    }
}
