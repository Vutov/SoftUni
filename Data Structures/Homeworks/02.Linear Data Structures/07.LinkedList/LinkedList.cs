using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _07.LinkedList
{
    public class LinkedList<T> : IEnumerable<T> where T : IComparable
    {
        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }
        }

        private ListNode<T> start;

        public int CurrentCount { get; set; }

        public void Add(T element)
        {
            var newElement = new ListNode<T>(element);
            if (this.CurrentCount == 0)
            {
                this.start = newElement;
            }
            else
            {
                var currElement = this.start;
                for (int i = 0; i < this.CurrentCount; i++)
                {
                    if (i == this.CurrentCount - 1)
                    {
                        currElement.NextNode = newElement;
                    }

                    currElement = currElement.NextNode;
                }
            }

            this.CurrentCount++;
        }

        public T Remove(int index)
        {
            if (index > this.CurrentCount)
            {
                throw new IndexOutOfRangeException("Invalid Index");
            }

            T removed = default(T);
            if (index == 0)
            {
                removed = this.start.Value;
                this.start = this.start.NextNode;
            }
            else
            {
                var currElement = this.start.NextNode;
                ListNode<T> previusElement = this.start;
                for (int i = 1; i < this.CurrentCount; i++)
                {
                    if (i == index)
                    {
                        removed = currElement.Value;
                        var nextElement = currElement.NextNode;
                        previusElement.NextNode = nextElement;
                        break;
                    }

                    previusElement = currElement;
                    currElement = currElement.NextNode;
                }
            }

            this.CurrentCount--;

            return removed;
        }

        public int Count()
        {
            return this.CurrentCount;
        }

        public void ForEach(Action<T> action)
        {
            var currElement = this.start;
            while (currElement != null)
            {
                action(currElement.Value);
                currElement = currElement.NextNode;
            }
        }

        public int FirstIndexOf(T value)
        {
            var element = this.start;
            for (int i = 0; i < this.CurrentCount; i++)
            {
                if (element.Value.CompareTo(value) == 0)
                {
                    return i;
                }

                element = element.NextNode;
            }

            return -1;
        }

        public int LastIndexOf(T value)
        {
            var element = this.start;
            var index = -1;
            for (int i = 0; i < this.CurrentCount; i++)
            {
                if (element.Value.CompareTo(value) == 0)
                {
                    index = i;
                }

                element = element.NextNode;
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currElement = this.start;
            while (currElement != null)
            {
                yield return currElement.Value;

                currElement = currElement.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
