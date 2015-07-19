namespace _01.PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        private readonly Dictionary<int, Tree> nodeByValue = new Dictionary<int, Tree>();

        public Tree()
        {
            this.Children = new List<Tree>();
        }

        public Tree(int value, params Tree[] children)
            : this()
        {
            this.Value = value;
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public int Value { get; set; }

        public Tree Parent { get; set; }

        public IList<Tree> Children { get; private set; }

        public Tree GetTreeNodeByValue(int value)
        {
            if (!this.nodeByValue.ContainsKey(value))
            {
                this.nodeByValue.Add(value, new Tree(value));
            }

            return this.nodeByValue[value];
        }

        public Tree FindRootNode()
        {
            var rootNode = this.nodeByValue.Values.FirstOrDefault(n => n.Parent == null);

            return rootNode;
        }

        public List<Tree> FindAllLeafs()
        {
            var leafs = this.nodeByValue.Values
                .Where(n => n.Children.Count == 0)
                .OrderBy(n => n.Value)
                .ToList();

            return leafs;
        }

        public List<Tree> FindAllMiddleNodes()
        {
            var nodes = this.nodeByValue.Values
                .Where(n => n.Children.Count != 0 && n.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return nodes;
        }

        /// <summary>
        /// Find leftmost longest path.
        /// </summary>
        /// <returns>Leftmost longest path.</returns>
        public List<Tree> FindLongestPath()
        {
            var firstNode = this.FindRootNode();
            var currentElements = new List<Tree>();
            var bestElements = new List<Tree>();
            bestElements = this.FindLongestPath(firstNode, currentElements, bestElements);
            bestElements.Insert(0, firstNode);

            return bestElements;
        }

        /// <summary>
        /// Finds all paths witch sum is equal to given sum.
        /// </summary>
        /// <param name="sum">Sum to be found.</param>
        /// <returns>All paths equal to the sum.</returns>
        public List<List<Tree>> FindAllPathsWithGivenSum(int sum)
        {
            var firstNode = this.FindRootNode();
            var currentElements = new List<Tree>() { this.FindRootNode() };
            var bestElements = new List<List<Tree>>();
            bestElements = this.FindAllPathsWithGivenSum(sum, firstNode, currentElements, bestElements);

            return bestElements;
        }

        /// <summary>
        /// Finds all paths witch sum is equal to given sum using recursion. 
        /// </summary>
        /// <param name="sum">Sum to be found.</param>
        /// <param name="node">Given child for start point.</param>
        /// <param name="elements">Current path.</param>
        /// <param name="bestElements">All paths equal to the sum.</param>
        /// <returns>All paths equal to the sum.</returns>
        private List<List<Tree>> FindAllPathsWithGivenSum(int sum, Tree node, List<Tree> elements, List<List<Tree>> bestElements)
        {
            var children = node.Children;
            foreach (var child in children)
            {
                elements.Add(child);
                if (elements.Sum(e => e.Value) == sum)
                {
                    bestElements.Add(elements);
                    elements = GetElementsSoFar(child);
                }

                if (child.Children.Count != 0)
                {
                    bestElements = this.FindAllPathsWithGivenSum(sum, child, elements, bestElements);
                }

                elements = GetElementsSoFar(child);
            }

            return bestElements;
        }

        /// <summary>
        /// Gets all element from the root to the given child.
        /// </summary>
        /// <param name="child">Given child.</param>
        /// <returns>Returns all elements above the child.</returns>
        private static List<Tree> GetElementsSoFar(Tree child)
        {
            var elements = new List<Tree>();
            var parent = child.Parent;
            while (parent != null)
            {
                elements.Insert(0, parent);
                parent = parent.Parent;
            }

            return elements;
        }

        /// <summary>
        /// Find leftmost longest path from given node using recursion.
        /// </summary>
        /// <param name="node">Start point for the path.</param>
        /// <param name="elements">Current longest path.</param>
        /// <param name="bestElements">The longest path found.</param>
        /// <returns>The longest path found.</returns>
        private List<Tree> FindLongestPath(Tree node, List<Tree> elements,  List<Tree> bestElements)
        {
            var children = node.Children;
            foreach (var child in children)
            {
                elements.Add(child);
                if (child.Children.Count != 0)
                {
                    bestElements = this.FindLongestPath(child, elements, bestElements);
                }
                
                if (elements.Count > bestElements.Count)
                {
                    bestElements = elements;
                }

                elements = new List<Tree>();
            }

            return bestElements;
        }
    }
}
