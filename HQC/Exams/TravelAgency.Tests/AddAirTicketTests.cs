namespace TravelAgency.Tests
{
    using System;
    using Core;
    using Enums;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class AddAirTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitAddAirTicket()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestAddAirTicketWhenEmptyShouldHaveNone()
        {
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketWhenEmptyShouldHaveOne()
        {
            var result = this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);

            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddAirTicketWhenDuplicateShouldReturnDuplicate()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);
            var result = this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);

            Assert.AreEqual("Duplicate ticket", result);
        }
    }
}
