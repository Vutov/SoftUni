using System;
using System.Collections.Generic;


namespace _01.Predicates
{
    public static class Extension
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var element in collection)
            {
                if (condition(element))
                {
                    return element;
                }
            }

            return default(T);
        }

    }

    public class Predicates
    {
        public static void Main(string[] args)
        {
            List<int> collection = new List<int>() {1, 2, 3, 4, 5, 6, 11, 3};

            Console.WriteLine(collection.FirstOrDefault(x => x > 7));
            Console.WriteLine(collection.FirstOrDefault(x => x < 0));
        }
    }
}
