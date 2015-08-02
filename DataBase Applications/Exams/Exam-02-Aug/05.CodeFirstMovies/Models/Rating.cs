namespace _05.CodeFirstMovies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int Stars { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RatedMovieId { get; set; }

        public Movie RatedMovie { get; set; }
    }
}
