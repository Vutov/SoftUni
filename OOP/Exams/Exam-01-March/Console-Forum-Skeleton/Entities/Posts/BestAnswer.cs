using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    class BestAnswer: Answer
    {
        public BestAnswer(int id, string body, IUser author) : base(id, body, author)
        {
        }
    }
}
