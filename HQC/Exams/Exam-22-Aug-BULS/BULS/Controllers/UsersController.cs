namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : BaseController
    {
        public UsersController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        /// <summary>
        /// Registers user by given Username, Password, Confirmation of password and role.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Users's password.</param>
        /// <param name="confirmPassword">Confirmation of the password.</param>
        /// <param name="role">User's role.</param>
        /// <returns>View containing users data.</returns>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Message.PassWordDontMatch);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users().GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(Message.UserAlreadyExist, username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users().Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var user = this.Data.Users().GetByUsername(username);
            if (user == null)
            {
                throw new ArgumentException(string.Format(Message.UserDontExist, username));
            }

            if (user.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(Message.WrongPassword);
            }

            this.User = user;
            return this.View(user);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser())
            {
                throw new ArgumentException(Message.NoOneLogged);
            }

            var user = this.User;
            this.User = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser())
            {
                throw new ArgumentException(Message.AllreadyLoged);
            }
        }
    }
}