namespace Messages.Tests.Models
{
    using System;

    public class MessageModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime? DateSent { get; set; }

        public string Sender { get; set; }
    }
}
