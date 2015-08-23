using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Tests
{
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    [TestClass]
    public class TestLogout
    {
        [TestMethod]
        public void TestLogoutWhenLogedInStudentShouldReturnSuccessMessage()
        {
            var controller = new UsersController(new BangaloreUniversityData(), new User("habala", "babbala", Role.Student));
            var result = controller.Logout();
            var message = string.Format(Message.UserLoggedOutSuccessfully, "habala");
            Assert.AreEqual(message, result.Display());
        }

        [TestMethod]
        public void TestLogoutWhenLogedInLecturerShouldReturnSuccessMessage()
        {
            var controller = new UsersController(new BangaloreUniversityData(), new User("habala", "babbala", Role.Lecturer));
            var result = controller.Logout();
            var message = string.Format(Message.UserLoggedOutSuccessfully, "habala");
            Assert.AreEqual(message, result.Display());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLogoutWhenNotLogedInShouldThrowArgumentException()
        {
            var controller = new UsersController(new BangaloreUniversityData(), null);
            controller.Logout();
        }

        [TestMethod]
        public void TestLogoutWhenNotLogedInShouldReturnMessageInException()
        {
            var controller = new UsersController(new BangaloreUniversityData(), null);
            try
            {
                var result = controller.Logout();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(Message.NoOneLogged, ex.Message);
            }
        }
    }
}
