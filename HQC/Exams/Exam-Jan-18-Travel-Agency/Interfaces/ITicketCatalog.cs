namespace TravelAgency.Interfaces
{
    using System;
    using Enums;

    /// <summary>
    /// Catalog for tickets. Has adding/deleting of air, bus and train tickets.
    /// Supports simple queries for departure and arrival place and datetime range.
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds air tickets.
        /// </summary>
        /// <param name="flightNumber">Unique number of the flight.</param>
        /// <param name="from">Departure airport.</param>
        /// <param name="to">Arrival airport</param>
        /// <param name="airline">Airline company.</param>
        /// <param name="dateTime">Data and time of the flight.</param>
        /// <param name="price">Price of the ticket.</param>
        /// <returns></returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Deletes bus ticket by given departure place, arrival place, travel company and date and time of the ticket.
        /// </summary>
        /// <param name="from">Departure place.</param>
        /// <param name="to">Arrival place.</param>
        /// <param name="travelCompany">Travel company.</param>
        /// <param name="dateTime">Date and time of the ticket.</param>
        /// <returns></returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Find all tickets from given destination to an other given destination.
        /// </summary>
        /// <param name="from">Departure place.</param>
        /// <param name="to">Arrival place.</param>
        /// <returns>All tickets in the given range.</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Find all tickets in given date and time range.
        /// </summary>
        /// <param name="startDateTime">Start date and time of the range.</param>
        /// <param name="endDateTime">End date and time of the range.</param>
        /// <returns>All tickets in the given range.</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}