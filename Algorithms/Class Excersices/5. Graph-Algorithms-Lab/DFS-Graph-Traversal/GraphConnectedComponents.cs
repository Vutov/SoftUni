using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph = new List<int>[]
    {
        new List<int>() { 3, 6 },
        new List<int>() { 3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() { },
        new List<int>() { 2 }
    };


    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        bool[] usedNodes = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            var connections = DFS(i, usedNodes, new List<int>());
            if (connections.Count != 0)
            {
                Console.WriteLine("Connected component: {0}", string.Join(" ", connections));
            }
        }
    }

    private static ICollection<int> DFS(int node, bool[] usedNodes, ICollection<int> connections)
    {
        if (usedNodes[node] == false)
        {
            usedNodes[node] = true;
            foreach (var childIndex in graph[node])
            {
                connections = DFS(childIndex, usedNodes, connections);
            }

            connections.Add(node);
        }

        return connections;
    }
}
