namespace BookShop.Data.Data
{
    using Models;
    using Repositories;

    public interface IBookShopData
    {
        IRepository<Book> Books { get; }

        IRepository<Author> Authors { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<Purchase> Purchase { get; } 

        int SaveChanges();
    }
}
