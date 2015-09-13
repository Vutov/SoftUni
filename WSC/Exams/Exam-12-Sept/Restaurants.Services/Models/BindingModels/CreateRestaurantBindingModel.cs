namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRestaurantBindingModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "The {0} must be at least 1 character long.")]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Required]
        public int TownId { get; set; }
    }
}