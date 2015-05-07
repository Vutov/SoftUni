using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class GenericArraySort
{
    private static List<T> GenericSort<T>(T[] arr)
    {
        var sorted = new List<T>();
        var list = new List<T>(arr);
        while (list.Count != 0)
        {
            T min = list.Min();
            list.Remove(min);
            sorted.Add(min);
        }
        return sorted;
    } 

    static void Main(string[] args)
    {
        int[] numbers = {1, 3, 4, 5, 1, 0, 5};
        string[] strings = {"zaz", "cba", "baa", "azis"};
        DateTime[] dates =
        {
            new DateTime(2002, 3, 1),
            new DateTime(2015, 5, 6),
            new DateTime(2014, 1, 1),
        };
        Console.WriteLine(String.Join(", ", GenericSort(numbers)));
        Console.WriteLine(String.Join(", ", GenericSort(strings)));
        Console.WriteLine(String.Join(", ", GenericSort(dates)));
    }
}

