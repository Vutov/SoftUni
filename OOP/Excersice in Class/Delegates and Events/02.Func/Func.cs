using System;
using System.Collections.Generic;

namespace _02.Func
{
    public static class Extension
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var list = new List<T>();
            foreach (var element in collection)
            {
                if (predicate(element))
                {
                    list.Add(element);
                }
                else
                {
                    return list;
                }
            }

            return list;
        }
    }


    class Func
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 6, 11, 3 };

            Console.WriteLine(string.Join(", ", collection.TakeWhile(x => x < 10)));
        }
    }
}
