namespace Twitter.App.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net;
    using System.Web;
    using System.Web.Http.Results;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models;
    using Twitter.Models;

    public class UserController : BaseController
    {
        [Authorize]
        public ActionResult UserProfile()
        {
            var user = this.Data.ApplicationUsers.GetById(this.User.Identity.GetUserId());
            var viewModel = new UserViewModel()
            {
                UserName = user.UserName
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(TweetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Data");
            }

            var tweet = new Tweet
            {
                Message = model.Message,
                TimeStamp = DateTime.Now,
                User = this.Data.ApplicationUsers.GetById(this.User.Identity.GetUserId())
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}