using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegisterUserTests
{
    using IssueTracker;
    using IssueTracker.Core;
    using IssueTracker.Interfaces;
    using IssueTracker.Models;

    [TestClass]
    public class RegisterUserTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitRegisterUser()
        {
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void TestRegisterUserWhenNoneOtherRegisteredShouldRegister()
        {
            var username = "t";
            var message = this.tracker.RegisterUser(username, "123", "123");
            Assert.AreEqual(string.Format(Message.RegisteredSuccessfully, username), message);
        }

        [TestMethod]
        public void TestRegisterUserWhenPasswordsDoesNotMatchShouldReturnErorStatus()
        {
            var username = "t";
            var message = this.tracker.RegisterUser(username, "123", "13");
            Assert.AreEqual(Message.NotMatchingPasswords, message);
        }

        [TestMethod]
        public void TestRegisterUserWhenAlreadyLoggesShouldReturnErorStatus()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            this.tracker.LoginUser(username, password);
            var message = this.tracker.RegisterUser(username + "1", password, password);
            Assert.AreEqual(Message.AlreadyLogged, message);
        }

        [TestMethod]
        public void TestRegisterUserWhenAlreadyExistShouldReturnErorStatus()
        {
            var username = "t";
            var password = "123";
            this.tracker.RegisterUser(username, password, password);
            var message = this.tracker.RegisterUser(username, password, password);
            Assert.AreEqual(string.Format(Message.UserExists, username), message);
        }
    }
}
