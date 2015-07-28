namespace CodeFirstPhonebook
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    class Client
    {
        static void Main(string[] args)
        {
            var context = new PhonebookEntities();
            var chanannels = context.Channels
                .Select(c => new
                {
                    c.Name,
                    ChannelMessages = c.ChannelMessages.Select(m => new
                    {
                        m.Content,
                        m.DateTime,
                        m.User.Username
                    })
                })
                .ToList();

            chanannels.ForEach(m =>
            {
                Console.WriteLine("{0}\n--Messages--", m.Name);
                var messages = m.ChannelMessages;
                foreach (var channelMessage in messages)
                {
                    Console.WriteLine("Content:{0},DateTime:{1:dd/MM/yyyy hh:mm:ss},User{2}",
                        channelMessage.Content,
                        channelMessage.DateTime,
                        channelMessage.Username);
                }
            });
        }
    }
}
