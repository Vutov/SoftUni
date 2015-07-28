namespace DatabaseFirstMapping
{
    using System;
    using System.Linq;

    class Client
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var models = context.Cameras
                .Select(c => new
                {
                    Manufacturer = c.Manufacturer.Name,
                    Model = c.Model
                })
                .OrderBy(c => c.Manufacturer + " " + c.Model)
                .ToList();

            models.ForEach(m =>
            {
                Console.WriteLine("{0} {1}", m.Manufacturer, m.Model);
            });
        }
    }
}
