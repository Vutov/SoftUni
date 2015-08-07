namespace TravelAgency.Tests
{
    using System;
    using Core;
    using Enums;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeleteAirTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitDeleteAirTicket()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestDeleteAirTicketWhenEmptyShouldHaveNone()
        {
            var result = this.catalog.DeleteAirTicket("123123a");
            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketWhenExistingTicketShouldDeleteIt()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);
            var result = this.catalog.DeleteAirTicket("asd");
            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
