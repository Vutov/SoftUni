namespace Messages.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/channel-messages")]
    public class ChannelMessagesController : BaseController
    {
        [Route("{channelName}")]
        public IHttpActionResult GetChannelMessagesByChannel(string channelName)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                return this.BadRequest();
            }

            var channel = this.Data.Channels.FirstOrDefault(c => c.Name == channelName);
            if (channel == null)
            {
                return this.NotFound();
            }

            var messeges = channel.ChannelMessages
                .OrderByDescending(c => c.DateSent)
                .AsQueryable();

            var viewModel = messeges.Select(ChannelMessegeViewModel.CreateChannelMessages);
            return this.Ok(viewModel);
        }

        [Route("{channel}")]
        public IHttpActionResult GetChannelMessagesWIthLimit(string channel, int limit)
        {
            if (string.IsNullOrEmpty(channel))
            {
                return this.BadRequest();
            }

            if (limit < 1 || limit > 1000)
            {
                return this.BadRequest();
            }

            var dbChannel = this.Data.Channels.FirstOrDefault(c => c.Name == channel);
            if (dbChannel == null)
            {
                return this.NotFound();
            }

            var messeges = dbChannel.ChannelMessages
                .OrderByDescending(c => c.DateSent)
                .Take(limit)
                .AsQueryable();

            var viewModel = messeges.Select(ChannelMessegeViewModel.CreateChannelMessages);
            return this.Ok(viewModel);
        }

        [HttpPost]
        [Route("{channelName}")]
        public IHttpActionResult PostAnonymoustMessage([FromUri]string channelName, [FromBody] ChannelMessageBindingModel model)
        {
            if (string.IsNullOrEmpty(channelName) || model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var dbChannel = this.Data.Channels.FirstOrDefault(c => c.Name == channelName);
            if (dbChannel == null)
            {
                return this.NotFound();
            }

            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var dbUser = this.Data.Users.First(u => u.Id == userId);
                var message = new ChannelMessage()
                {
                    DateSent = DateTime.Now,
                    Sender = dbUser,
                    Text = model.Text
                };
                dbChannel.ChannelMessages.Add(message);
                this.Data.SaveChanges();

                var viewModel = new ChannelMessageCreateWithUserViewModel()
                {
                    Id = message.Id,
                    Sender = message.Sender.UserName,
                    Message = "Message sent to channel " + dbChannel.Name + "."
                };
                return this.Ok(viewModel);
            }
            else
            {
                var message = new ChannelMessage()
                {
                    DateSent = DateTime.Now,
                    Sender = null,
                    Text = model.Text
                };
                dbChannel.ChannelMessages.Add(message);
                this.Data.SaveChanges();

                var viewModel = new ChannelMessageCreateViewModel()
                {
                    Id = message.Id,
                    Message = "Anonymous message sent to channel " + dbChannel.Name + "."
                };
                return this.Ok(viewModel);
            }
        }
    }
}
