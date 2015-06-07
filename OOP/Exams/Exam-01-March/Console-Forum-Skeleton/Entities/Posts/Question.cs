using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Question : IQuestion
    {
        public Question(int id, string title, string body, IUser author)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.Author = author;
            this.Answers = new List<IAnswer>();
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; set; }
    }
}
