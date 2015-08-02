namespace _05.CodeFirstMovies.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Country
    {
        private ICollection<User> users;

        public Country()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
