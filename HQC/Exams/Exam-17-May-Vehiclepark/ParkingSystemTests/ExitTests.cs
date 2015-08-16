using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingSystemTests
{
    using VehicleParkSystem;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Models;

    [TestClass]
    public class ExitTests
    {
        private VehiclePark vehiclePark;

        [TestInitialize]
        public void InitExit()
        {
            this.vehiclePark = new VehiclePark(10, 10);
        }

        [TestMethod]
        public void TestExitWhenNoSuchCarInsideShouldReturnErrorStatus()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            var message = this.vehiclePark.ExitVehicle("CA1235BB", DateTime.Now, 100);
            Assert.AreEqual(string.Format(Message.NoSuchVehicle, "CA1235BB"), message);
        }


        [TestMethod]
        public void TestExitWhenCarInsideShouldReturnTicketStatus()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            this.vehiclePark.InsertCar(car, 1, 1, new DateTime(2000,1,1,1,0,0));
            var message = this.vehiclePark.ExitVehicle("CA1234AA", new DateTime(2000,1,1,2,0,0), 1000);
            var ticket = new Ticket(car, 1000, "(1,1)", 1);
            Assert.AreEqual(ticket.ToString(), message);
        }
    }
}
