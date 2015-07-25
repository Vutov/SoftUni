namespace Extract_Album_Names
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ExtractNames
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            var rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var xmlElement = node["name"];
                if (xmlElement != null)
                {
                    Console.WriteLine("Album name: {0}", xmlElement.InnerText);
                }
            }
        }
    }
}
