namespace BookShop.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorBindingMethod
    {
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}