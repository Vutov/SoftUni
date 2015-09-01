namespace Messages.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;

    public class ChannelMessegeViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }

        public static Expression<Func<ChannelMessage, ChannelMessegeViewModel>> CreateChannelMessages
        {
            get
            {
                return c => new ChannelMessegeViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateSent = c.DateSent,
                    Sender = c.Sender == null ? null : c.Sender.UserName
                };
            }
        }

        public static Expression<Func<UserMessage, ChannelMessegeViewModel>> CreateUserMessages
        {
            get
            {
                return c => new ChannelMessegeViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateSent = c.DateSent,
                    Sender = c.Sender == null ? null : c.Sender.UserName
                };
            }
        }
    }
}