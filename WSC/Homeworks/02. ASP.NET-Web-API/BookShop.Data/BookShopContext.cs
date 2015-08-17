namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new DbInizializer());
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}