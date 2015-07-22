namespace ImportRiversFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirst.Mapping;

    class ImportRiversXml
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var doc = XDocument.Load("../../../Rivers.xml");
            var rivers = doc.Root.Elements();
            foreach (XElement river in rivers)
            {
                try
                {
                    var importRiver = ParseRiver(context, river);
                    ImportRiver(context, importRiver);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static River ParseRiver(GeographyEntities context, XElement river)
        {
            if (string.IsNullOrEmpty(river.Element("name").Value))
            {
                throw new ArgumentException("River's name is mandatory!");
            }

            var name = river.Element("name").Value;

            if (string.IsNullOrEmpty(river.Element("length").Value))
            {
                throw new ArgumentException("River's length is mandatory!");
            }

            var length = int.Parse(river.Element("length").Value);

            if (string.IsNullOrEmpty(river.Element("outflow").Value))
            {
                throw new ArgumentException("River's outflow is mandatory!");
            }

            var outflow = river.Element("outflow").Value;

            int? drainageArea = null;
            var drainageNode = river.Element("drainage-area");
            if (drainageNode != null)
            {
                drainageArea = int.Parse(river.Element("drainage-area").Value);
            }

            int? avgDischarge = null;
            var dischargeNode = river.Element("average-discharge");
            if (dischargeNode != null)
            {
                avgDischarge = int.Parse(river.Element("average-discharge").Value);
            }

            var countries = new List<Country>();
            var countryNode = river.Element("countries").Elements();
            foreach (var country in countryNode)
            {
                var countryName = country.Value;
                var riverCountry = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                if (riverCountry == null)
                {
                    throw new ArgumentException("{0} not found in db!", countryName);
                }

                countries.Add(riverCountry);
            }

            var newRiver = new River()
            {
                RiverName = name,
                Length = length,
                Outflow = outflow,
                DrainageArea = drainageArea,
                AverageDischarge = avgDischarge,
                Countries = countries
            };

            return newRiver;
        }

        private static void ImportRiver(GeographyEntities context, River river)
        {
            context.Rivers.AddOrUpdate(river);
            context.SaveChanges();
            Console.WriteLine("{0} saved to the db.", river.RiverName);
        }
    }
}
