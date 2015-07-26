namespace Artists
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class Artists
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("DOM:");
            var xdoc = XDocument.Load("../../../Catalog.xml");
            var artists = from album in xdoc.Descendants("album")
                          orderby album.Element("artist").Value
                          select new
                            {
                                Author = album.Element("artist").Value
                            };
            artists.ToList().ForEach(a => Console.WriteLine(a.Author));

            Console.WriteLine();
            Console.WriteLine("XPath:");
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            var artistNames = (
                from XmlNode artist in doc.SelectNodes("catalog/album/artist")
                select artist.InnerText)
                .ToList();
            artistNames.Sort();
            artistNames.ForEach(Console.WriteLine);
        }
    }
}
