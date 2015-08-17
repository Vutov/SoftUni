namespace BookShop.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookSearchBindingModel
    {
        [Required]
        public string Search { get; set; }
    }
}