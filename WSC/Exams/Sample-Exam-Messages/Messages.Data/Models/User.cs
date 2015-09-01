namespace Messages.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<ChannelMessage> channelMessages;
        private ICollection<UserMessage> userMessages;

        public User()
        {
            this.channelMessages = new HashSet<ChannelMessage>();
            this.userMessages = new HashSet<UserMessage>();
        }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get { return this.channelMessages; }
            set { this.channelMessages = value; }
        }

        public virtual ICollection<UserMessage> UserMessages
        {
            get { return this.userMessages; }
            set { this.userMessages = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
