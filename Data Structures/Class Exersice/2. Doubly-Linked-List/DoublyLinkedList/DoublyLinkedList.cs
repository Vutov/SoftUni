using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PreviusNode { get; set; }

        public T Value { get; private set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> start;

    private ListNode<T> end;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newHead = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.start = newHead;
            this.end = newHead;
        }
        else
        {
            newHead.NextNode = this.start;
            this.start.PreviusNode = newHead;
            this.start = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        var newTail = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.start = newTail;
            this.end = newTail;
        }
        else
        {
            newTail.PreviusNode = this.end;
            this.end.NextNode = newTail;
            this.end = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        var removed = this.start.Value;
        this.start = this.start.NextNode;
        if (this.start != null)
        {
            this.start.PreviusNode = null;
        }
        else
        {
            this.end = null;
        }

        this.Count--;

        return removed;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        var removed = this.end.Value;
        this.end = this.end.PreviusNode;
        if (this.end != null)
        {
            this.end.NextNode = null;
        }
        else
        {
            this.start = null;
        }

        this.Count--;

        return removed;
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
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        if (this.Count > 0)
        {
            var currElement = this.start;
            var index = 0;
            while (currElement != null)
            {
                arr[index] = currElement.Value;

                currElement = currElement.NextNode;
                index++;
            }
        }

        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
