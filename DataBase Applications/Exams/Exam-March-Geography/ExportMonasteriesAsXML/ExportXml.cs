namespace ExportMonasteriesAsXML
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirst.Mapping;

    public class ExportXml
    {
        public static void Main(string[] args)
        {
            const string SaveXmlIn = @"..\..\..\Monasteries.xml";

            var context = new GeographyEntities();
            var monasteries = context.Countries
                .Where(c => c.Monasteries.Count > 0)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries.Select(m => new
                    {
                        m.Name
                    })
                        .OrderBy(m => m.Name)
                })
                .OrderBy(c => c.CountryName)
                .ToList();

            var xml = new XDocument();
            var root = new XElement("monasteries");
            xml.Add(root);

            monasteries.ForEach(c =>
            {
                var country = new XElement("country");
                country.SetAttributeValue("name", c.CountryName);
                foreach (var monastery in c.Monasteries)
                {
                    var mon = new XElement("monastery", monastery.Name);
                    country.Add(mon);
                }

                root.Add(country);
            });

            xml.Save(SaveXmlIn);
            var directory = new DirectoryInfo(SaveXmlIn);
            Console.WriteLine("XML saved to {0}", directory.FullName);
        }
    }
}
