namespace Export_the_Manufacturers_and_Cameras_as_JSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using DatabaseFirstMapping;

    class ExportJson
    {
        static void Main(string[] args)
        {
            var directoryToSaveTo = new DirectoryInfo("../../../manufacturers-and-cameras.json");

            var context = new PhotographySystemEntities();
            var manufacturers = context.Manufacturers
                .Select(m => new
                {
                    manufacturer = m.Name,
                    cameras = m.Cameras
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                        .OrderBy(c => c.model)
                })
                .OrderBy(m => m.manufacturer)
                .ToList();

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(manufacturers);
            Console.WriteLine("Saved to {0}", directoryToSaveTo.FullName);
            File.WriteAllText(directoryToSaveTo.FullName, json);
        }
    }
}
