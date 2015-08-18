namespace BookShop.WebServices.Models.ViewModels
{
    using System;

    public class UsersPurchasesViewModel
    {
        public string Username { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }
    }
}