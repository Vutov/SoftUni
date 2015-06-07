using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum.Commands
{
    class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
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
                return;
            }

            var id = int.Parse(this.Data[1]);
            var answers = this.Forum.CurrentQuestion.Answers;
            var found = false;
            IAnswer foundAnswer = null;

            foreach (var answer in answers)
            {
                if (answer.Id == id)
                {
                    foundAnswer = answer;
                    found = true;
                }
            }

            if (!found)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NoAnswer));
                return;
            }

            var questions = this.Forum.Questions;
            IUser questionAuthor = null;
            foreach (var question in questions)
            {
                foreach (var answer in question.Answers)
                {
                    if (answer.Id == id)
                    {
                        questionAuthor = question.Author;
                    }
                }
            }

            if (questionAuthor == this.Forum.CurrentUser ||
                this.Forum.CurrentUser is Administrator)
            {
                answers.Remove(foundAnswer);
                var bestAnswer = new BestAnswer(id, foundAnswer.Body, foundAnswer.Author);
                answers.Add(bestAnswer);

                this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, id));
            }
            else
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NoPermission));
            }
        }
    }
}
