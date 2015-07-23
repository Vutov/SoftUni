namespace RiversByCountry
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirst.Mapping;

    class RiversByCountry
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var doc = XDocument.Load("../../../rivers-query.xml");
            var queriesRoot = doc.Root.Elements();

            var resultXml = new XDocument();
            var resultRoot = new XElement("results");
            resultXml.Add(resultRoot);

            foreach (var query in queriesRoot)
            {
                var maxResultsAttribute = query.Attribute("max-results");
                var maxResult = -1;
                if (maxResultsAttribute != null)
                {
                    maxResult = int.Parse(maxResultsAttribute.Value);
                }

                var countries = query.Elements().Select(c => c.Value).ToList();
                var rivers = context.Rivers
                    .Where(r => r.Countries.Any(c => countries.Contains(c.CountryName)))
                    .Select(r => r.RiverName)
                    .OrderBy(r => r)
                    .ToList();

                var currentRiversCount = rivers.Count;
                var riversNode = new XElement("rivers");
                riversNode.SetAttributeValue("total-count", currentRiversCount);
                var actualResult = currentRiversCount;
                if (maxResult != -1)
                {
                    if (maxResult < currentRiversCount)
                    {
                        actualResult = maxResult;
                    }
                }

                riversNode.SetAttributeValue("listed-count", actualResult);
                for (int i = 0; i < actualResult; i++)
                {
                    var riverNode = new XElement("river");
                    riverNode.Value = rivers[i];
                    riversNode.Add(riverNode);
                }

                resultRoot.Add(riversNode);
            }

            Console.WriteLine(resultXml);
        }
    }
}