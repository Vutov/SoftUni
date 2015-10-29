using System;
using System.Linq;

class PlayWithFirstLastList
{
    static void Main()
    {
        var items = new FirstLastList<string>();
        items.Add("zero");
        Console.WriteLine("Count: {0}", items.Count);
        Console.WriteLine("First: {0}", items.First(1).FirstOrDefault());
        Console.WriteLine("Last: {0}", items.Last(1).FirstOrDefault());
        Console.WriteLine("Min: {0}", items.Min(1).FirstOrDefault());
        Console.WriteLine("Max: {0}", items.Max(1).FirstOrDefault());

        items.Clear();

        items.Add("first");
        items.Add("second");
        items.Add("third");
        items.Add("fourth");
        Console.WriteLine("Count: {0}", items.Count);
        Console.WriteLine("First: {0}", items.First(1).FirstOrDefault());
        Console.WriteLine("Last: {0}", items.Last(1).FirstOrDefault());
        Console.WriteLine("Min: {0}", items.Min(1).FirstOrDefault());
        Console.WriteLine("Max: {0}", items.Max(1).FirstOrDefault());

        Console.WriteLine("RemoveAll('first'): {0}", 
            items.RemoveAll("first"));
        Console.WriteLine("RemoveAll('fourth'): {0}", 
            items.RemoveAll("fourth"));
        Console.WriteLine("RemoveAll('first'): {0}",
            items.RemoveAll("first"));
        Console.WriteLine("Count: {0}", items.Count);
        Console.WriteLine("First: {0}", items.First(1).FirstOrDefault());
        Console.WriteLine("Last: {0}", items.Last(1).FirstOrDefault());
        Console.WriteLine("Min: {0}", items.Min(1).FirstOrDefault());
        Console.WriteLine("Max: {0}", items.Max(1).FirstOrDefault());
    }
}
