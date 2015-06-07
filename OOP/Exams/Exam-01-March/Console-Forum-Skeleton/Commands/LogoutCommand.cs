using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class LogoutCommand: AbstractCommand
    {
        public LogoutCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;

            if (this.Forum.IsLogged)
            {
                this.Forum.CurrentUser = null;
                this.Forum.Output.AppendLine(string.Format(Messages.LogoutSuccess));
            }
            else
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NotLogged));
            }
        }
    }
}
