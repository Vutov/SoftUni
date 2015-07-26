namespace Data
{
    using System.Data.Entity;
    using Models;

    public class DBInitializer : CreateDatabaseIfNotExists<NewsDb>
    {
        protected override void Seed(NewsDb context)
        {
            context.News.Add(new News() { Content = "First content" });
            context.News.Add(new News() { Content = "Second content" });
            context.News.Add(new News() { Content = "third content" });

            base.Seed(context);
        }
    }
}