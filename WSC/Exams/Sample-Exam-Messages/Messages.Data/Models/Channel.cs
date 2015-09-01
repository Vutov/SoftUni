namespace Messages.Data.Models
{
    using System.Collections.Generic;

    public class Channel
    {
        private ICollection<ChannelMessage> channelMessages;

        public Channel()
        {
            this.channelMessages = new HashSet<ChannelMessage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get { return this.channelMessages; }
            set { this.channelMessages = value; }
        }
    }
}
