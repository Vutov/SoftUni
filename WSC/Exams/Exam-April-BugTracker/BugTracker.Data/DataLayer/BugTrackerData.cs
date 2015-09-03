namespace BugTracker.Data.DataLayer
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class BugTrackerData : IBugTrackerData
    {
        private readonly IDictionary<Type, object> repositories;

        public BugTrackerData(BugTrackerDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public BugTrackerDbContext Context { get; private set; }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Bug> Bugs
        {
            get { return this.GetRepository<Bug>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var modelType = typeof(T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof(Repository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType, this.Context));
            }

            return (IRepository<T>)this.repositories[modelType];
        }
    }
}