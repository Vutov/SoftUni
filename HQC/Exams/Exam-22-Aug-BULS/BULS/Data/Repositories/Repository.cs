namespace BangaloreUniversityLearningSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> items;

        protected Repository()
        {
            this.items = new List<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            this.items.Add(item);
        }
    }
}