namespace _05.CodeFirstMovies.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private ICollection<User> favoritedMovieUsers;
        private ICollection<Rating> ratings;

        public Movie()
        {
            this.favoritedMovieUsers = new HashSet<User>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> FavoritedMovieUsers
        {
            get { return this.favoritedMovieUsers; }
            set { this.favoritedMovieUsers = value; }
        }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
