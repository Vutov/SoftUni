namespace BugTracker.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> Create
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated
                };
            }
        } 
    }
}