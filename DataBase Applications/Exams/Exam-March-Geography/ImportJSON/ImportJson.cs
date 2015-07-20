namespace ImportJSON
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using CodeFirst.DataModel.Data;
    using CodeFirst.DataModel.Models;
    using Models;

    internal class ImportJson
    {
        private static void Main(string[] args)
        {
            var json = File.ReadAllText("../../../Mountains.json");

            var serializer = new JavaScriptSerializer();
            var mountains = serializer.Deserialize<MountainJson[]>(json);

            foreach (var mountain in mountains)
            {
                try
                {
                    ImportMountain(mountain);
                    Console.WriteLine("Mountain {0} imported", mountain.MountainName);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportMountain(MountainJson mountain)
        {
            var context = new MountainsContext();

            if (string.IsNullOrEmpty(mountain.MountainName))
            {
                throw new ArgumentException("Mountain name is required.");
            }

            var peaks = new List<Peak>();
            foreach (var peak in mountain.Peaks)
            {
                if (string.IsNullOrEmpty(peak.PeakName))
                {
                    throw new ArgumentException("Peak name is required.");
                }

                if (peak.Elevation == null)
                {
                    throw new ArgumentException("Peak elevation is required.");
                }

                var dataPeak = new Peak()
                {
                    Name = peak.PeakName,
                    Elevation = (int)peak.Elevation
                };

                peaks.Add(dataPeak);
            }

            var countries = mountain.Countries
                .Select(country => new Country()
                {
                    CountryName = country,
                    CountryCode = country.Substring(0, 2).ToUpper()
                })
                .ToList();

            var dataMountain = new Mountain()
            {
                Name = mountain.MountainName,
                Countries = countries,
                Peaks = peaks
            };

            context.Mountains.AddOrUpdate(dataMountain);
            context.SaveChanges();
        }
    }
}

