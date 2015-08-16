namespace ParkingSystemTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Models;

    [TestClass]
    public class GetStatusTests
    {
        private VehiclePark vehiclePark;

        [TestInitialize]
        public void InitGetStatus()
        {
            this.vehiclePark = new VehiclePark(2, 2);
        }

        [TestMethod]
        public void TestGetStatusWhenEmptyShouldReturnEmptyStatus()
        {
            var message = this.vehiclePark.GetStatus();
            var status = @"Sector 1: 0 / 2 (0% full)
Sector 2: 0 / 2 (0% full)";
            Assert.AreEqual(status, message);
        }

        [TestMethod]
        public void TestGetStatusWhenFilledShouldReturnFilledStatus()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            var car1 = new Car("CA1234AB", "memeem", 5);
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            this.vehiclePark.InsertCar(car1, 1, 2, DateTime.Now);
            
            var message = this.vehiclePark.GetStatus();
            var status = @"Sector 1: 2 / 2 (100% full)
Sector 2: 0 / 2 (0% full)";

            Assert.AreEqual(status, message);
        }
    }
}
