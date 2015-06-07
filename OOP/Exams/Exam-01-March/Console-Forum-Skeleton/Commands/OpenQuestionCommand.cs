using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var id = int.Parse(this.Data[1]);
            var questions = this.Forum.Questions;
            var foundQuestion = false;
            foreach (var question in questions)
            {
                if (question.Id == id)
                {

                    var questionString = "Question";
                    GetoutQuestion(questionString, question);

                    var answers = question.Answers.OrderBy(a => a.Id).ToList();
                    if (answers.Count == 0)
                    {
                        this.Forum.Output.AppendLine(string.Format(Messages.NoAnswers));
                    }
                    else
                    {
                        this.Forum.Output.AppendLine(string.Format(Messages.Answers));

                        IAnswer firstanAnswer = null;
                        var foundBestAnswer = false;

                        foreach (var answer in answers)
                        {
                            if (answer is BestAnswer)
                            {
                                firstanAnswer = answer;
                                foundBestAnswer = true;
                            }
                        }

                        var answerString = "Answer";

                        if (foundBestAnswer)
                        {
                            this.Forum.Output.AppendLine(string.Format(Messages.StarsSeparator));
                            GetoutAnswer(answerString, firstanAnswer);
                            this.Forum.Output.AppendLine(string.Format(Messages.StarsSeparator));
                        }

                        foreach (var answer in answers)
                        {
                            if (answer != firstanAnswer)
                            {
                                GetoutAnswer(answerString, answer);
                            }
                        }
                    }

                    this.Forum.CurrentQuestion = question;
                    foundQuestion = true;
                }
            }

            if (!foundQuestion)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NoQuestion));

            }
        }

        private void GetoutAnswer(string answerString, IAnswer firstanAnswer)
        {
            this.Forum.Output.AppendLine(string.Format(Messages.Header, answerString, firstanAnswer.Id));
            this.Forum.Output.AppendLine(string.Format(Messages.Author, firstanAnswer.Author.Username));
            this.Forum.Output.AppendLine(string.Format(Messages.Body, answerString, firstanAnswer.Body));
            this.Forum.Output.AppendLine(string.Format(Messages.DashesSeparator));
        }

        public void GetoutQuestion(string questionString, IQuestion question)
        {
            this.Forum.Output.AppendLine(string.Format(Messages.Header, questionString, question.Id));
            this.Forum.Output.AppendLine(string.Format(Messages.Author, question.Author.Username));
            this.Forum.Output.AppendLine(string.Format(Messages.Title, questionString, question.Title));
            this.Forum.Output.AppendLine(string.Format(Messages.Body, questionString, question.Body));
            this.Forum.Output.AppendLine(string.Format(Messages.EquelsSeparator));
        }
    }
}
