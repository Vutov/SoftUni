using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class MealBindingModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "The {0} must be at least 1 character long.")]
        [Display(Name = "Meal Name")]
        public string Name { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The {0} must be more than 0!")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}