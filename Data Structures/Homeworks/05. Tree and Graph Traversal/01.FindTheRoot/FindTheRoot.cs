namespace _01.FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTheRoot
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var hasParent = new bool[n + 1];

            for (int i = 0; i < n; i++)
            {
                var node = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                hasParent[node[1]] = true;
            }

            var parents = new List<int>();
            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    parents.Add(i);
                }
            }

            if (parents.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (parents.Count > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }
            else
            {
                Console.WriteLine(parents[0]);
            }
        }
    }
}
