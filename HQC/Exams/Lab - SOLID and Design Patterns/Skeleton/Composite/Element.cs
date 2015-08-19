namespace Composite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Element
    {
        private int displayDepthLevel = 0;
        private const int DisplayDepthSpaces = 2;

        public Element(string type, params Element[] children)
        {
            this.Type = type;
            this.Children = children;
        }

        public string Type { get; set; }

        public ICollection<Element> Children { get; private set; }

        public void Add(Element child)
        {
            if (child == null)
            {
                throw new InvalidOperationException("Child cannot be null!");
            }

            this.Children.Add(child);
        }

        public bool Remove(Element child)
        {
            if (child == null)
            {
                throw new InvalidOperationException("Child cannot be null!");
            }

            var removed = this.Children.Remove(child);
            return removed;
        }

        public string Display()
        {
            var result = this.Display(this, new StringBuilder());
            return result.ToString();
        }

        private StringBuilder Display(Element node, StringBuilder currentTree)
        {
            // Open tag
            currentTree.Append(new string(' ', this.displayDepthLevel * DisplayDepthSpaces))
                .Append("<")
                .Append(node.Type)
                .Append(">")
                .AppendLine();
            this.displayDepthLevel++;

            foreach (var child in node.Children)
            {
                currentTree = this.Display(child, currentTree);
            }

            // Closing tag
            this.displayDepthLevel--;
            currentTree.Append(new string(' ', this.displayDepthLevel * DisplayDepthSpaces))
                .Append("<")
                .Append(node.Type)
                .Append("/>")
                .AppendLine();

            return currentTree;
        }
    }
}
