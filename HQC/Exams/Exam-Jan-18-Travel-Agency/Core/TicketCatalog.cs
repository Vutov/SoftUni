namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interfaces;
    using Models;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly List<AirTicket> airTickets;
        private readonly List<TrainTicket> trainTickets;
        private readonly List<BusTicket> busTickets;

        public TicketCatalog()
        {
            this.airTickets = new List<AirTicket>();
            this.trainTickets = new List<TrainTicket>();
            this.busTickets = new List<BusTicket>();
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            if (!this.airTickets.Any(t => t.FlightNumber == flightNumber))
            {
                var ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);
                this.airTickets.Add(ticket);
                return "Ticket added";
            }

            return "Duplicate ticket";
        }

        public string DeleteAirTicket(string flightNumber)
        {
            if (this.airTickets.Any(t => t.FlightNumber == flightNumber))
            {
                this.airTickets.RemoveAll(t => t.FlightNumber == flightNumber);
                return "Ticket deleted";
            }

            return "Ticket does not exist";
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            if (!this.trainTickets.Any(t =>
                t.From == from &&
                t.To == to &&
                t.DepartureDateAndTime == dateTime))
            {
                var ticket = new TrainTicket(from, to, dateTime, price, studentPrice);
                this.trainTickets.Add(ticket);
                return "Ticket added";
            }

            return "Duplicate ticket";
        }

        public string DeleteTrainTicket(string @from, string to, DateTime dateTime)
        {
            if (this.trainTickets.Any(t =>
                t.From == from &&
                t.To == to &&
                t.DepartureDateAndTime == dateTime))
            {
                this.trainTickets.RemoveAll(t =>
                    t.From == from &&
                    t.To == to &&
                    t.DepartureDateAndTime == dateTime);

                return "Ticket deleted";
            }

            return "Ticket does not exist";
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            if (!this.busTickets.Any(t =>
                t.From == from &&
                t.To == to &&
                t.TravelComany == travelCompany &&
                t.DepartureDateAndTime == dateTime))
            {
                var ticket = new BusTicket(from, to, travelCompany, dateTime, price);
                this.busTickets.Add(ticket);
                return "Ticket added";
            }

            return "Duplicate ticket";
        }

        public string DeleteBusTicket(string @from, string to, string travelCompany, DateTime dateTime)
        {
            if (this.busTickets.Any(t =>
                t.From == from &&
                t.To == to &&
                t.TravelComany == travelCompany &&
                t.DepartureDateAndTime == dateTime))
            {
                this.busTickets.RemoveAll(t =>
                t.From == from &&
                t.To == to &&
                t.TravelComany == travelCompany &&
                t.DepartureDateAndTime == dateTime);

                return "Ticket deleted";
            }

            return "Ticket does not exist";
        }

        public string FindTickets(string from, string to)
        {
            var allTickets = this.GetAllTicketsFromTo(from, to);
            var processedTickets = this.ProcessTickets(allTickets);
            return processedTickets;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var allTickets = this.GetAllTicketsIninterval(startDateTime, endDateTime);
            var processedTickets = this.ProcessTickets(allTickets);
            return processedTickets;
        }

        public int GetTicketsCount(string type)
        {
            if (type == "air")
            {
                return this.airTickets.Count;
            }

            if (type == "bus")
            {
                return this.busTickets.Count;
            }

            return this.trainTickets.Count;
        }

        public int GetTicketsCount(TicketType type)
        {
            var ticketCount = 0;
            switch (type)
            {
                case TicketType.Air:
                    ticketCount = this.airTickets.Count;
                    break;
                case TicketType.Bus:
                    ticketCount = this.busTickets.Count;
                    break;
                case TicketType.Train:
                    ticketCount = this.trainTickets.Count;
                    break;
            }

            return ticketCount;
        }

        private HashSet<Ticket> GetAllTicketsFromTo(string from, string to)
        {
            var allTickets = new HashSet<Ticket>();
            this.airTickets.ForEach(t =>
            {
                if (t.From == from && t.To == to)
                {
                    allTickets.Add(t);
                }
            });

            this.busTickets.ForEach(t =>
            {
                if (t.From == from && t.To == to)
                {
                    allTickets.Add(t);
                }
            });

            this.trainTickets.ForEach(t =>
            {
                if (t.From == from && t.To == to)
                {
                    allTickets.Add(t);
                }
            });

            return allTickets;
        }

        private HashSet<Ticket> GetAllTicketsIninterval(DateTime startDateTime, DateTime endDateTime)
        {
            var allTickets = new HashSet<Ticket>();
            this.airTickets.ForEach(t =>
            {
                if (t.DepartureDateAndTime.CompareTo(startDateTime) >= 0 &&
                    t.DepartureDateAndTime.CompareTo(endDateTime) <= 0)
                {
                    allTickets.Add(t);
                }
            });

            this.busTickets.ForEach(t =>
            {
                if (t.DepartureDateAndTime.CompareTo(startDateTime) >= 0 &&
                    t.DepartureDateAndTime.CompareTo(endDateTime) <= 0)
                {
                    allTickets.Add(t);
                }
            });

            this.trainTickets.ForEach(t =>
            {
                if (t.DepartureDateAndTime.CompareTo(startDateTime) >= 0 &&
                    t.DepartureDateAndTime.CompareTo(endDateTime) <= 0)
                {
                    allTickets.Add(t);
                }
            });

            return allTickets;
        }

        private string ProcessTickets(HashSet<Ticket> allTickets)
        {
            if (allTickets.Count > 0)
            {
                var result = allTickets
                    .OrderBy(t => t.DepartureDateAndTime)
                    .ThenBy(t => t.TicketType.ToString())
                    .ThenBy(t => t.Price)
                    .ToList();

                return string.Join(" ", result);
            }

            return "Not found";
        }
    }
}
