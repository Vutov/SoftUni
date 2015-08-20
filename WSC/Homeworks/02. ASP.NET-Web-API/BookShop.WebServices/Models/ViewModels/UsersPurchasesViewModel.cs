namespace BookShop.WebServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using BookShop.Models;

    public class UsersPurchasesViewModel
    {
        public string Username { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }


        public static Expression<Func<Purchase, UsersPurchasesViewModel>> Create 
        {
            get
            {
                return p => new UsersPurchasesViewModel()
                {
                    Username = p.ApplicationUser.UserName,
                    BookTitle = p.Book.Title,
                    Price = p.Book.Price,
                    DateOfPurchase = p.DateOfPurchase,
                    IsRecalled = p.IsRecalled
                };
            }
        }
    }
}