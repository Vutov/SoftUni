namespace Restaurants.Models
{
    using System.ComponentModel.DataAnnotations;
    using Restauranteur.Models;

    public class Meal
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public int TypeId { get; set; }

        public virtual MealType Type { get; set; }
    }
}
