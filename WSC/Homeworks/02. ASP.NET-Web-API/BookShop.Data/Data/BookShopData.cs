namespace BookShop.Data.Data
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class BookShopData : IBookShopData
    {
        private readonly IDictionary<Type, object> repositories;

        public BookShopData(BookShopContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public BookShopContext Context { get; private set; }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Author> Authors
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Purchase> Purchase
        {
            get { return this.GetRepository<Purchase>(); }
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
