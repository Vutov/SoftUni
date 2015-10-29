namespace Restaurants.Data.DataLayer
{
    using Models;
    using Repositories;
    using Restauranteur.Models;

    public interface IRestaurantData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<Rating> Ratings { get;}

        IRepository<Town> Towns { get;}

        IRepository<Restaurant> Restaurants { get;}

        IRepository<Meal> Meals { get;}

        IRepository<MealType> MealTypes { get;}

        IRepository<Order> Orders { get;}

        int SaveChanges();
    }
}
