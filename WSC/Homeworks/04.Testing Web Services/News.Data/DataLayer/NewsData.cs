namespace News.Data.DataLayer
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class NewsData : INewsData
    {
        private readonly IDictionary<Type, object> repositories;

        public NewsData(NewsContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public NewsContext Context { get; private set; }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<News> News
        {
            get { return this.GetRepository<News>(); }
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