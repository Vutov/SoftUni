using System.Collections.Generic;

namespace HTMLDispatcher
{
    class ElementBuilder
    {
        private string elementName;
        private string attributes;
        private string content;

        public string ElementName
        {
            get
            {
                return this.elementName;
            }
            set
            {
                this.elementName = value;
            }
        }

        public ElementBuilder(string name)
        {
            this.ElementName = name;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attributes += string.Format(" {0}=\"{1}\"", attribute, value);
        }

        public void AddContent(string content)
        {
            this.content += string.Format("{0}", content);
        }

        public override string ToString()
        {
            return string.Format("<{0}{1}>{2}</{0}>", this.elementName, this.attributes, this.content);
        }

        public static string operator *(ElementBuilder element, int multiply)
        {
            var result = new List<ElementBuilder>();
            for (int i = 0; i < multiply; i++)
            {
                result.Add(element);
            }

            return string.Join("\n", result);
        }
    }
}
