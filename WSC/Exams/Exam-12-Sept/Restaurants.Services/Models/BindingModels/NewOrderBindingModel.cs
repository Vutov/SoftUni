namespace Restaurants.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class NewOrderBindingModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} must be more than 0.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}