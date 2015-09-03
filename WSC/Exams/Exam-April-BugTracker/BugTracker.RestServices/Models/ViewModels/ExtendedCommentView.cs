namespace BugTracker.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;

    public class ExtendedCommentView
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public string BugTitle { get; set; }

        public static Expression<Func<Comment, ExtendedCommentView>> Create
        {
            get
            {
                return c => new ExtendedCommentView()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated,
                    BugId = c.BugId,
                    BugTitle = c.Bug.Title
                };
            }
        } 
    }
}