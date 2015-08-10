using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegisterUserTests
{
    using System.Collections.Generic;
    using IssueTracker;
    using IssueTracker.Core;
    using IssueTracker.Enums;
    using IssueTracker.Interfaces;
    using IssueTracker.Models;

    [TestClass]
    public class SearchForIssueTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitSearchForIssue()
        {
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void TestSearchForIssueWhenNoTagsGivenShouldReturnErrorStatus()
        {
            var message = this.tracker.SearchForIssues(new string[0]);
            Assert.AreEqual(Message.NoTags, message);
        }

        [TestMethod]
        public void TestSearchForIssueWhenNoMathcingTagsGivenShouldReturnNoMatchingStatus()
        {
            var message = this.tracker.SearchForIssues(new[] { "a" });
            Assert.AreEqual(Message.NoMatchingTags, message);
        }

        [TestMethod]
        public void TestSearchForIssueWhenOneMathcingTagsGivenShouldReturnOneMatchingResult()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            this.tracker.CreateIssue("asa", "asdasd", IssuePriority.High, new string[] { "a", "b" });
            var message = this.tracker.SearchForIssues(new[] { "a" });
            var resultMessage = new Problem(1, "asa", "asdasd", IssuePriority.High, new List<string>() { "a", "b" }).ToString();
            Assert.AreEqual(resultMessage, message);
        }

        [TestMethod]
        public void TestSearchForIssueWhenMathcingTagsGivenShouldReturnOrderedMatchingResult()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            this.tracker.CreateIssue("some", "issue", IssuePriority.Low, new string[] { "a", "b", "c" });
            this.tracker.CreateIssue("other", "missue", IssuePriority.High, new string[] { "a", "b", "c" });
            var message = tracker.SearchForIssues(new[] { "a" });
            var expectedMessage =
                new Problem(2, "other", "missue", IssuePriority.High, new List<string>() { "a", "b", "c" }) +
                Environment.NewLine +
                new Problem(1, "some", "issue", IssuePriority.Low, new List<string>() { "a", "b", "c" });
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
