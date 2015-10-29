namespace Restaurants.Models
{
    using System.Collections.Generic;

    public class Restaurant
    {
        private ICollection<Meal> meals;
        private ICollection<Rating> ratings;

        public Restaurant()
        {
            this.meals = new HashSet<Meal>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Meal> Meals
        {
            get { return this.meals; }
            set { this.meals = value; }
        }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
