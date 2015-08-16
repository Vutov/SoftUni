namespace ParkingSystemTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Models;

    [TestClass]
    public class InsertCarTests
    {
        private VehiclePark vehiclePark;

        [TestInitialize]
        public void InitInsertCar()
        {
            this.vehiclePark = new VehiclePark(10, 10);
        }

        [TestMethod]
        public void TestInsertCarWhenNoOtherCarsInTheParkShouldReturnSuccessMessage()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            var message = this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            Assert.AreEqual(string.Format(Message.ParkedSucessfully, "Car", 1, 1), message);
        }

        [TestMethod]
        public void TestInsertCarInTheSameParkingSlotShouldReturnErrorMessage()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            var message = this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            Assert.AreEqual(string.Format(Message.PlaceOccupied, 1, 1), message);
        }

        [TestMethod]
        public void TestInsertCarInTheSameCarShouldReturnErrorMessage()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            var message = this.vehiclePark.InsertCar(car, 1, 2, DateTime.Now);
            Assert.AreEqual(string.Format(Message.DuplicateLicense, "CA1234AA"), message);
        }

        [TestMethod]
        public void TestInsertCarInInvalidPlaceShouldReturnErrorMessage()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            var message = this.vehiclePark.InsertCar(car, 1, 11, DateTime.Now);
            Assert.AreEqual(string.Format(Message.NoPlace, 11, 1), message);
        }

        [TestMethod]
        public void TestInsertCarInInvalidSectorhouldReturnErrorMessage()
        {
            var car = new Car("CA1234AA", "memeem", 5);
            var message = this.vehiclePark.InsertCar(car, 11, 1, DateTime.Now);
            Assert.AreEqual(string.Format(Message.NoSector, 11), message);
        }
    }
}
