namespace News.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class NewsContext : IdentityDbContext<ApplicationUser>
    {
        public NewsContext()
            : base("name=NewsContext")
        {
        }

        public virtual DbSet<News> News { get; set; }

        public static NewsContext Create()
        {
            return new NewsContext();
        }
    }
}