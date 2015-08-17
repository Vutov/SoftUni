namespace BookShop.WebServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BookShop.Models;

    public abstract class BookBindingModel
    {
        [MinLength(1, ErrorMessage = "Title must be at least 1 symbol long")]
        [MaxLength(50, ErrorMessage = "Title must not be longer than 50 symbols")]
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Decription must not be longer than 1000 symbols")]
        public string Decription { get; set; }

        public EditionType EditionType { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Age Restriction is required!")]
        public AgeRestriction AgeRestriction { get; set; }
    }
}