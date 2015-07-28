namespace ImportXml
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    public class ImportXml
    {
        public static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();

            var xml = XDocument.Load("../../../manufacturers-and-lenses.xml");
            var manufacturers = xml.Root.Elements();
            var processCounter = 0;
            foreach (var node in manufacturers)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", ++processCounter);
                try
                {
                    var manufacturer = ProcessManufacturer(context, node);
                    var lensesNode = node.Element("lenses");
                    if (lensesNode != null)
                    {
                        var lenses = lensesNode.Elements();
                        foreach (var lense in lenses)
                        {
                            try
                            {
                                ProcessLenses(context, lense, manufacturer);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.Error.WriteLine("Processing lens terminated: {0}", ex.Message);
                            }
                        }
                    }

                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine("Processing manufacture terminated: {0}", ex.Message);
                }
            }

        }

        private static Manufacturer ProcessManufacturer(PhotographySystemEntities context, XElement manufacturer)
        {
            var manufacturerNameNode = manufacturer.Element("manufacturer-name");
            if (manufacturerNameNode == null)
            {
                throw new ArgumentException("Manufacturer name is mandatory!");
            }

            var name = manufacturerNameNode.Value;
            var processedManufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == name);
            if (processedManufacturer == null)
            {
                processedManufacturer = new Manufacturer()
                {
                    Name = name
                };

                context.Manufacturers.Add(processedManufacturer);
                context.SaveChanges();
                Console.WriteLine("Created manufacturer: {0}", processedManufacturer.Name);
            }
            else
            {
                Console.WriteLine("Existing manufacturer: {0}", processedManufacturer.Name);
            }

            return processedManufacturer;
        }

        private static void ProcessLenses(PhotographySystemEntities context, XElement lense, Manufacturer manufacturer)
        {
            var modelNode = lense.Attribute("model");
            if (modelNode == null)
            {
                throw new ArgumentException("Model is mandatory for lenses!");
            }

            var model = modelNode.Value;
            var typeNode = lense.Attribute("type");
            if (typeNode == null)
            {
                throw new ArgumentException("Type is required for lenses!");
            }

            var type = typeNode.Value;
            decimal? price = null;
            var priceNode = lense.Attribute("price");
            if (priceNode != null)
            {
                price = decimal.Parse(priceNode.Value);
            }

            Lens processedLense = context.Lenses.FirstOrDefault(l => l.Model == model);
            if (processedLense == null)
            {
                processedLense = new Lens()
                {
                    Model = model,
                    Type = type,
                    Price = price,
                    Manufacturer = manufacturer
                };

                context.Lenses.AddOrUpdate(processedLense);
                context.SaveChanges();
                Console.WriteLine("Created lens: {0}", processedLense.Model);
            }
            else
            {
                Console.WriteLine("Existing lens: {0}", processedLense.Model);
            }
        }
    }
}
