namespace _04.Artits_and_albums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class ArtistsAndAlbums
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DOM:");
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            var artistsAndAlbums = new Dictionary<string, int>();

            var catalog = doc.DocumentElement;
            foreach (XmlNode album in catalog.ChildNodes)
            {
                var xmlElement = album["artist"];
                if (xmlElement != null)
                {
                    if (!artistsAndAlbums.ContainsKey(xmlElement.InnerText))
                    {
                        artistsAndAlbums.Add(xmlElement.InnerText, 0);
                    }

                    artistsAndAlbums[xmlElement.InnerText]++;
                }
            }

            foreach (var artist in artistsAndAlbums)
            {
                Console.WriteLine("{0} > {1}", artist.Key, artist.Value);
            }

            Console.WriteLine("XPath:");
            var xdoc = new XmlDocument(); 
            xdoc.Load("../../../Catalog.xml");
            var artists =
                (from XmlNode artist in xdoc.SelectNodes("catalog/album/artist")
                select artist.InnerText)
                .ToList();
            var artistInAlbums = new Dictionary<string, int>();
            artists.ForEach( a =>
            {
                if (!artistInAlbums.ContainsKey(a))
                {
                    artistInAlbums.Add(a, 0);
                }

                artistInAlbums[a]++;
            });

            foreach (var artist in artistInAlbums)
            {
                Console.WriteLine("{0} > {1}", artist.Key, artist.Value);
            }
        }
    }
}
