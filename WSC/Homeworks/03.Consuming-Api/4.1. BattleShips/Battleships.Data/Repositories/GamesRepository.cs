namespace Battleships.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using Battleships.Data.Repositories;
    using Battleships.Models;
    
    public class GamesRepository : GenericRepository<Game>
    {
        public GamesRepository(DbContext context) 
            : base(context)
        {
        }

        public IQueryable<Game> GetGamesByState(GameState state)
        {
            return this.Set.Where(x => x.State == state);
        }
    }
}
