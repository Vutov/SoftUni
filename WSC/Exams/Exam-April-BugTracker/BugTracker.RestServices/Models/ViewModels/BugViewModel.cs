namespace BugTracker.RestServices.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Models;

    public class BugViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Bug, BugViewModel>> Create
        {
            get
            {
                return b => new BugViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.DateCreated,
                    Comments = b.Comments
                        .Select(c => new CommentViewModel()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Author = c.Author == null ? null : c.Author.UserName,
                            DateCreated = c.DateCreated
                        })
                        .OrderByDescending(c => c.DateCreated)
                };
            }
        }
    }
}