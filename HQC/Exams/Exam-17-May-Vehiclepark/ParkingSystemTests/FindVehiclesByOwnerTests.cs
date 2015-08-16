namespace ParkingSystemTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VehicleParkSystem;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;

    [TestClass]
    public class FindVehiclesByOwnerTests
    {
        private VehiclePark vehiclePark;

        [TestInitialize]
        public void InitExit()
        {
            var mockedData = new Mock<IVehicleParkData>();
            mockedData.Setup(m => m.GetVehiclesByOwner("pesho")).Returns(new List<IVehicle>());

            var car1 = new Car("SA1234BB", "ivan", 10);
            var car2 = new Car("SA1234BC", "ivan", 5);
            var car3 = new Car("SA1234BD", "ivan", 3);
            mockedData.Setup(m => m.GetVehiclesByOwner("ivan"))
                .Returns(new List<IVehicle>()
                {
                    car1, car2, car3
                });
            mockedData.Setup(m => m.GetVehicle("SA1234BB"))
                .Returns(car1);
            mockedData.Setup(m => m.GetParkedSpot(car1)).Returns("(1,1)");
            mockedData.Setup(m => m.GetVehicle("SA1234BC"))
                .Returns(car2);
            mockedData.Setup(m => m.GetParkedSpot(car2)).Returns("(1,2)");
            mockedData.Setup(m => m.GetVehicle("SA1234BD"))
                .Returns(car3);
            mockedData.Setup(m => m.GetParkedSpot(car3)).Returns("(1,3)");

            this.vehiclePark = new VehiclePark(10, 10, mockedData.Object);
        }


        [TestMethod]
        public void TestFindCarsByOwnerWhenNoCarsShouldReturnErrorStatus()
        {
            var message = this.vehiclePark.FindVehiclesByOwner("pesho");
            Assert.AreEqual(string.Format(Message.NoVehiclesByOwner, "pesho"), message);
        }

        [TestMethod]
        public void TestFindCarsByOwnerWhenHasCarsShouldReturnCorrectStatus()
        {
            var message = this.vehiclePark.FindVehiclesByOwner("ivan");
            var exprected =
@"Car [SA1234BB], owned by ivan
Parked at (1,1)
Car [SA1234BC], owned by ivan
Parked at (1,2)
Car [SA1234BD], owned by ivan
Parked at (1,3)";
            Assert.AreEqual(exprected, message);
        }
    }
}
