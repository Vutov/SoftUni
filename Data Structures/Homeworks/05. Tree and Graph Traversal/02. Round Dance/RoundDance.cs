namespace _02.Round_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static Dictionary<int, List<int>> relations = new Dictionary<int, List<int>>();

        private static List<int> visited = new List<int>();

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var firstNode = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var node = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (!relations.ContainsKey(node[0]))
                {
                    relations.Add(node[0], new List<int>());
                }

                relations[node[0]].Add(node[1]);

                if (!relations.ContainsKey(node[1]))
                {
                    relations.Add(node[1], new List<int>());
                }

                relations[node[1]].Add(node[0]);
            }

            var longest = FindLongestDance(firstNode, 1);
            Console.WriteLine(longest);
        }

        private static int FindLongestDance(int node, int currentMax)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                currentMax = 1;

                foreach (var childNode in relations[node])
                {
                    currentMax = FindLongestDance(childNode, currentMax);
                }

                currentMax++;
            }

            return currentMax;
        }
    }
}
