namespace RegisterUserTests
{
    using System;
    using System.Collections.Generic;
    using IssueTracker;
    using IssueTracker.Core;
    using IssueTracker.Enums;
    using IssueTracker.Interfaces;
    using IssueTracker.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetMyIssuesTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitGetMyIssues()
        {
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void TestGetMyIssuesWhenNotLoggedShouldReturnErrorStatus()
        {
            var message = tracker.GetMyIssues();
            Assert.AreEqual(Message.NoOneLogged, message);
        }

        [TestMethod]
        public void TestGetMyIssuesWhenNoIssuesListedShouldReturnNotFoundStatus()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            var message = tracker.GetMyIssues();
            Assert.AreEqual(Message.NoIssues, message);
        }

        [TestMethod]
        public void TestGetMyIssuesWhenHasIssuesListedShouldReturnIssues()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            this.tracker.CreateIssue("some", "issue", IssuePriority.Low, new string[] {"a", "b", "c"});
            var message = tracker.GetMyIssues();
            var expectedMessage = new Problem(1, "some", "issue", IssuePriority.Low, new List<string>() {"a", "b", "c"}).ToString();
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestGetMyIssuesWhenHasTwoIssuesListedShouldReturnOrderedIssues()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            this.tracker.CreateIssue("some", "issue", IssuePriority.Low, new string[] { "a", "b", "c" });
            this.tracker.CreateIssue("other", "missue", IssuePriority.High, new string[] { "a", "b", "c" });
            var message = tracker.GetMyIssues();
            var expectedMessage =
                new Problem(2, "other", "missue", IssuePriority.High, new List<string>() {"a", "b", "c"}) +
                Environment.NewLine +
                new Problem(1, "some", "issue", IssuePriority.Low, new List<string>() {"a", "b", "c"});
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
