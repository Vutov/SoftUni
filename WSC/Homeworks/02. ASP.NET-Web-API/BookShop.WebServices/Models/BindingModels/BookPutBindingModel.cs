namespace BookShop.WebServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BookShop.Models;

    public class BookPutBindingModel: BookBindingModel
    {
        [Required(ErrorMessage = "Author Id is required!")]
        public int AuthorId { get; set; }
    }
}