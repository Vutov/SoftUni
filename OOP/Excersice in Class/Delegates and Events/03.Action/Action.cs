using System;
using System.Collections.Generic;

namespace _03.Action
{
    public static class Extension
    {
        public static void ForE<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }


    class Action
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 6, 11, 3 };

            collection.ForE(Console.WriteLine);
        }
    }
}
