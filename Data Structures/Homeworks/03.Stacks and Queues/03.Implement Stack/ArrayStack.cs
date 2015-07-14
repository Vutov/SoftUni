namespace _03.Implement_Stack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;

        public ArrayStack()
        {
            this.elements = new T[InitialCapacity];
        }

        public ArrayStack(int capacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var element = this.elements[this.Count - 1];
            this.Count--;

            return element;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.elements[this.Count - 1 - i];
            }

            return result;
        }

        private void Grow()
        {
            var currentLen = this.elements.Length;
            var newElements = new T[currentLen * 2];
            for (int i = 0; i < currentLen; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
