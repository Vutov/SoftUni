namespace DatabaseFirst.Mapping
{
    using System;
    using System.Linq;

    public class Client
    {
        public static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var contitentNames = context.Continents.Select(c => c.ContinentName).ToList();
            contitentNames.ForEach(Console.WriteLine);
        }
    }
}
