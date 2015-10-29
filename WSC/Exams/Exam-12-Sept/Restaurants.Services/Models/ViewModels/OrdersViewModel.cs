namespace Restaurants.Services.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Restaurants.Models;

    public class OrdersViewModel
    {
        public int Id { get; set; }

        public MealViewModel Meal { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Order, OrdersViewModel>> Create
        {
            get
            {
                return o => new OrdersViewModel()
                {
                    Id = o.Id,
                    CreatedOn = o.CreatedOn,
                    Quantity = o.Quantity,
                    Status = o.OrderStatus,
                    Meal = new MealViewModel()
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    }
                };
            }
        }
    }
}