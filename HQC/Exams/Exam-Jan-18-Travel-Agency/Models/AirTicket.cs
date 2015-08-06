namespace Nashmat.Models
{
    using System;
    using Enums;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string departureAirport,
            string arrivalAirport, string airlineCompany, DateTime departureDateAndTime,
            decimal price)
            : base(TicketType.Air, departureAirport, arrivalAirport, departureDateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.AirlineCompany = airlineCompany;
        }

        public string FlightNumber { get; private set; }

        public string AirlineCompany { get; private set; }
    }
}