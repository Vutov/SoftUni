namespace RegisterUserTests
{
    using System;
    using IssueTracker;
    using IssueTracker.Core;
    using IssueTracker.Enums;
    using IssueTracker.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateIssueTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitCreateIssue()
        {
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void TestCreateIssueWhenNoIssueExistShouldReturnCreatedStatus()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            var message = this.tracker.CreateIssue("asa", "asdasd", IssuePriority.High, new string[] {"a", "b"});
            var id = 1;
            Assert.AreEqual(string.Format(Message.IssueCreated, id), message);
        }

        [TestMethod]
        public void TestCreateIssueWhenNotLoggedShouldReturnErrorStatus()
        {
            var message = this.tracker.CreateIssue("asa", "asdasd", IssuePriority.High, new string[] { "a", "b" });
            Assert.AreEqual(Message.NoOneLogged, message);
        }

        [TestMethod]
        public void TestCreateIssueAutoIncrementIdShouldAutoIncrementTheId()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            var message = this.tracker.CreateIssue("asa", "asdasd", IssuePriority.High, new string[] { "a", "b" });
            var id = 1;
            Assert.AreEqual(string.Format(Message.IssueCreated, id), message);
            var message2 = this.tracker.CreateIssue("asa2", "asdasd2", IssuePriority.High, new string[] { "a", "b" });
            var id2 = 2;
            Assert.AreEqual(string.Format(Message.IssueCreated, id2), message2);
            var message3 = this.tracker.CreateIssue("asa3", "asdasd3", IssuePriority.High, new string[] { "a", "b" });
            var id3 = 3;
            Assert.AreEqual(string.Format(Message.IssueCreated, id3), message3);
        }

        [TestMethod]
        public void TestCreateIssueAutoIncrementIdWhenWrongIssueIsAddedShouldAutoIncrementTheIdProperly()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            var message = this.tracker.CreateIssue("asa", "asdasd", IssuePriority.High, new string[] { "a", "b" });
            var id = 1;
            Assert.AreEqual(string.Format(Message.IssueCreated, id), message);
            try
            {
                this.tracker.CreateIssue("", "", IssuePriority.High, new string[] { "a", "b" });
            }
            catch (ArgumentException ex)
            {
                
            }

            var message2 = this.tracker.CreateIssue("asa2", "asdasd2", IssuePriority.High, new string[] { "a", "b" });
            var id2 = 2;
            Assert.AreEqual(string.Format(Message.IssueCreated, id2), message2);
        }
    }
}
