namespace Nashmat.Models
{
    using System;
    using Enums;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string departureTown,
            string arrivalTown, DateTime departureDateAndTime,
            decimal regularPrice, decimal studentsPrice)
            : base(TicketType.Train, departureTown, arrivalTown, departureDateAndTime, regularPrice)
        {
            this.StudentPrice = studentsPrice;
        }

        public decimal StudentPrice { get; private set; }
    }
}