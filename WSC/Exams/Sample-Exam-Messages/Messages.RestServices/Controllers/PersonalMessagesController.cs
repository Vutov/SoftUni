namespace Messages.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/user/personal-messages")]
    public class PersonalMessagesController : BaseController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult GetPersonalMessages()
        {
            var userId = this.User.Identity.GetUserId();
            var messages = this.Data.UserMessages
                .Where(u => u.Recipient.Id == userId)
                .OrderByDescending(m => m.DateSent)
                .Select(ChannelMessegeViewModel.CreateUserMessages);
            return this.Ok(messages);
        }

        [Route("")]
        public IHttpActionResult PostPersonalMessage([FromBody] PersonalMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var recipient = this.Data.Users.FirstOrDefault(u => u.UserName == model.Recipient);
            if (recipient == null)
            {
                return this.BadRequest();
            }

            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var sender = this.Data.Users.First(u => u.Id == userId);
                var message = new UserMessage()
                {
                    Sender = sender,
                    Recipient = recipient,
                    Text = model.Text,
                    DateSent = DateTime.Now
                };
                this.Data.UserMessages.Add(message);
                this.Data.SaveChanges();

                var viewModel = new ChannelMessageCreateWithUserViewModel()
                {
                    Id = message.Id,
                    Sender = sender.UserName,
                    Message = "Message sent successfully to user " + recipient.UserName + "."
                };
                return this.Ok(viewModel);
            }
            else
            {
                var message = new UserMessage()
                {
                    Sender = null,
                    Recipient = recipient,
                    Text = model.Text,
                    DateSent = DateTime.Now
                };
                this.Data.UserMessages.Add(message);
                this.Data.SaveChanges();

                var viewModel = new ChannelMessageCreateViewModel()
                {
                    Id = message.Id,
                    Message = "Anonymous message sent successfully to user " + recipient.UserName + "."
                };
                return this.Ok(viewModel);
            }
        }
    }
}
