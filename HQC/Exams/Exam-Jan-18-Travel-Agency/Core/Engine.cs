namespace Nashmat.Core
{
    using System;
    using System.Globalization;

    public class Engine
    {
        private const string DateTimeFormat = "dd.MM.yyyy HH:mm";
        private readonly TicketCatalog ticketCatalog;

        public Engine(TicketCatalog ticketCatalog)
        {
            this.ticketCatalog = ticketCatalog;
        }

        public string ExecuteCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            var command = line.Substring(0, firstSpaceIndex);
            var allData = line.Substring(firstSpaceIndex + 1);
            var data = allData.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].Trim();
            }

            var result = "Invalid command!";
            switch (command)
            {
                case "AddAir":
                    var addFlightNumber = data[0];
                    var departureAirport = data[1];
                    var arrivalAirport = data[2];
                    var airline = data[3];
                    var flightDateAndTime = DateTime.ParseExact(data[4], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    var flightPrice = decimal.Parse(data[5]);
                    result = this.ticketCatalog.AddAirTicket(addFlightNumber, departureAirport,
                        arrivalAirport, airline, flightDateAndTime, flightPrice);
                    break;
                case "DeleteAir":
                    var deleteFlightNumber = data[0];
                    result = this.ticketCatalog.DeleteAirTicket(deleteFlightNumber);
                    break;
                case "AddTrain":
                    var departureTrainStation = data[0];
                    var arrivalTrainStation = data[1];
                    var trainDateAndTime = DateTime.ParseExact(data[2], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    var regularPrice = decimal.Parse(data[3]);
                    var studentPrice = decimal.Parse(data[4]);
                    result = this.ticketCatalog.AddTrainTicket(departureTrainStation, arrivalTrainStation,
                        trainDateAndTime, regularPrice, studentPrice);
                    break;
                case "DeleteTrain":
                    var deleteDepartureTrainStation = data[0];
                    var deleteArrivalTrainStation = data[1];
                    var deleteTrainDateAndTime = DateTime.ParseExact(data[2], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.DeleteTrainTicket(deleteDepartureTrainStation, deleteArrivalTrainStation,
                        deleteTrainDateAndTime);
                    break;
                case "AddBus":
                    var departureTown = data[0];
                    var arrivalTown = data[1];
                    var busCompany = data[2];
                    var busDateAndTime = DateTime.ParseExact(data[3], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    var busPrice = decimal.Parse(data[4]);
                    result = this.ticketCatalog.AddBusTicket(departureTown, arrivalTown, busCompany,
                        busDateAndTime, busPrice);
                    break;
                case "DeleteBus":
                    var deleteDepartureTown = data[0];
                    var deleteArrivalTown = data[1];
                    var deleteBusCompany = data[2];
                    var deleteBusDateAndTime = DateTime.ParseExact(data[3], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.DeleteBusTicket(deleteDepartureTown, deleteArrivalTown, deleteBusCompany,
                        deleteBusDateAndTime);
                    break;
                case "FindTickets":
                    var findTicketsFrom = data[0];
                    var findTicketsTo = data[1];
                    result = this.ticketCatalog.FindTickets(findTicketsFrom, findTicketsTo);
                    break;
                case "FindTicketsInInterval":
                    var findTicketsStarting = DateTime.ParseExact(data[0], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    var findTicketsEnding = DateTime.ParseExact(data[1], DateTimeFormat,
                CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.FindTicketsInInterval(findTicketsStarting, findTicketsEnding);
                    break;
            }

            return result;
        }
    }
}