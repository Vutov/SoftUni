namespace ExportRiversAsJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using DatabaseFirst.Mapping;

    public class ExportRiversJson
    {
        public static void Main(string[] args)
        {
            const string SaveJsonIn = @"..\..\..\Rivers.Json";

            var context = new GeographyEntities();
            var rivers = context.Rivers
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries
                        .Select(c => c.CountryName)
                        .OrderBy(c => c)
                })
                .OrderByDescending(r => r.riverLength)
                .ToList();

            var serializer = new JavaScriptSerializer();
            var serializedJson = serializer.Serialize(rivers);

            var directory = new DirectoryInfo(SaveJsonIn);
            File.WriteAllText(SaveJsonIn, serializedJson);
            Console.WriteLine("JSON saved to {0}", directory.FullName);
            //Console.WriteLine(serializedJson);
        }
    }
}
