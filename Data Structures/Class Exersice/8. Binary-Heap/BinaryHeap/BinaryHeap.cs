namespace BinaryHeap
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(T[] elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public T ExtractMax()
        {
            var max = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return max;
        }

        public T PeekMax()
        {
            return this.heap[0];
        }

        public void Insert(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var largets = i;
            var count = this.heap.Count;
            if (left < count && this.heap[left].CompareTo(this.heap[largets]) > 0)
            {
                largets = left;
            }

            if (right < count && this.heap[right].CompareTo(this.heap[largets]) > 0)
            {
                largets = right;
            }

            if (largets != i)
            {
                var swap = this.heap[i];
                this.heap[i] = this.heap[largets];
                this.heap[largets] = swap;
                this.HeapifyDown(largets);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
            {
                var swap = this.heap[i];
                this.heap[i] = this.heap[parent];
                this.heap[parent] = swap;
                i = parent;
                parent = (i - 1) / 2;
            }
        }
    }
}
