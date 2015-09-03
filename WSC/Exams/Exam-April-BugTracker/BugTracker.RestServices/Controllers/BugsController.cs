namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data.DataLayer;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/bugs")]
    public class BugsController : BaseController
    {
        public BugsController()
            : base()
        {
        }

        public BugsController(IBugTrackerData data)
            : base(data)
        {
        }

        [Route("{id}")]
        public IHttpActionResult GetBugById(int id)
        {
            var bug = this.Data.Bugs.GetById(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var bugViewModel = new BugViewModel()
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Status = bug.Status.ToString(),
                Author = bug.Author == null ? null : bug.Author.UserName,
                DateCreated = bug.DateCreated,
                Comments = bug.Comments
                    .Select(c => new CommentViewModel()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        Author = c.Author == null ? null : c.Author.UserName,
                        DateCreated = c.DateCreated
                    })
                    .OrderByDescending(c => c.DateCreated)
            };

            return this.Ok(bugViewModel);
        }

        [Route("")]
        public IHttpActionResult PostNewBug([FromBody] CreateBugBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = new Bug()
            {
                Title = model.Title,
                Description = model.Description,
                DateCreated = DateTime.Now,
                Status = Status.Open,
                Comments = new List<Comment>(),
                Author = null
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var loggedUserId = this.User.Identity.GetUserId();
                var user = this.Data.Users.GetById(loggedUserId);
                bug.Author = user;
            }

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (bug.Author == null)
            {
                var viewModel = new CreateWithoutAuthorViewModel()
                {
                    Id = bug.Id,
                    Message = "Anonymous bug submitted."
                };

                return this.Created("http://localhost:5555/api/bugs/" + viewModel.Id, viewModel);
            }
            else
            {
                var viewModel = new CreateWithAuthorViewModel()
                {
                    Id = bug.Id,
                    Author = bug.Author.UserName,
                    Message = "User bug submitted."
                };

                return this.Created("http://localhost:5555/api/bugs/" + viewModel.Id, viewModel);
            }
        }

        [Route("{id}")]
        public IHttpActionResult PatchExistingBug(int id, EditBugBindingModel model)
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

            var hasChanged = false;
            if (!string.IsNullOrEmpty(model.Title))
            {
                bug.Title = model.Title;
                hasChanged = true;
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                bug.Description = model.Description;
                hasChanged = true;
            }

            if (!string.IsNullOrEmpty(model.Status))
            {
                try
                {
                    bug.Status = (Status)Enum.Parse(typeof(Status), model.Status, true);
                }
                catch (ArgumentException ex)
                {
                    return this.BadRequest("Invalid status");
                }

                hasChanged = true;
            }

            if (!hasChanged)
            {
                return this.BadRequest();
            }

            this.Data.SaveChanges();
            var viewModel = new MessageViewModel()
            {
                Message = "Bug #" + bug.Id + " patched."
            };

            return this.Ok(viewModel);
        }
    }
}
