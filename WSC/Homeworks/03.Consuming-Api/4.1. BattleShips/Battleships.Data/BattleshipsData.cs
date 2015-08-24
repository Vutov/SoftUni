namespace Battleships.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Battleships.Data.Repositories;
    using Battleships.Models;

    public class BattleshipsData : IBattleshipsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories; 

        public BattleshipsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public GamesRepository Games
        {
            get { return (GamesRepository)this.GetRepository<Game>(); }
        }

        public IRepository<Ship> Ships
        {
            get { return this.GetRepository<Ship>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                if (type.IsAssignableFrom(typeof(Game)))
                {
                    typeOfRepository = typeof(GamesRepository);
                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
