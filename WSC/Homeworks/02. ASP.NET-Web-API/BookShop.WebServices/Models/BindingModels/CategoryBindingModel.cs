namespace BookShop.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryBindingModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}