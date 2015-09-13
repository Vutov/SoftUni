namespace Restaurants.Services.Models.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Restaurants.Models;

    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create
        {
            get
            {
                return r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Count == 0 ? 0 : r.Ratings.Select(ra => ra.Stars).Average(),
                    Town = new TownViewModel()
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    }
                };
            }
        }
    }
}