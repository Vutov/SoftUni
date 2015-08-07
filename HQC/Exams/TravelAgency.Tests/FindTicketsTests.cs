using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.Tests
{
    using Core;
    using Interfaces;

    [TestClass]
    public class FindTicketsTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitFindTicketsTests()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestFindTicketsWhenNoTicketsAdded()
        {
            var result = this.catalog.FindTickets("varna", "sofia");

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void TestFindTicketsWhenNoTicketsInRangeAdded()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);
            this.catalog.AddAirTicket("asd1", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);
            this.catalog.AddAirTicket("asd2", "sofia", "varna", "mecompany", new DateTime(2000, 1, 1), 10m);
            
            var result = this.catalog.FindTickets("varna", "sofia");

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void TestFindTicketsWhenHasAddedTicketsInRange()
        {
            this.catalog.AddAirTicket("asd", "varna", "sofia", "mecompany", new DateTime(2001, 1, 1, 12, 15, 0), 10m);
            this.catalog.AddAirTicket("asd1", "sofia", "varna", "mecompany1", new DateTime(2002, 1, 1), 10m);
            this.catalog.AddAirTicket("asd2", "sofia", "varna", "mecompany2", new DateTime(2003, 1, 1), 10m);

            var result = this.catalog.FindTickets("varna", "sofia");

            Assert.AreEqual("[01.01.2001 12:15; air; 10.00]", result);
        }

        [TestMethod]
        public void TestFindTicketsWhenHasManyAddedTicketsInRange()
        {
            this.catalog.AddAirTicket("asd", "varna", "sofia", "mecompany", new DateTime(2001, 1, 1, 12, 3, 0), 10m);
            this.catalog.AddAirTicket("other", "varna", "blagoevragd", "mecompany", new DateTime(2001, 1, 1, 11, 5, 0), 15m);
            this.catalog.AddAirTicket("asd2", "varna", "sofia", "mecompany2", new DateTime(2003, 1, 1, 0, 0, 0), 20m);

            var result = this.catalog.FindTickets("varna", "sofia");

            Assert.AreEqual("[01.01.2001 12:03; air; 10.00] [01.01.2003 00:00; air; 20.00]", result);
        }
    }
}
