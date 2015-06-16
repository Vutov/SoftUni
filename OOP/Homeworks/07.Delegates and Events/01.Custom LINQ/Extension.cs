using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Custom_LINQ
{
    public static class Extension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var list = new List<T>();
            foreach (var element in collection)
            {
                if (!predicate(element))
                {
                    list.Add(element);
                }
            }

            return list;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> predicate) where TSelector : IComparable
        {
            var max = default(TSelector);
            foreach (var element in collection)
            {
                if (predicate(element).CompareTo(max) > 0)
                {
                    max = predicate(element);
                }
            }

            return max;
        }

    }
}
