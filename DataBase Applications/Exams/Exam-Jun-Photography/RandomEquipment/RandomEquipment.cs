namespace RandomEquipment
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    public class RandomEquipment
    {
        public static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var rng = new Random();
            var doc = XDocument.Load("../../../generate-equipments.xml");
            var generate = doc.Root.Elements();

            var processCount = 0;
            foreach (var element in generate)
            {
                Console.WriteLine("Processing request #{0} ...", ++processCount);
                var generateCountNode = element.Attribute("generate-count");
                var generateCunt = 10;
                if (generateCountNode != null)
                {
                    generateCunt = int.Parse(generateCountNode.Value);
                }

                var manufacturerNode = element.Element("manufacturer");
                var manufacturer = "Nikon";
                if (manufacturerNode != null)
                {
                    manufacturer = manufacturerNode.Value;
                }

                var cameras = context.Cameras
                    .Where(c => c.Manufacturer.Name == manufacturer)
                    .Select(c => c.Id)
                    .ToList();

                var lens = context.Lenses
                   .Where(c => c.Manufacturer.Name == manufacturer)
                   .Select(c => c.Id)
                   .ToList();

                var users = context.Users.Select(u => u.Id).ToList();

                var photos = context.Photographs.Select(p => p.Id).ToList();

                for (int i = 0; i < generateCunt; i++)
                {
                    var userNumber = rng.Next(0, users.Count);
                    var usersList = new List<User>();
                    for (int j = 0; j < userNumber; j++)
                    {
                        usersList.Add(context.Users.Find(users[rng.Next(0, users.Count)]));
                    }

                    var photoNumber = rng.Next(0, users.Count);
                    var photosList = new List<Photograph>();
                    for (int j = 0; j < photoNumber; j++)
                    {
                        photosList.Add(context.Photographs.Find(photos[rng.Next(0, photos.Count)]));
                    }

                    var equipment = new Equipment()
                    {
                        Camera = context.Cameras.Find(cameras[rng.Next(0, cameras.Count())]),
                        Lens = context.Lenses.Find(lens[rng.Next(0, lens.Count())]),
                        Users = usersList,
                        Photographs = photosList
                    };

                    context.Equipments.Add(equipment);
                    context.SaveChanges();
                    Console.WriteLine("Equipment added: {0} (Camera: {1} - Lens: {2})",
                        manufacturer,
                        equipment.Camera.Model,
                        equipment.Lens.Model);
                }

                Console.WriteLine();
            }
        }
    }
}
