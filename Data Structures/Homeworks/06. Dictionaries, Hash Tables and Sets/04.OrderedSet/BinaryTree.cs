namespace _04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> where T : IComparable<T>
    {
        private int treeCount;

        public BinaryTree(T value)
        {
            this.Value = value;
            this.Child = new BinaryTree<T>[2];
            this.treeCount = 1;
        }

        public T Value { get; set; }

        public BinaryTree<T> Parent { get; private set; }

        public BinaryTree<T>[] Child { get; private set; }

        public void Add(T element)
        {
            this.AddToProperPlace(this, new BinaryTree<T>(element));
        }

        public bool Contains(T element)
        {
            var foundElement = this.Contains(this, element);
            if (foundElement)
            {
                return true;
            }

            return false;
        }

        public void Remove(T element)
        {
            if (!this.Contains(element))
            {
                var message = string.Format("{0} not found!", element);
                throw new InvalidOperationException(message);
            }

            this.Remove(this, element);
        }

        public int Count()
        {
            this.GetCount(this);
            return this.treeCount;
        }

        public ICollection<T> GetElementsByValue()
        {
            var elements = this.GetElementsByValue(this, new List<T>());
            var sortedElements = this.SortValues(elements);

            return sortedElements;
        }

        /// <summary>
        /// Finds the right place where to put the new node depending on the node 
        /// value. Implements binary search tree structure.
        /// </summary>
        /// <param name="parent">Parent node.</param>
        /// <param name="node">New parent node.</param>
        private void AddToProperPlace(BinaryTree<T> parent, BinaryTree<T> node)
        {
            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];
            var isLeftOfParent = parent.Value.CompareTo(node.Value) > 0;

            if (leftChild != null && rightChild != null)
            {
                if (isLeftOfParent)
                {
                    this.AddToProperPlace(leftChild, node);
                }
                else
                {
                    this.AddToProperPlace(rightChild, node);
                }
            }
            else if (leftChild != null)
            {
                if (isLeftOfParent)
                {
                    this.AddToProperPlace(leftChild, node);
                }
                else
                {
                    parent.Child[1] = node;
                    node.Parent = parent;
                }
            }
            else if (rightChild != null)
            {
                if (isLeftOfParent)
                {
                    parent.Child[0] = node;
                    node.Parent = parent;
                }
                else
                {
                    this.AddToProperPlace(rightChild, node);
                }
            }
            else
            {
                if (isLeftOfParent)
                {
                    parent.Child[0] = node;
                }
                else
                {
                    parent.Child[1] = node;
                }

                node.Parent = parent;
            }
        }

        private void GetCount(BinaryTree<T> parent)
        {
            foreach (var child in parent.Child)
            {
                if (child != null)
                {
                    this.treeCount++;
                    this.GetCount(child);
                }
            }
        }

        /// <summary>
        /// Binary search for element. If isFound return it, if not isFound return null.
        /// </summary>
        /// <param name="parent">Parent to start search from.</param>
        /// <param name="element">Element to find.</param>
        /// <param name="isFound">Is the element isFound.</param>
        /// <returns>If isFound node, else null.</returns>
        private bool Contains(BinaryTree<T> parent, T element, bool isFound = false)
        {
            if (parent.Value.Equals(element))
            {
                return true;
            }

            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];
            var isLeftOfParent = parent.Value.CompareTo(element) > 0;

            if (leftChild != null && isLeftOfParent)
            {
               isFound = this.Contains(leftChild, element);
            }

            if (rightChild != null && !isLeftOfParent)
            {
                isFound = this.Contains(rightChild, element);
            }

            return isFound;
        }

        /// <summary>
        /// Recursively searches and removes node by given value.
        /// </summary>
        /// <param name="parent">Starting point of the search.</param>
        /// <param name="elementValue">Value of the element searching for.</param>
        private void Remove(BinaryTree<T> parent, T elementValue)
        {
            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];

            if (parent.Value.Equals(elementValue))
            {
                var grandDaddy = parent.Parent;
                var newParent = leftChild;
                if (newParent == null)
                {
                    newParent = rightChild;
                }

                if (leftChild != null && rightChild != null)
                {
                    if (leftChild.Value.CompareTo(rightChild.Value) > 0)
                    {
                        newParent = leftChild;
                        if (newParent.Child[0] == null)
                        {
                            newParent.Child[0] = rightChild;
                        }
                        else if (newParent.Child[1] == null)
                        {
                            newParent.Child[1] = rightChild;
                        }
                        else
                        {
                            this.Remove(rightChild.Value);
                            this.Add(rightChild.Value);
                        }

                        rightChild.Parent = newParent;
                    }
                    else
                    {
                        newParent = rightChild;
                        if (newParent.Child[0] == null)
                        {
                            newParent.Child[0] = leftChild;
                        }
                        else if (newParent.Child[1] == null)
                        {
                            newParent.Child[1] = leftChild;
                        }
                        else
                        {
                            this.Remove(leftChild.Value);
                            this.Add(leftChild.Value);
                        }

                        leftChild.Parent = newParent;
                    }
                }

                newParent.Parent = grandDaddy;
                if (grandDaddy.Child[0] == parent)
                {
                    grandDaddy.Child[0] = newParent;
                }
                else
                {
                    grandDaddy.Child[1] = newParent;
                }
            }

            var isLeftOfParent = parent.Value.CompareTo(elementValue) > 0;
            if (leftChild != null && isLeftOfParent)
            {
                this.Remove(leftChild, elementValue);
            }

            if (rightChild != null && !isLeftOfParent)
            {
                this.Remove(rightChild, elementValue);
            }
        }

        /// <summary>
        /// Recursively gets all elements in the tree.
        /// </summary>
        /// <param name="parent">Start point in the tree.</param>
        /// <param name="elements">Current elements.</param>
        /// <returns>All elements.</returns>
        private List<T> GetElementsByValue(BinaryTree<T> parent, List<T> elements)
        {
            elements.Add(parent.Value);
            foreach (var child in parent.Child)
            {
                if (child != null)
                {
                    elements = this.GetElementsByValue(child, elements);
                }
            }

            return elements;
        }

        /// <summary>
        /// Insertion sort.
        /// </summary>
        /// <param name="values">Given values to be sorted.</param>
        /// <returns>Sorted values.</returns>
        private ICollection<T> SortValues(List<T> values)
        {
            bool sort = true;
            while (sort)
            {
                sort = false;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i].CompareTo(values[i + 1]) > 0)
                    {
                        T swapper = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = swapper;
                        sort = true;
                    }
                }
            }

            return values;
        }
    }
}
