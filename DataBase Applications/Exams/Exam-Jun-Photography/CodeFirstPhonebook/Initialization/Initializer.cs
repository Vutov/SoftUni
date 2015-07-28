namespace CodeFirstPhonebook.Initialization
{
    using System;
    using System.Data.Entity;
    using Models;

    public class Initializer: DropCreateDatabaseIfModelChanges<PhonebookEntities>
    {
        protected override void Seed(PhonebookEntities context)
        {
            var user1 = new User() { Username = "VGeorgiev", FullName = "Vladimir Georgiev", PhoneNumber = "0894545454" };
            var user2 = new User() { Username = "Nakov", FullName = "Svetlin Nakov", PhoneNumber = "0897878787" };
            var user3 = new User() { Username = "Ache", FullName = "Angel Georgiev", PhoneNumber = "0897121212" };
            var user4 = new User() { Username = "Alex", FullName = "Alexandra Svilarova", PhoneNumber = "0894151417" };
            var user5 = new User() { Username = "Petya", FullName = "Petya Grozdarska", PhoneNumber = "0895464646" };
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);

            var channel1 = new Channel() { Name = "Malinki" };
            var channel2 = new Channel() { Name = "SoftUni" };
            var channel3 = new Channel() { Name = "Admins" };
            var channel4 = new Channel() { Name = "Programmers" };
            var channel5 = new Channel() { Name = "Geeks" };
            context.Channels.Add(channel1);
            context.Channels.Add(channel2);
            context.Channels.Add(channel3);
            context.Channels.Add(channel4);
            context.Channels.Add(channel5);

            var channelMessage1 = new ChannelMessage()
            {
                Channel = channel1,
                DateTime = DateTime.Now,
                User = user5,
                Content = "Hey dudes, are you ready for tonight?"
            };
            var channelMessage2 = new ChannelMessage()
            {
                Channel = channel1,
                DateTime = DateTime.Now,
                User = user1,
                Content = "Hey Petya, this is the SoftUni chat."
            };
            var channelMessage3 = new ChannelMessage()
            {
                Channel = channel1,
                DateTime = DateTime.Now,
                User = user2,
                Content = "Hahaha, we are ready!"
            };
            var channelMessage4 = new ChannelMessage()
            {
                Channel = channel1,
                DateTime = DateTime.Now,
                User = user5,
                Content = "Oh my god. I mean for drinking beers!"
            };
            var channelMessage5 = new ChannelMessage()
            {
                Channel = channel1,
                DateTime = DateTime.Now,
                User = user1,
                Content = "We are sure!"
            };

            context.ChannelMessages.Add(channelMessage1);
            context.ChannelMessages.Add(channelMessage2);
            context.ChannelMessages.Add(channelMessage3);
            context.ChannelMessages.Add(channelMessage4);
            context.ChannelMessages.Add(channelMessage5);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
