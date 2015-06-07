using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;

            if (!this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NotLogged));
                return;
            }

            string title = this.Data[1];
            string body = this.Data[2];
            var questions = this.Forum.Questions;
            Question currentQuestion = new Question(questions.Count + 1, title, body, this.Forum.CurrentUser);

            this.Forum.CurrentUser.Questions.Add(currentQuestion);
            questions.Add(currentQuestion);

            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, currentQuestion.Id));
        }
    }
}
