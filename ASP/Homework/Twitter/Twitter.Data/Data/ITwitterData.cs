namespace Twitter.Data.Data
{
    using Repositories;
    using Models;

    public interface ITwitterData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}