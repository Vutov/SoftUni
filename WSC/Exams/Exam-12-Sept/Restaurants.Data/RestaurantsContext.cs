namespace Restaurants.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;
    using Restauranteur.Models;

    public class RestaurantsContext : IdentityDbContext<ApplicationUser>
    {
        public RestaurantsContext()
            : base("RestaurantsContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<RestaurantsContext, Configuration>());
        }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Restaurant> Restaurants { get; set; }

        public virtual IDbSet<Meal> Meals { get; set; }

        public virtual IDbSet<MealType> MealTypes { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public static RestaurantsContext Create()
        {
            return new RestaurantsContext();
        }
    }
}