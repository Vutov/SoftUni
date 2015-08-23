namespace BULS.Tests
{
    using System;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data.Repositories;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestAddLecture
    {
        [TestMethod]
        public void TestAddLectureWhenLoggedAndCourseIsSetShouldReturnAddMessage()
        {
            var mockedData = new Mock<IBangaloreUniversityData>();
            var courses = new MockedRepositories.MockCourseRepository();
            courses.Add(new Course("habala"));
            mockedData.Setup(r => r.Courses()).Returns(courses);
            var controller = new CoursesController(mockedData.Object, new User("blablabla", "b;a;ba;ba;", Role.Lecturer));
            var result = controller.AddLecture(1, "balba");
            var message = string.Format(Message.LectureAddedSuccessfully, "habala");
            Assert.AreEqual(message, result.Display());
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestAddLectureWhenDontHavePermisionShouldThrowException()
        {
            var mockedData = new Mock<IBangaloreUniversityData>();
            var courses = new MockedRepositories.MockCourseRepository();
            courses.Add(new Course("habala"));
            mockedData.Setup(r => r.Courses()).Returns(courses);
            var controller = new CoursesController(mockedData.Object, new User("blablabla", "b;a;ba;ba;", Role.Student));
            var result = controller.AddLecture(1, "balba");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLectureWhenNotLoggedShouldThrowException()
        {
            var mockedData = new Mock<IBangaloreUniversityData>();
            var courses = new MockedRepositories.MockCourseRepository();
            courses.Add(new Course("habala"));
            mockedData.Setup(r => r.Courses()).Returns(courses);
            var controller = new CoursesController(mockedData.Object, null);
            var result = controller.AddLecture(1, "balba");
        }
    }
}
