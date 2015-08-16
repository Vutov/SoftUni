namespace VehicleParkSystem.Core
{
    using System;
    using System.Globalization;
    using Interfaces;
    using Models;

    public class CommandHandler
    {
        private IVehiclePark vehiclePark;

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.vehiclePark == null)
            {
                return Message.VehicleParkNotSetUp;
            }

            var message = string.Empty;
            switch (command.Name)
            {
                case "SetupPark":
                    this.vehiclePark = new VehiclePark(
                        int.Parse(command.Parameters["sectors"]),
                        int.Parse(command.Parameters["placesPerSector"]));
                    message = Message.VehicleParkCreated;
                    break;
                case "Park":
                    var licensePlate = command.Parameters["licensePlate"];
                    var owner = command.Parameters["owner"];
                    var reservedHours = int.Parse(command.Parameters["hours"]);
                    var place = int.Parse(command.Parameters["place"]);
                    var sector = int.Parse(command.Parameters["sector"]);
                    var time = DateTime.Parse(command.Parameters["time"]);
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            var car = new Car(licensePlate, owner, reservedHours);
                            message = this.vehiclePark.InsertCar(car, sector, place, time);
                            break;
                        case "motorbike":
                            var bike = new Motorbike(licensePlate, owner, reservedHours);
                            message = this.vehiclePark.InsertMotorbike(bike, sector, place, time);
                            break;
                        case "truck":
                            var truck = new Truck(licensePlate, owner, reservedHours);
                            message = this.vehiclePark.InsertTruck(truck, sector, place, time);
                            break;
                    }

                    break;
                case "Exit":
                    var exitLicesencePlate = command.Parameters["licensePlate"];
                    var exitTime = DateTime.Parse(command.Parameters["time"]);
                    var moneyOwed = decimal.Parse(command.Parameters["paid"]);
                    message = this.vehiclePark.ExitVehicle(
                        exitLicesencePlate,
                        exitTime,
                        moneyOwed);
                    break;
                case "Status":
                    message = this.vehiclePark.GetStatus();
                    break;
                case "FindVehicle":
                    message = this.vehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                    break;
                case "VehiclesByOwner":
                    message = this.vehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command");
            }

            return message;
        }
    }
}
