namespace Data
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<NewsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}