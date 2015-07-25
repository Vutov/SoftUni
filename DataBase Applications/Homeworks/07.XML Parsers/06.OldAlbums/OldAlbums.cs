namespace _06.OldAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class OldAlbums
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("../../../Catalog.xml");
            var catalog = doc.XPathSelectElements("catalog/album");
            var yearLine = DateTime.Now.Year - 5;

            Console.WriteLine("XPath:");
            foreach (var album in catalog)
            {
                var year = album.Element("year");
                if (year != null)
                {
                    if (int.Parse(year.Value) <= yearLine)
                    {
                        // Just fooling around with try-catch, too lazy to check for nulls :)
                        try
                        {
                            Console.WriteLine("{0}: {1:C}", album.Element("name").Value,
                                decimal.Parse(album.Element("price").Value));
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine("Missing attribute: {0}", ex.Message);
                        }
                    }
                }
            }

            // An other way with LINQ
            Console.WriteLine("LINQ:");

            var linqCatalog = doc.XPathSelectElements("catalog/album")
                .Where(c =>
                {
                    var year = c.Element("year");
                    return year != null && int.Parse(year.Value) <= yearLine;
                })
                .Select(c => new
                {
                    Title = c.Element("name"),
                    Price = c.Element("price"),
                });

            foreach (var album in linqCatalog)
            {
                Console.WriteLine("{0}: {1:C}", album.Title.Value,
                                decimal.Parse(album.Price.Value));
            }
        }
    }
}
