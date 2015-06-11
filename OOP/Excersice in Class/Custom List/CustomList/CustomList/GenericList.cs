using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class GenericList<T> where T: IComparable
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int currentIndex;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            currentIndex = 0;
        }

        public void Add(T element)
        {
            if (currentIndex >= elements.Length)
            {
                this.Resize();
            }

            this.elements[currentIndex] = element;

            currentIndex++;
        }

        public void Remove(T element)
        {
            int emptyIndex = elements.Length;

            for (int i = 0; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.Equals(element))
                {
                    this.elements[i] = default(T);
                    emptyIndex = i;
                }
            }

            if (!emptyIndex.Equals(elements.Length))
            {
                for (int i = emptyIndex; i < currentIndex; i++)
                {
                    T tmp = this.elements[i];
                    this.elements[i] = this.elements[i + 1];
                    this.elements[i + 1] = tmp;
                }
            }

            currentIndex--;
        }

        public T Min()
        {
            T min = this.elements[0];

            for (int i = 1; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.CompareTo(min) < 0)
                {
                    min = currElement;
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            for (int i = 1; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.CompareTo(max) > 0)
                {
                    max = currElement;
                }
            }

            return max;
        }

        public int Count()
        {
            return currentIndex;
        }

        public int Capacity()
        {
            return this.elements.Length;
        }

        public T this[int index]
        {
            get
            {
                return this.elements[index];
            }
            set
            {
                this.elements[index] = value;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements.Take(currentIndex));
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Sort()
        {
            bool sort = true;
            while (sort)
            {
                sort = false;
                for (int i = 0; i < currentIndex - 1; i++)
                {
                    if (this.elements[i].CompareTo(this.elements[i + 1]) > 0)
                    {
                        T swapper = this.elements[i];
                        this.elements[i] = this.elements[i + 1];
                        this.elements[i + 1] = swapper;
                        sort = true;
                    }
                }
            }
        }

        public void Reverse()
        {
            var revElemenets = new T[currentIndex];
            int index = 0;
            for (int i = currentIndex - 1; i >= 0; i--)
            {
                revElemenets[index] = this.elements[i];
                index++;
            }

            this.elements = revElemenets;
        }

        private void Resize()
        {
            T[] resized = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                resized[i] = this.elements[i];
            }

            this.elements = resized;
        }
    }
}
