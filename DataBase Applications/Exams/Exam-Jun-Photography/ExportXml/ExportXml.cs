namespace ExportXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    class ExportXml
    {
        static void Main(string[] args)
        {
            var directoryToSaveTo = new DirectoryInfo("../../../photographs.xml");

            var context = new PhotographySystemEntities();
            var photographs = context.Photographs
                .Select(p => new
                {
                    p.Title,
                    CategoryName = p.Category.Name,
                    p.Link,
                    Equipment = new
                    {
                        Camera = new
                        {
                            p.Equipment.Camera.Megapixels,
                            Model = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model
                        },
                        Lens = new
                        {
                            Model = p.Equipment.Lens.Manufacturer.Name + " " +  p.Equipment.Lens.Model,
                            p.Equipment.Lens.Price
                        }
                    },

                })
                .OrderBy(p => p.Title)
                .ToList();

            var xml = new XDocument();
            var root = new XElement("photographs");
            xml.Add(root);
            foreach (var photograph in photographs)
            {
                var photoNode = new XElement("photograph");
                photoNode.SetAttributeValue("title", photograph.Title);
                photoNode.Add(new XElement("category", photograph.CategoryName));
                photoNode.Add(new XElement("link", photograph.Link));
                var equipmentNode = new XElement("equipment");
                var camera = new XElement("camera", photograph.Equipment.Camera.Model);
                camera.SetAttributeValue("megapixels", photograph.Equipment.Camera.Megapixels);
                equipmentNode.Add(camera);
                var lens = new XElement("lens", photograph.Equipment.Lens.Model);
                if (photograph.Equipment.Lens.Price != null)
                {
                    lens.SetAttributeValue("price", photograph.Equipment.Lens.Price);
                }

                equipmentNode.Add(lens);
                photoNode.Add(equipmentNode);
                root.Add(photoNode);
            }

            Console.WriteLine("Saved to {0}", directoryToSaveTo.FullName);
            xml.Save(directoryToSaveTo.FullName);
        }
    }
}
