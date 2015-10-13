namespace Twitter.Data.Data
{
    using System;
    using System.Collections.Generic;
    using Twitter.Data;
    using Repositories;
    using Models;

    public class TwitterData : ITwitterData
    {
        private readonly IDictionary<Type, object> repositories;

        public TwitterData(ApplicationDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationDbContext Context { get; private set; }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
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