namespace ParkingSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VehicleParkSystem;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;

    [TestClass]
    public class FindVehicleTests
    {
        private VehiclePark vehiclePark;

        [TestMethod]
        public void TestFindVehcleWhenNotPresentShouldReturnErrorStatus()
        {
            var mockedData = new Mock<IVehicleParkData>();

            this.vehiclePark = new VehiclePark(10, 10, mockedData.Object);

            var message = this.vehiclePark.FindVehicle("CA1234VV");
            Assert.AreEqual(string.Format(Message.NoSuchVehicle, "CA1234VV"), message);
        }

        [TestMethod]
        public void TestFindVehcleWhenPresentShouldReturnVehicleStatus()
        {
            var mockedData = new Mock<IVehicleParkData>();
            var car1 = new Car("SA1234BB", "ivan", 10);
            var car2 = new Car("SA1234BC", "ivan", 5);
            var car3 = new Car("SA1234BD", "ivan", 3);

            mockedData
                .Setup(m => m.GetVehicle(car1.LicensePlate))
                .Returns(car1);
            mockedData.Setup(m => m.GetParkedSpot(car1)).Returns("(1,1)");
            mockedData
                .Setup(m => m.GetVehicle(car2.LicensePlate))
                .Returns(car2);
            mockedData.Setup(m => m.GetParkedSpot(car2)).Returns("(1,2)");
            mockedData
                .Setup(m => m.GetVehicle(car3.LicensePlate))
                .Returns(car3);
            mockedData.Setup(m => m.GetParkedSpot(car3)).Returns("(1,3)");
 
            this.vehiclePark = new VehiclePark(10, 10, mockedData.Object);

            var message1 = this.vehiclePark.FindVehicle(car1.LicensePlate);
            var expected1 = 
@"Car [SA1234BB], owned by ivan
Parked at (1,1)";
            Assert.AreEqual(expected1, message1);

            var message2 = this.vehiclePark.FindVehicle(car2.LicensePlate);
            var expected2 =
@"Car [SA1234BC], owned by ivan
Parked at (1,2)";
            Assert.AreEqual(expected2, message2);

            var message3 = this.vehiclePark.FindVehicle(car3.LicensePlate);
            var expected3 =
@"Car [SA1234BD], owned by ivan
Parked at (1,3)";
            Assert.AreEqual(expected3, message3);
        }
    }
}
