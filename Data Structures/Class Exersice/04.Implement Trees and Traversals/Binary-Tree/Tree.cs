using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public T Value { get; private set; }

    public IList<Tree<T>> Children { get; private set; }

    public void Print(int depth = 0)
    {
        Console.Write(new string(' ', 2 * depth));
        Console.WriteLine(this.Value);
        foreach (var child in this.Children)
        {
            child.Print(depth + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }
}
