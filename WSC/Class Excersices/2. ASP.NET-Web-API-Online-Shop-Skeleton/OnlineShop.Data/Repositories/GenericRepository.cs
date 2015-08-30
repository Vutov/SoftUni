using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        protected DbContext Context;
        protected DbSet<T> Set;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.Set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.Set.AsQueryable();
        }

        public T Find(object id)
        {
            return this.Set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = state;
        }
    }
}