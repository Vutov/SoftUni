using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shortest_Path_in_Matrix
{
    class ShortestPath
    {
        static List<int> Dijkstra(int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);

            // Initialize the distance[]
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceNode] = 0;

            // Dijkstra's algorithm implemented without priority queue
            var used = new bool[n];
            int?[] previous = new int?[n];
            while (true)
            {
                // Find the nearest unused node from the source
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    // No min distance node found --> algorithm finished
                    break;
                }

                used[minNode] = true;

                // Improve the distance[0…n-1] through minNode
                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                // No path found from sourceNode to destinationNode
                return null;
            }

            // Reconstruct the shortest path from sourceNode to destinationNode
            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }
            path.Reverse();
            return path;
        }

        public static void Main()
        {
            var height = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());

            var matrix = new int[height, width];
            for (int row = 0; row < height; row++)
            {
                var data = Console.ReadLine().Split(' ');
                for (int col = 0; col < data.Length; col++)
                {
                    var node = int.Parse(data[col]);
                    matrix[row, col] = node;
                }
            }

            var size = width * height;
            var graph = new int[size, size];
            var number = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col + 1 < width)
                    {
                        var rightValue = matrix[row, col + 1];
                        var rightNumber = number + 1;
                        graph[number, rightNumber] = rightValue;
                    }

                    if (col - 1 >= 0)
                    {
                        var leftValue = matrix[row, col - 1];
                        var leftNumber = number - 1;
                        graph[number, leftNumber] = leftValue;
                    }

                    if (row - 1 >= 0)
                    {
                        var upValue = matrix[row - 1, col];
                        var upNumber = number - width;
                        graph[number, upNumber] = upValue;
                    }

                    if (row + 1 < height)
                    {
                        var downValue = matrix[row + 1, col];
                        var downNumber = number + width;
                        graph[number, downNumber] = downValue;
                    }

                    number++;
                }
            }

            //for (int i = 0; i < graph.GetLength(0); i++)
            //{
            //    for (int j = 0; j < graph.GetLength(1); j++)
            //    {
            //        Console.Write(graph[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            //// For 4 nodes
            //// 0 - {1, 2}
            //// 1 - {0, 3}
            //// 2 - {0, 4}
            //// 3 - {1, 2}
            //// As matrix:
            //// 2 4
            //// 9 1 
            
            //    var graphTest = new[,]
            //{
            //    // 0   1   2   3 
            //    {  0,  4,  9,  0}, // 0
            //    {  2,  0,  0,  1}, // 1
            //    {  2,  0,  0,  1}, // 2
            //    {  0,  4,  9,  0}, // 3
            //};

            FindAndPrintShortestPath(graph, matrix, 0, number - 1);
        }

        static void FindAndPrintShortestPath(int[,] graph, int[,] matrix, int sourceNode, int destinationNode)
        {
            var path = Dijkstra(graph, sourceNode, destinationNode);
            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                int pathLength = matrix[0, 0]; // Start point
                var formattedPath = new StringBuilder();
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                    var row = path[i] / matrix.GetLength(1);
                    var col = path[i] % matrix.GetLength(1);
                    formattedPath.Append(" " + matrix[row, col]);
                }

                // Last
                formattedPath.Append(" " + matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);

                Console.WriteLine("Length: {0}", pathLength);
                Console.WriteLine("Path: {0}", formattedPath);
            }
        }
    }
}
