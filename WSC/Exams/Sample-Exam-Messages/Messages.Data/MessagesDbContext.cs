namespace Messages.Data
{
    using System.Data.Entity;

    using Messages.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class MessagesDbContext : IdentityDbContext<User>
    {
        public MessagesDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static MessagesDbContext Create()
        {
            return new MessagesDbContext();
        }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<ChannelMessage> ChannelMessages { get; set; }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
