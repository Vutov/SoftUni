using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private int totalElements;
    private BigList<T> firstAndLastElements;
    private SortedDictionary<T, List<T>> smallestElements;
    private SortedDictionary<T, List<T>> biggestElements;

    public FirstLastList()
    {
        this.totalElements = 0;
        this.firstAndLastElements = new BigList<T>();
        this.smallestElements = new SortedDictionary<T, List<T>>(new SmallestElement());
        this.biggestElements = new SortedDictionary<T, List<T>>(new BiggestElement());
    }


    public void Add(T newElement)
    {
        this.firstAndLastElements.Add(newElement);
        if (!this.smallestElements.ContainsKey(newElement))
        {
            this.smallestElements.Add(newElement, new List<T>());
        }

        this.smallestElements[newElement].Add(newElement);
        if (!this.biggestElements.ContainsKey(newElement))
        {
            this.biggestElements.Add(newElement, new List<T>());
        }

        this.biggestElements[newElement].Add(newElement);

        this.totalElements++;
    }

    public int Count
    {
        get { return this.totalElements; }
    }

    public IEnumerable<T> First(int count)
    {
        if (this.totalElements < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        var elements = this.firstAndLastElements.GetRange(0, count);
        foreach (var element in elements)
        {
            yield return element;
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.totalElements < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        var elements = this.firstAndLastElements.Range(this.totalElements - count, count);
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            yield return elements[i];
        }
    }

    public IEnumerable<T> Min(int count)
    {
        if (this.totalElements < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (count == 0)
        {
            yield break;
        }

        foreach (var element in this.smallestElements)
        {
            foreach (var tvalue in element.Value)
            {
                count--;
                yield return tvalue;
                if (count <= 0)
                {
                    yield break;
                }
            }
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (this.totalElements < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (count == 0)
        {
            yield break;
        }

        foreach (var element in this.biggestElements)
        {
            foreach (var tvalue in element.Value)
            {
                count--;
                yield return tvalue;
                if (count <= 0)
                {
                    yield break;
                }
            }
        }
    }

    public int RemoveAll(T element)
    {
        var removed = 0;
        if (this.smallestElements.ContainsKey(element))
        {
            removed = this.smallestElements[element].Count;
        }
        else
        {
            return 0;
        }

        this.firstAndLastElements.RemoveAll(e => e.CompareTo(element) == 0);
        this.smallestElements.Remove(element);
        this.biggestElements.Remove(element);
        this.totalElements -= removed;
        return removed;
    }

    public void Clear()
    {
        this.smallestElements = new SortedDictionary<T, List<T>>(new SmallestElement());
        this.biggestElements = new SortedDictionary<T, List<T>>(new BiggestElement());
        this.firstAndLastElements = new BigList<T>();
        this.totalElements = 0;
    }

    private class SmallestElement : IComparer<T>
    {
        public int Compare(T first, T second)
        {
            return first.CompareTo(second);
        }
    }

    private class BiggestElement : IComparer<T>
    {
        public int Compare(T first, T second)
        {
            return second.CompareTo(first);
        }
    }
}