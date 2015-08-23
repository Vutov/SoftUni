namespace BULS.Tests
{
    using BangaloreUniversityLearningSystem.Data.Repositories;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGet
    {
        private IRepository<User> context;

        [TestInitialize]
        public void InitGet()
        {
            this.context = new UsersRepository();
        }

        [TestMethod]
        public void TestGetWhenEmptyShouldReturnNull()
        {
            var user = this.context.Get(1);
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void TestGetWhenDontExistShouldReturnNull()
        {
            this.context.Add(new User("somemm", "passss", Role.Student));
            var user = this.context.Get(2);
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void TestGetExistsShouldReturnUser()
        {
            this.context.Add(new User("somemm", "passss", Role.Student));
            this.context.Add(new User("somemm1", "passss2", Role.Student));
            this.context.Add(new User("somemm2", "passss3", Role.Student));
            var user = this.context.Get(2);
            Assert.AreEqual("somemm1", user.Username);
            Assert.AreEqual(HashUtilities.HashPassword("passss2"), user.Password);
            Assert.AreEqual(Role.Student, user.Role);
        }
    }
}
