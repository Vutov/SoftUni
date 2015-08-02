namespace _05.CodeFirstMovies
{
    using System.Linq;

    class MoviesMain
    {
        static void Main(string[] args)
        {
            var context = new MoviesEntitie();

            // Just so the db will be initialized
            context.Countries.Count();
        }
    }
}
