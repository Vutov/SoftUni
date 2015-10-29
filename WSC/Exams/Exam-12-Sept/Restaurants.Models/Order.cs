namespace Restaurants.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Delivered
    }
}
