namespace BangaloreUniversityLearningSystem.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private readonly Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                var user = this.GetAll().FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    return null;
                }

                this.usersByUsername[username] = user;
            }

            return this.usersByUsername[username];
        }
    }
}
