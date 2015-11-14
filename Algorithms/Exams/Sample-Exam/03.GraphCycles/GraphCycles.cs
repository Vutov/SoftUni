namespace _03.GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GraphCycles
    {

        private static bool foundCircle = false;

        static void Main(string[] args)
        {
            var nodNumber = int.Parse(Console.ReadLine());
            var graph = new SortedDictionary<int, SortedSet<int>>();
            for (int i = 0; i < nodNumber; i++)
            {
                var data = Regex.Match(Console.ReadLine(), @"(\d+).+?->(\d*.*)").Groups;
                var node = int.Parse(data[1].Value);
                var edges = data[2].Value
                    .Split(' ')
                    .Where(e => e != string.Empty)
                    .Select(int.Parse)
                    .ToList();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new SortedSet<int>());
                }

                for (int j = 0; j < edges.Count(); j++)
                {
                    graph[node].Add(edges[j]);
                }
            }

            foreach (var node in graph)
            {
                FindCircles(graph, node.Key, new List<int>() { node.Key });
            }

            if (!foundCircle)
            {
                Console.WriteLine("No cycles found");
            }
        }

        private static void FindCircles(IDictionary<int, SortedSet<int>> graph, int node, List<int> visitedNodes, int level = 1)
        {
            if (level == 3)
            {
                var startNode = visitedNodes[0];
                var lastNode = graph[visitedNodes.Last()];
                if (lastNode.Contains(startNode))
                {
                    foundCircle = true;
                    Console.WriteLine("{{{0}}}", string.Join(" -> ", visitedNodes));
                }

                return;
            }

            foreach (var child in graph[node])
            {
                if (!visitedNodes.Contains(child) && child > visitedNodes[0])
                {
                    visitedNodes.Add(child);
                    FindCircles(graph, child, visitedNodes, level + 1);
                    visitedNodes.Remove(child);
                }
            }
        }
    }
}
