namespace _06.QueryDatabae
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _05.CodeFirstMovies;
    using _05.CodeFirstMovies.Models;

    public class Queries
    {
        public static void Main(string[] args)
        {
            var context = new MoviesEntitie();
            var serializer = new JavaScriptSerializer();
            var adultMoviePath = new DirectoryInfo("../../../adult-movies.json");
            var user = "jmeyery";
            var path = string.Format("../../../rated-movies-by-{0}.json", user);
            var ratedMoviePath = new DirectoryInfo(path);
            var topMoviesPath = new DirectoryInfo("../../../top-10-favourite-movies.json");

            //1. Adult Movies
            AdultMoveis(context, serializer, adultMoviePath);

            //2. Rated Movies by User
            RatedMovieByUser(context, serializer, user, ratedMoviePath);

            //3. Top 10 Favourite Movies
            TopMovies(context, serializer, topMoviesPath);
        }

        private static void AdultMoveis(MoviesEntitie context, JavaScriptSerializer serializer, DirectoryInfo adultMoviePath)
        {
            var adultMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count
                })
                .OrderBy(m => m.title)
                .ThenBy(m => m.ratingsGiven)
                .ToList();

            var adultMovieJson = serializer.Serialize(adultMovies);
            File.WriteAllText(adultMoviePath.FullName, adultMovieJson);
            Console.WriteLine("Query 1 saved: " + adultMoviePath.FullName);
        }

        private static void RatedMovieByUser(MoviesEntitie context, JavaScriptSerializer serializer, string user, DirectoryInfo ratedMoviePath)
        {
            var ratedMovie = context.Users
                .Where(u => u.Username == user)
                .Select(u => new
                {
                    username = u.Username,
                    ratedMovies = u.RatedMovies.Select(m => new
                    {
                        title = m.RatedMovie.Title,
                        userRating = m.RatedMovie.Ratings
                            .Where(r => r.User == u)
                            .Select(r => r.Stars)
                            .Sum(),
                        averageRating = m.RatedMovie.Ratings
                            .Average(r => r.Stars)
                    })
                        .OrderBy(m => m.title)
                })
                .First();

            var usersMovies = serializer.Serialize(ratedMovie);
            File.WriteAllText(ratedMoviePath.FullName, usersMovies);
            Console.WriteLine("Query 2 saved: " + ratedMoviePath.FullName);
        }

        private static void TopMovies(MoviesEntitie context, JavaScriptSerializer serializer, DirectoryInfo topMoviesPath)
        {
            var favouriteMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .Select(m => new
                {
                    isbn = m.ISBN,
                    title = m.Title,
                    favouritedBy = m.FavoritedMovieUsers
                        .Select(u => u.Username)
                })
                .OrderByDescending(m => m.favouritedBy.Count())
                .ThenBy(m => m.title)
                .Take(10)
                .ToList();

            var topMovies = serializer.Serialize(favouriteMovies);
            File.WriteAllText(topMoviesPath.FullName, topMovies);
            Console.WriteLine("Query 3 saved: " + topMoviesPath.FullName);
        }
    }
}