namespace News.Data.DataLayer
{
    using Models;
    using Repositories;

    public  interface INewsData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<News> News { get; }

        int SaveChanges();
    }
}
