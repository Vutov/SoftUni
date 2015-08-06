namespace Nashmat.Models
{
    using System;
    using Enums;

    public class BusTicket : Ticket
    {
        public BusTicket(string departureTown,
            string arrivalTown, string travelCompany, DateTime departureDateAndTime,
            decimal price)
            : base(TicketType.Bus, departureTown, arrivalTown, departureDateAndTime, price)
        {
            this.TravelComany = travelCompany;
        }

        public string TravelComany { get; private set; }
    }
}