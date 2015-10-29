namespace Topological_Sorting_DFS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TopologicalSorter
    {
        private readonly Dictionary<string, List<string>> graph;

        public TopologicalSorter(Dictionary<string, List<string>> graph)
        {
            this.graph = graph;
        }

        public ICollection<string> TopSort()
        {
            var nodes = new Dictionary<string, int>();

            foreach (var node in this.graph)
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

            var sorted = new List<string>();
            while (true)
            {
                string removeNode = nodes.FirstOrDefault(n => n.Value == 0).Key;
                if (removeNode == null)
                {
                    break;
                }

                if (this.graph.ContainsKey(removeNode))
                {
                    foreach (var decremet in this.graph[removeNode])
                    {
                        nodes[decremet]--;
                    }
                }

                this.graph.Remove(removeNode);
                nodes.Remove(removeNode);
                sorted.Add(removeNode);
            }

            if (this.graph.Count != 0)
            {
                throw new InvalidOperationException("Cycle detected in graph");
            }

            return sorted;
        }
    }
}
