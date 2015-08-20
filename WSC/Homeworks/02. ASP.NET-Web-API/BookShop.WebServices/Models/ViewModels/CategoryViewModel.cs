namespace BookShop.WebServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using BookShop.Models;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> Create
        {
            get
            {
                return c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
    }
}