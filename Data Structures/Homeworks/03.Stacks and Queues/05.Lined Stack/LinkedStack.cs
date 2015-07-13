namespace _05.Lined_Stack
{
    using System;

    public class LinkedStack<T>
    {
        private StackNode<T> firstNode;

        public int Count { get; set; }

        public void Push(T value)
        {
            var node = new StackNode<T>(value);

            if (this.Count == 0)
            {
                this.firstNode = node;
            }
            else
            {
                node.NextNode = this.firstNode;
                this.firstNode = node;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var first = this.firstNode;
            this.firstNode = this.firstNode.NextNode;

            this.Count--;

            return first.Value;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var nextNode = this.firstNode;
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = nextNode.Value;
                nextNode = nextNode.NextNode;
            }

            return result;
        }

        private class StackNode<T>
        {
            public StackNode(T value, StackNode<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public StackNode<T> NextNode { get; set; }

            public T Value { get; private set; }
        }
    }
}
