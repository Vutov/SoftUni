namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RatingBindingModel
    {
        [Range(1, 10, ErrorMessage = "The {0} must be between 1 and 10.")]
        [Display(Name = "Rating Stars")]
        public int Stars { get; set; }
    }
}