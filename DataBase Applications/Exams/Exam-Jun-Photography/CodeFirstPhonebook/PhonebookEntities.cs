namespace CodeFirstPhonebook
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Initialization;
    using Models;

    public class PhonebookEntities : DbContext
    {
        public PhonebookEntities()
            : base("name=PhonebookEntities")
        {
            Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithOptional(p => p.Sender)
                .Map(m =>
                {
                    m.MapKey("SenderId");
                });
            modelBuilder.Entity<User>()
                .HasMany(u => u.RecievedMessages)
                .WithOptional(p => p.Recipiant)
                .Map(m =>
                {
                    m.MapKey("RecipiantId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
    }
}