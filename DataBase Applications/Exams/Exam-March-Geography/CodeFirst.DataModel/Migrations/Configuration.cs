namespace CodeFirst.DataModel.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MountainsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MountainsContext context)
        {
            if (!context.Countries.Any())
            {
                var bulgaria = new Country()
                {
                    CountryName = "Bulgaria",
                    CountryCode = "BG"
                };

                context.Countries.AddOrUpdate(bulgaria);

                var germany = new Country()
                {
                    CountryName = "Germany",
                    CountryCode = "GE"
                };

                context.Countries.AddOrUpdate(germany);

                var rila = new Mountain()
                {
                    Name = "Rila",
                    Countries = new List<Country>() {bulgaria},
                    Peaks = new List<Peak>()
                    {
                        new Peak()
                        {
                            Name = "Musala",
                            Elevation = 2925
                        },
                        new Peak()
                        {
                            Name = "Malyovitsa",
                            Elevation = 2729
                        }
                    }
                };

                context.Mountains.AddOrUpdate(rila);

                var pirin = new Mountain()
                {
                    Name = "Pirin",
                    Countries = new List<Country>() { bulgaria },
                    Peaks = new List<Peak>()
                    {
                        new Peak()
                        {
                            Name = "Vihren",
                            Elevation = 2914
                        }
                    }
                };

                context.Mountains.AddOrUpdate(pirin);

                var rhodopes = new Mountain()
                {
                    Name = "Rhodopes",
                    Countries = new List<Country>() { bulgaria },
                    Peaks = new List<Peak>()
                };

                context.Mountains.AddOrUpdate(rhodopes);

                context.SaveChanges();
            }
        }
    }
}
