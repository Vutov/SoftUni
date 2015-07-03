using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReversedList
{
    class ReversedList<T> : IEnumerable<T> where T : IComparable
    {
        private const int DefaultCapacity = 4;

        private T[] container;

        public ReversedList()
        {
            this.container = new T[DefaultCapacity];
        }

        public int Index { get; set; }

        public T this[int wantedIndex]
        {
            get
            {
                var reversedIndex = this.Index - wantedIndex - 1;
                return this.container[reversedIndex];
            }
            set
            {
                var reversedIndex = this.Index - wantedIndex - 1;
                this.container[reversedIndex] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Index >= this.container.Length)
            {
                this.Grow();
            }

            this.container[Index] = element;

            this.Index++;
        }

        public int Count()
        {
            return this.Index;
        }

        public int Capacity()
        {
            return this.container.Length;
        }

        public void Sort()
        {
            bool sort = true;
            while (sort)
            {
                sort = false;
                for (int i = 0; i < this.Index - 1; i++)
                {
                    if (this.container[i].CompareTo(this.container[i + 1]) > 0)
                    {
                        T swapper = this.container[i];
                        this.container[i] = this.container[i + 1];
                        this.container[i + 1] = swapper;
                        sort = true;
                    }
                }
            }
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Index - 1; i >= 0; i--)
            {
                action(this.container[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Index - 1; i >= 0; i--)
            {
                yield return this.container[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Grow()
        {
            var biggerContainer = new T[this.container.Length * 2];
            for (int i = 0; i < this.container.Length; i++)
            {
                biggerContainer[i] = this.container[i];
            }

            this.container = biggerContainer;
        }
    }
}
