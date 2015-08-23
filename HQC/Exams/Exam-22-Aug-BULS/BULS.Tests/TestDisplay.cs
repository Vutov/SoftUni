namespace BULS.Tests
{
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using BangaloreUniversityLearningSystem.Views.UsersController;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestDisplay
    {
        [TestMethod]
        public void TestDisplayUsingLoginActionShouldReturnLoginView()
        {
            var view = new Login(new User("habala", "babala", Role.Student));
            var result = view.Display();
            var message = string.Format(Message.UserLoggedSuccessfully, "habala");
            Assert.AreEqual(message, result);
        }


        [TestMethod]
        public void TestDisplayUsingMockedViewShouldReturnMocked()
        {
            var view = new MockedView(new User("habala", "babala", Role.Student));
            var result = view.Display();
            Assert.AreEqual("mocked", result);
        }
    }
}
