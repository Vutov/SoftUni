namespace OnlineShop.Services.Models.View
{
    using System;
    using System.Linq.Expressions;
    using OnlineShop.Models;

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