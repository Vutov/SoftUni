namespace OnlineShop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<Ad> Ads { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<AdType> AdTypes { get; set; }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }
    }
}