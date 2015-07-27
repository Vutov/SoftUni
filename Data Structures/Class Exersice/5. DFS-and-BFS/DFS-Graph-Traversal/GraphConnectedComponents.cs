using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph;

    //new List<int>() {3, 6},
    //new List<int>() {3, 4, 5, 6},
    //new List<int>() {8},
    //new List<int>() {0, 1, 5},
    //new List<int>() {1, 6},
    //new List<int>() {1, 6},
    //new List<int>() {1, 3},
    //new List<int>() {},
    //new List<int>() {2}

    private static bool[] visited;

    public static void Main()
    {
        ReadGraph();
        FindGraphConnectedComponents();
    }

    private static void DFS(int index)
    {
        if (!visited[index])
        {
            visited[index] = true;

            var node = graph[index];
            foreach (var neighbor in node)
            {

                DFS(neighbor);
            }

            Console.Write(" " + index);
        }
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
    }

    private static void ReadGraph()
    {
        var n = int.Parse(Console.ReadLine());
        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            var node = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            graph[i] = node;
        }
    }
}
