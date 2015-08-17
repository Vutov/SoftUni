namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.Data.BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShop.Data.BookShopContext";
        }
    }
}
