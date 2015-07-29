using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheatreTests
{
    using System.Linq;
    using Theatre.Core;
    using Theatre.Exceptions;

    [TestClass]
    public class TheatreTests
    {
        private Engine applicationEngine;

        [TestInitialize]
        public void InitTheater()
        {
            this.applicationEngine = new Engine();
        }

        [TestMethod]
        public void TestListTheatresWhenEmptyShouldHaveNoTheatres()
        {
            var theatres = this.applicationEngine.ListTheatres();
            Assert.AreEqual(0, theatres.Count());
        }

        [TestMethod]
        public void TestListTheatresWhenOneTheatreAddedShouldHaveOneTheatre()
        {
            this.applicationEngine.AddTheatre("Some theatre");
            var theatres = this.applicationEngine.ListTheatres();
            Assert.AreEqual(1, theatres.Count());
        }

        [TestMethod]
        public void TestListTheatresWhenHundredUniqueTheatresAddedShouldHaveHundredTheatres()
        {
            const int TestNumOfTheatres = 100;
            for (int i = 0; i < TestNumOfTheatres; i++)
            {
                this.applicationEngine.AddTheatre("Some theatre" + i);
            }

            var theatres = this.applicationEngine.ListTheatres();
            Assert.AreEqual(TestNumOfTheatres, theatres.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void TestAddTheatreWithSameTheatresAddedShouldThrowDuplicateException()
        {
            this.applicationEngine.AddTheatre("Some theatre");
            this.applicationEngine.AddTheatre("Some theatre");
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformanceWhenNotExistingTheatreShouldThrowNotFoundExpection()
        {
            this.applicationEngine.AddPerformance("theatre", "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);
        }

        [TestMethod]
        public void TestAddPerformanceWithOneWhenExistingTheatreShouldHaveOnePerformance()
        {
            const string TheatreName = "Some theatre";
            this.applicationEngine.AddTheatre(TheatreName);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);

            var performances = this.applicationEngine.ListPerformances(TheatreName);
            Assert.AreEqual(1, performances.Count());
        }

        [TestMethod]
        public void TestAddPerformanceWithTenWhenExistingTheatreShouldAddTenPeroformanes()
        {
            const string TheatreName = "Some theatre";
            this.applicationEngine.AddTheatre(TheatreName);
            const int TestNum = 10;
            for (int i = 0; i < TestNum; i++)
            {
                this.applicationEngine.AddPerformance(TheatreName, "title" + i, new DateTime(2000, 01, i + 1), new TimeSpan(0, 0, 10), 40m);
            }

            var performances = this.applicationEngine.ListPerformances(TheatreName);
            Assert.AreEqual(TestNum, performances.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddPerformanceWhenTwoPerformancesHaveSameDateShouldThrowTimeDurationException()
        {
            const string TheatreName = "Some theatre";
            this.applicationEngine.AddTheatre(TheatreName);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);
        }


        [TestMethod]
        public void TestListPerformancesWhenNoneShouldHaveNonePerformances()
        {
            const string TheatreName = "Some theatre";
            this.applicationEngine.AddTheatre(TheatreName);
            var performances = this.applicationEngine.ListPerformances(TheatreName);
            Assert.AreEqual(0, performances.Count());
        }

        [TestMethod]
        public void TestListPerformancesWhenOnePeformancesShouldHaveOnePerformance()
        {
            const string TheatreName = "Some theatre";
            const int NumOfPerformances = 1;
            this.applicationEngine.AddTheatre(TheatreName);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);
            var performances = this.applicationEngine.ListPerformances(TheatreName);
            Assert.AreEqual(NumOfPerformances, performances.Count());
        }

        [TestMethod]
        public void TestListPerformancesWhenHundredPeformancesShouldHaveHundredPerformances()
        {
            const string TheatreName = "Some theatre";
            const int NumOfPerformances = 1;
            this.applicationEngine.AddTheatre(TheatreName);
            for (int i = 0; i < NumOfPerformances; i++)
            {
                this.applicationEngine.AddPerformance(TheatreName, "title" + i, DateTime.Now, new TimeSpan(0, 0, 10), 40m);
            }

            var performances = this.applicationEngine.ListPerformances(TheatreName);
            Assert.AreEqual(NumOfPerformances, performances.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestListPerformancesWhenTheatreIsMissingShouldThrowNotFoundException()
        {
            const string TheatreName = "Some theatre";
            var performances = this.applicationEngine.ListPerformances(TheatreName);
        }

        [TestMethod]
        public void TestListAllPerformancesWhenNoneShouldReturnNone()
        {
            var allPerformances = this.applicationEngine.ListAllPerformances();
            Assert.AreEqual(0, allPerformances.Count());
        }

        [TestMethod]
        public void TestListAllPerformancesWhenOneShouldReturnOne()
        {
            const string TheatreName = "Some theatre";
            const int NumOfPerformances = 1;
            this.applicationEngine.AddTheatre(TheatreName);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);

            var allPerformances = this.applicationEngine.ListAllPerformances();

            Assert.AreEqual(NumOfPerformances, allPerformances.Count());
        }

        [TestMethod]
        public void TestListAllPerfomancesWhenTwoTheatresHasDifferentPerformancesShouldReturnAll()
        {
            const string TheatreName = "Some theatre";
            const string TheatreName2 = "Some theatre2";
            this.applicationEngine.AddTheatre(TheatreName);
            this.applicationEngine.AddPerformance(TheatreName, "title", DateTime.Now, new TimeSpan(0, 0, 10), 40m);
            this.applicationEngine.AddTheatre(TheatreName2);
            this.applicationEngine.AddPerformance(TheatreName2, "title", DateTime.Now.AddDays(1), new TimeSpan(0, 0, 10), 40m);
            this.applicationEngine.AddPerformance(TheatreName2, "title1", DateTime.Now, new TimeSpan(0, 0, 10), 40m);

            var allPerformances = this.applicationEngine.ListAllPerformances();

            Assert.AreEqual(3, allPerformances.Count());
        }
    }
}
