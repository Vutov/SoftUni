namespace Restaurants.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Restauranteur.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RestaurantsContext context)
        {
            if (!context.Towns.Any())
            {
                SeedTowns(context);
            }

            if (!context.MealTypes.Any())
            {
                SeedMealTypes(context);
            }
        }

        private static void SeedMealTypes(RestaurantsContext context)
        {
            var mealTypes = new[]
            {
                new MealType {Name = "Salad", Order = 10},
                new MealType {Name = "Soup", Order = 20},
                new MealType {Name = "Main", Order = 30},
                new MealType {Name = "Dessert", Order = 40}
            };

            foreach (var mealType in mealTypes)
            {
                context.MealTypes.Add(mealType);
            }

            context.SaveChanges();
        }

        private static void SeedTowns(RestaurantsContext context)
        {
            var towns = new[]
            {
                new Town {Name = "Plovdiv"},
                new Town {Name = "Sofia"},
                new Town {Name = "Pernik"},
                new Town {Name = "Burgas"},
                new Town {Name = "Kurtovo Konare"}
            };

            foreach (var town in towns)
            {
                context.Towns.Add(town);
            }

            context.SaveChanges();
        }
    }
}
