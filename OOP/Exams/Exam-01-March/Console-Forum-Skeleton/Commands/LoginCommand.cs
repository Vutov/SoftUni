using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;

            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = this.Data[2];

            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.AlreadyLoggedIn));
            }
            else
            {
                var foundUser = false;
                foreach (var user in users)
                {
                    if (user.Username == username && 
                        user.Password == PasswordUtility.Hash(password))
                    {
                        this.Forum.CurrentUser = user;
                        this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
                        foundUser = true;
                    }
                }

                if (!foundUser)
                {
                    throw new CommandException(Messages.InvalidLoginDetails);
                }
            }

        }
    }
}
