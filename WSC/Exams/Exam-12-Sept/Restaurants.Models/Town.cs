namespace Restaurants.Models
{
    using System.Collections.Generic;

    public class Town
    {
        private ICollection<Restaurant> restaurants;

        public Town()
        {
            this.restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants
        {
            get { return this.restaurants; }
            set { this.restaurants = value; }
        }
    }
}
