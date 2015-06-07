using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Commands;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum
{
    class ExtendedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            this.Output.Clear();
            HeaderInfo();
            Console.Write(this.Output);
            this.Output.Clear();
            var inputCommand = Console.ReadLine();

            try
            {
                IExecutable command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine(Messages.InvalidCommand);
            }

            Console.Write(this.Output);
        }

        private void HeaderInfo()
        {
            this.Output.AppendLine(Messages.WavesSeparator);
            if (this.IsLogged)
            {
                this.Output.AppendLine(string.Format(Messages.UserWelcomeMessage,
                    this.CurrentUser.Username));
            }
            else
            {
                this.Output.AppendLine(string.Format(Messages.GuestWelcomeMessage));
            }

            var allQuestions = this.Questions;
            var hotQuestions = allQuestions.Sum(question => question.Answers.OfType<BestAnswer>().Count());

            var allAnswers = this.Answers;
            var userAnswers = new Dictionary<string, int>();
            foreach (var answer in allAnswers)
            {
                var author = answer.Author.Username;
                if (!userAnswers.ContainsKey(author))
                {
                    userAnswers.Add(author, 0);
                }

                userAnswers[author]++;
            }

            var activeUsers = userAnswers.Count(user => user.Value >= 3);

            this.Output.AppendLine(string.Format(Messages.GeneralHeaderMessage,
                    hotQuestions, activeUsers));
            this.Output.AppendLine(Messages.WavesSeparator);
        }
    }
}
