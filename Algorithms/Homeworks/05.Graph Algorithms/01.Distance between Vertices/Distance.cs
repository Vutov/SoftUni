using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Distance_between_Vertices
{
    using System.Text.RegularExpressions;

    public class Distance
    {
        private static int distance = int.MaxValue;

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine();
            var line = Console.ReadLine();
            var graph = new Dictionary<int, List<int>>();
            while (line != "Distances to find:")
            {
                var data = Regex.Split(line, @"\D+");
                var key = int.Parse(data[0]);
                if (!graph.ContainsKey(key))
                {
                    graph.Add(key, new List<int>());
                }

                for (int i = 1; i < data.Count(); i++)
                {
                    if (data[i] != string.Empty)
                    {
                        graph[key].Add(int.Parse(data[i]));
                    }
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != string.Empty)
            {
                var data = Regex.Split(line, @"\D+");
                var start = int.Parse(data[0]);
                var end = int.Parse(data[1]);

                DFS(graph, start, end, new List<int>(), new List<int>());
                if (distance == int.MaxValue)
                {
                    Console.WriteLine("{{{0}, {1}}} -> {2}", start, end, -1);
                }
                else
                {
                    Console.WriteLine("{{{0}, {1}}} -> {2}", start, end, distance);
                    distance = int.MaxValue;
                }

                line = Console.ReadLine();
            }
        }

        private static void DFS(Dictionary<int, List<int>> graph, int start, int end, List<int> visited, List<int> path)
        {
            if (start == end)
            {
                if (distance > path.Count)
                {
                    distance = path.Count;
                }
                return;
            }

            if (!visited.Contains(start))
            {
                visited.Add(start);
                foreach (var node in graph[start])
                {
                    if (!visited.Contains(node))
                    {
                        path.Add(node);
                        DFS(graph, node, end, visited, path);
                        path.Remove(node);
                        visited.Remove(node);
                    }
                }
            }
        }
    }
}
