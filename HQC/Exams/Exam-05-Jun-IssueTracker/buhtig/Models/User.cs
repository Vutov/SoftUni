namespace IssueTracker.Models
{
    using Core;

    public class User
    {
        private string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; private set; }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                this.password = PasswordHasher.HashPassword(value);
            }
        }
    }
}