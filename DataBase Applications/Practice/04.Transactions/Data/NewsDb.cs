namespace Data
{
    using System.Data.Entity;
    using Models;

    public class NewsDb : DbContext
    {
        public NewsDb()
        {
            Database.SetInitializer(new DBInitializer());
        }

        public IDbSet<News> News { get; set; }
    }
}
