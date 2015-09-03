namespace BugTracker.Data.DataLayer
{
    using Models;
    using Repositories;

    public interface IBugTrackerData
    {
        IRepository<User> Users { get; }

        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
