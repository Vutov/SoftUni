using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.Tests
{
    using Core;
    using Enums;
    using Interfaces;

    [TestClass]
    public class FindTicketsInIntervalTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitFindTicketsInInterval()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestFindTicketsInintervalWhenNoTicketsAdded()
        {
            var result = this.catalog.FindTicketsInInterval(
                new DateTime(2000, 1, 1, 12, 0, 0),
                new DateTime(2000, 1, 1, 12, 30, 0));

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void TestFindTicketsInintervalWhenNoTicketsInRangeAdded()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2001, 1, 1), 10m);
            this.catalog.AddAirTicket("asd1", "sofia1", "varna1", "mecompany1", new DateTime(2002, 1, 1), 10m);
            this.catalog.AddAirTicket("asd2", "sofia2", "varna2", "mecompany2", new DateTime(2003, 1, 1), 10m);

            var result = this.catalog.FindTicketsInInterval(
                new DateTime(2000, 1, 1, 12, 0, 0),
                new DateTime(2000, 1, 1, 12, 30, 0));

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void TestFindTicketsInintervalWhenHasAddedTicketsInRange()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2001, 1, 1, 12, 15, 0), 10m);
            this.catalog.AddAirTicket("asd1", "sofia1", "varna1", "mecompany1", new DateTime(2002, 1, 1), 10m);
            this.catalog.AddAirTicket("asd2", "sofia2", "varna2", "mecompany2", new DateTime(2003, 1, 1), 10m);

            var result = this.catalog.FindTicketsInInterval(
                new DateTime(2001, 1, 1, 12, 0, 0),
                new DateTime(2001, 1, 1, 12, 30, 0));

            Assert.AreEqual("[01.01.2001 12:15; air; 10.00]", result);
        }

        [TestMethod]
        public void TestFindTicketsInintervalWhenHasManyAddedTicketsInRange()
        {
            this.catalog.AddAirTicket("asd", "sofia", "varna", "mecompany", new DateTime(2001, 1, 1, 12, 15, 0), 10m);
            this.catalog.AddAirTicket("other", "varna", "blagoevragd", "mecompany", new DateTime(2001, 1, 1, 12, 3, 0), 15m);
            this.catalog.AddAirTicket("asd2", "sofia2", "varna2", "mecompany2", new DateTime(2003, 1, 1), 10m);

            var result = this.catalog.FindTicketsInInterval(
                new DateTime(2001, 1, 1, 12, 0, 0),
                new DateTime(2001, 1, 1, 12, 30, 0));

            Assert.AreEqual("[01.01.2001 12:03; air; 15.00] [01.01.2001 12:15; air; 10.00]", result);
        }
    }
}
