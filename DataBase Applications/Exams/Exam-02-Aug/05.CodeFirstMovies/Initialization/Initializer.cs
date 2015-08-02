namespace _05.CodeFirstMovies.Initialization
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Models;

    public class Initializer : DropCreateDatabaseIfModelChanges<MoviesEntitie>
    {
        protected override void Seed(MoviesEntitie context)
        {
            var deserializer = new JavaScriptSerializer();
            var countriesJson = File.ReadAllText("../../../data/countries.json");
            var countries = deserializer.Deserialize<JsonCountry[]>(countriesJson);
            foreach (var country in countries)
            {
                var newCountry = new Country() { Name = country.Name };
                context.Countries.Add(newCountry);
            }

            context.SaveChanges();
            Console.WriteLine("{0} countries imported", context.Countries.Count());

            var usersJson = File.ReadAllText("../../../data/users.json");
            var users = deserializer.Deserialize<JsonUser[]>(usersJson);
            foreach (var user in users)
            {
                var country = user.Country;
                Country userCountry = null;
                if (country != null)
                {
                    userCountry = context.Countries.FirstOrDefault(c => c.Name == user.Country);    
                }
                
                var newUser = new User()
                {
                    Username = user.Username,
                    Age = user.Age,
                    Email = user.Email,
                    Country = userCountry
                };

                context.Users.Add(newUser);
            }

            context.SaveChanges();
            Console.WriteLine("{0} users imported", context.Users.Count());

            var moviesJson = File.ReadAllText("../../../data/movies.json");
            var movies = deserializer.Deserialize<JsonMovies[]>(moviesJson);
            foreach (var movie in movies)
            {
                var newMovie = new Movie()
                {
                    AgeRestriction = (AgeRestriction) Enum.ToObject(typeof (AgeRestriction), movie.AgeRestriction),
                    ISBN = movie.ISBN,
                    Title = movie.Title
                };

                context.Movies.Add(newMovie);
            }

            context.SaveChanges();
            Console.WriteLine("{0} movies imported", context.Movies.Count());

            var usersAndMoviesJson = File.ReadAllText("../../../data/users-and-favourite-movies.json");
            var usersAndMovies = deserializer.Deserialize<JsonUsersFavMovies[]>(usersAndMoviesJson);
            foreach (var couple in usersAndMovies)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == couple.username);
                foreach (var favouriteMovie in couple.FavouriteMovies)
                {
                    var favMovie = context.Movies.FirstOrDefault(m => m.ISBN == favouriteMovie);
                    user.FavoriteMovies.Add(favMovie);
                }
            }

            context.SaveChanges();
            Console.WriteLine("Favorite movies imported!");

            var movieRatinsJson = File.ReadAllText("../../../data/movie-ratings.json");
            var movieRatings = deserializer.Deserialize<JsonMovieRatings[]>(movieRatinsJson);
            foreach (var jsonMovieRating in movieRatings)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == jsonMovieRating.User);
                var movie = context.Movies.FirstOrDefault(m => m.ISBN == jsonMovieRating.Movie);
                var rating = new Rating()
                {
                    RatedMovie = movie,
                    User = user,
                    Stars = jsonMovieRating.Rating
                };

                context.Ratings.Add(rating);
            }

            context.SaveChanges();
            Console.WriteLine("{0} ratings imported!", context.Ratings.Count());

            base.Seed(context);
        }
    }
}