namespace _05.CodeFirstMovies
{
    using System.Data.Entity;
    using Initialization;
    using Models;

    public class MoviesEntitie : DbContext
    {
        public MoviesEntitie()
            : base("name=MoviesEntitie")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}