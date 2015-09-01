namespace Messages.Data.Models
{
    using System;

    public class UserMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Recipient { get; set; }
    }
}
