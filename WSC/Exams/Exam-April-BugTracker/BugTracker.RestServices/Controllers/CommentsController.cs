namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.DataLayer;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    public class CommentsController : BaseController
    {
        public CommentsController()
            : base()
        {
        }

        public CommentsController(IBugTrackerData data)
            : base(data)
        {
        }

        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult PostNewCommentOnBug([FromUri] int id, [FromBody] CreateaCommentBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = this.Data.Bugs.GetById(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comment = new Comment()
            {
                Text = model.Text,
                DateCreated = DateTime.Now,
                Author = null
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.Data.Users.GetById(userId);
                comment.Author = user;
            }

            bug.Comments.Add(comment);
            this.Data.SaveChanges();
            if (comment.Author == null)
            {
                var viewModel = new CreateWithoutAuthorViewModel()
                {
                    Id = comment.Id,
                    Message = "Added anonymous comment for bug #" + bug.Id
                };

                return this.Ok(viewModel);
            }
            else
            {
                var viewModel = new CreateWithAuthorViewModel()
                {
                    Id = comment.Id,
                    Author = comment.Author.UserName,
                    Message = "User comment added for bug #" + bug.Id
                };

                return this.Ok(viewModel);
            }
        }

        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult GetCommentsForBug(int id)
        {
            var bug = this.Data.Bugs.GetById(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments
                .AsQueryable()
                .Select(CommentViewModel.Create)
                .OrderByDescending(c => c.DateCreated);

            return this.Ok(comments);
        }

        [Route("api/comments")]
        public IHttpActionResult GetAllComment()
        {
            var comments = this.Data.Comments
                .All()
                .Select(ExtendedCommentView.Create)
                .OrderByDescending(c => c.DateCreated);

            return this.Ok(comments);
        }
    }
}
