using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Tests
{
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using Moq;

    [TestClass]
    public class TestAllCourses
    {
        [TestMethod]
        public void TestAllCoursesWhenEmptyShouldReturnNoCourses()
        {
            var controller = new CoursesController(new BangaloreUniversityData(), new User("habala", "babbala", Role.Student));
            var result = controller.All();
            Assert.AreEqual(Message.NoCourses, result.Display());
        }

        [TestMethod]
        public void TestAllCoursesWhenHasCoursesShouldReturnTheCourses()
        {
            var data = new BangaloreUniversityData();
            var loginController = new UsersController(data, null);
            loginController.Register("habala", "babbala", "babbala", "Lecturer");
             var user = new User("habala", "babbala", Role.Lecturer);
            var controller = new CoursesController(data, user);
            controller.Create("tessst");
            controller.Create("tessst1");
            controller.Create("tessst3");
            var result = controller.All();
            var message = @"All courses:
tessst (0 students)
tessst1 (0 students)
tessst3 (0 students)";
            Assert.AreEqual(message, result.Display());
        }

    }
}
