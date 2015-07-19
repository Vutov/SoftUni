namespace _01.PlayWithTrees
{
    using System;
    using System.Linq;

    public class TreeTests
    {
        public static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            var tree = new Tree();
            for (int i = 1; i < nodeCount; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var parentValue = edge[0];
                var parentNode = tree.GetTreeNodeByValue(parentValue);
                var chieldValue = edge[1];
                var chieldNode = tree.GetTreeNodeByValue(chieldValue);
                chieldNode.Parent = parentNode;
                parentNode.Children.Add(chieldNode);
            }

            var pathSum = int.Parse(Console.ReadLine());
            var subreeSum = int.Parse(Console.ReadLine());

            var rootNode = tree.FindRootNode();
            Console.WriteLine("First Node: {0}", rootNode.Value);
            var leafs = tree.FindAllLeafs().Select(l => l.Value);
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafs));
            var middleNodes = tree.FindAllMiddleNodes().Select(l => l.Value);
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));
            var longesPath = tree.FindLongestPath().Select(l => l.Value);
            Console.WriteLine("Longest path: {0} (length = {1})", 
                string.Join(" -> ", longesPath), longesPath.Count());
            var sumPaths = tree.FindAllPathsWithGivenSum(pathSum);
            Console.WriteLine("Path of sum: {0}", pathSum);
            foreach (var sumPath in sumPaths)
            {
                var path = sumPath.Select(p => p.Value);
                Console.WriteLine("{0}", string.Join(" -> ", path));
            }
        }
    }
}
