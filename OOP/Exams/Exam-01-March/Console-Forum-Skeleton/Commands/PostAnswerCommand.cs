using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NotLogged));
                return;
            }

            if (this.Forum.CurrentQuestion == null)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NoQuestionOpened));
            }

            var body = this.Data[1];
            var answers = this.Forum.Answers;

            Answer answer = new Answer(answers.Count + 1, body, this.Forum.CurrentUser);
            answers.Add(answer);
            this.Forum.CurrentQuestion.Answers.Add(answer);

            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answer.Id));
        }
    }
}
