namespace Messages.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/channels")]
    public class ChannelsController : BaseController
    {
        [Route("")]
        public IHttpActionResult GetAllChannels()
        {
            var channels = this.Data.Channels.OrderBy(c => c.Name);
            var channelsView = channels.Select(ChannelViewModel.Create);
            return this.Ok(channelsView);
        }

        [Route("{id}")]
        public IHttpActionResult GetChannelById(int id)
        {
            var channel = this.Data.Channels.FirstOrDefault(c => c.Id == id);
            if (channel == null)
            {
                return this.NotFound();
            }

            var channelView = new ChannelViewModel()
            {
                Id = channel.Id,
                Name = channel.Name
            };

            return this.Ok(channelView);
        }

        [Route("")]
        public IHttpActionResult PostCreateNewChannel([FromBody] ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var dbModel = this.Data.Channels.FirstOrDefault(c => c.Name == model.Name);
            if (dbModel != null)
            {
                return this.Conflict();
            }

            var newChannel = new Channel()
            {
                Name = model.Name
            };
            this.Data.Channels.Add(newChannel);
            this.Data.SaveChanges();

            var viewModel = new ChannelViewModel()
            {
                Id = newChannel.Id,
                Name = newChannel.Name
            };

            return this.Created("http://localhost:7777/api/channels/" + viewModel.Id, viewModel);
        }

        [Route("{id}")]
        public IHttpActionResult PutEditExistingChannel([FromUri]int id, [FromBody] ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var channelToEdit = this.Data.Channels.FirstOrDefault(c => c.Id == id);
            if (channelToEdit == null)
            {
                return this.NotFound();
            }

            var dbModel = this.Data.Channels.FirstOrDefault(c => c.Name == model.Name);
            if (dbModel != null)
            {
                return this.Conflict();
            }

            channelToEdit.Name = model.Name;
            this.Data.SaveChanges();

            var viewModel = new MessageViewModel()
            {
                Message = "Channel #" + id + " edited successfully."
            };
            return this.Ok(viewModel);
        }

        [Route("{id}")]
        public IHttpActionResult DeleteChannelById(int id)
        {
            var dbModel = this.Data.Channels.FirstOrDefault(c => c.Id == id);
            if (dbModel == null)
            {
                return this.NotFound();
            }

            if (dbModel.ChannelMessages.Any())
            {
                return this.Conflict();
            }

            this.Data.Channels.Remove(dbModel);
            this.Data.SaveChanges();

            var viewModel = new MessageViewModel()
            {
                Message = "Channel #" + id + " deleted."
            };
            return this.Ok(viewModel);
        }
    }
}
