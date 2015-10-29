using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Cycles_in_a_Graph
{
    using System.Text.RegularExpressions;

    class Cycles
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var graph = new Dictionary<string, List<string>>();
            while (line != string.Empty)
            {
                var data = Regex.Split(line, @"\W+");
                var key = data[0];
                if (!graph.ContainsKey(key))
                {
                    graph.Add(key, new List<string>());
                }

                for (int i = 1; i < data.Count(); i++)
                {
                    if (data[i] != string.Empty)
                    {
                        graph[key].Add(data[i]);
                        if (!graph.ContainsKey(data[i]))
                        {
                            graph.Add(data[i], new List<string>());
                        }

                        graph[data[i]].Add(key);
                    }
                }

                line = Console.ReadLine();
            }

            Console.Write("Acyclic: ");
            if (IsAcyclic(graph))
            {
                Console.Write("Yes\n");
            }
            else
            {
                Console.Write("No\n");
            }

        }

        public static bool IsAcyclic(Dictionary<string, List<string>> graph)
        {
            var nodes = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                if (!nodes.ContainsKey(node.Key))
                {
                    nodes.Add(node.Key, 0);
                }

                foreach (var connection in node.Value)
                {
                    if (!nodes.ContainsKey(connection))
                    {
                        nodes.Add(connection, 0);
                    }

                    nodes[connection] = nodes[connection] + 1;
                }
            }

            while (true)
            {
                string removeNode = nodes.FirstOrDefault(n => n.Value == 1).Key;
                if (removeNode == null)
                {
                    break;
                }

                if (graph.ContainsKey(removeNode))
                {
                    foreach (var decremet in graph[removeNode])
                    {
                        if (nodes.ContainsKey(decremet))
                        {
                            nodes[decremet]--;
                        }
                    }
                }

                graph.Remove(removeNode);
                nodes.Remove(removeNode);
            }

            if (graph.Count != 1)
            {
                return false;
            }

            return true;
        }
    }
}
