namespace BookShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Book")]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Is-racalled")]
        public bool IsRecalled { get; set; }
    }
}
