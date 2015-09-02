namespace OnlineShop.Tests.Mocked
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repositories;
    using Moq;
    using OnlineShop.Models;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UsersRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeCategories();

            this.SetupFakeUsers();

            this.SetupFakeAdTypes();

            this.SetupFakeAds();
        }

        private void SetupFakeAds()
        {
            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 1,
                    Name = "Ad1",
                    Type = new AdType() {Name = "Normal", Index = 101},
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser() {UserName = "SomeDude", Id = "1234"},
                    Price = 100
                },
                new Ad()
                {
                    Id = 2,
                    Name = "Ad2",
                    Type = new AdType() {Name = "Premium", Index = 102},
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser() {UserName = "SomeDude2", Id = "1235"},
                    Price = 101
                },
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(u => u.All()).Returns(fakeAds.AsQueryable());
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType(){Id = 1, Name = "at1"},
                new AdType(){Id = 2, Name = "at2"},
                new AdType(){Id = 3, Name = "at3"},
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(u => u.All()).Returns(fakeAdTypes.AsQueryable());
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category(){Id = 1, Name = "C1"},
                new Category(){Id = 2, Name = "C2"},
                new Category(){Id = 3, Name = "C3"},
            };
            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(u => u.All()).Returns(fakeCategories.AsQueryable());
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser(){UserName = "Some1", Id = "1"},
                new ApplicationUser(){UserName = "Some2", Id = "2"},
                new ApplicationUser(){UserName = "Some3", Id = "3"},
            };
            this.UsersRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UsersRepositoryMock.Setup(u => u.All()).Returns(fakeUsers.AsQueryable());
        }
    }
}
