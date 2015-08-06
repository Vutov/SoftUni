namespace Nashmat.Models
{
    using System;
    using Enums;

    public abstract class Ticket
    {
        protected Ticket(TicketType ticketType, string from, string to, DateTime departureDateAndTime, decimal price)
        {
            this.TicketType = ticketType;
            this.From = from;
            this.To = to;
            this.DepartureDateAndTime = departureDateAndTime;
            this.Price = price;
        }

        public TicketType TicketType { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public DateTime DepartureDateAndTime { get; private set; }

        public decimal Price { get; private set; }

        public override string ToString()
        {
            var result = "[" + this.DepartureDateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.TicketType.ToString().ToLower() + "; " +
                           String.Format("{0:f2}", this.Price) + "]";
            return result;
        }
    }
}