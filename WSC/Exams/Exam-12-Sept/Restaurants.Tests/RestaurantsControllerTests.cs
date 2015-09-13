namespace Restaurants.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data.DataLayer;
    using Data.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurants.Models;
    using Services.Controllers;
    using Services.Infrastructure;
    using Services.Models.BindingModels;
    using Services.Models.ViewModels;

    [TestClass]
    public class RestaurantsControllerTests
    {
        [TestMethod]
        public void GetAllRestaurantsWhenHasSuchTownAndOnlyOneRestaurantShouldReturnOkAndOneRestaurant()
        {
            // Setup fake restaurants
            var user = new ApplicationUser() { Id = "1", UserName = "Fake User", PasswordHash = "1234" };
            var sofia = new Town() { Id = 1, Name = "Sofia" };
            var fakeTown = new Town()
            {
                Id = 1,
                Name = "Sofia",
                Restaurants = new List<Restaurant>()
                {
                    new Restaurant()
                    {
                        Id = 1,
                        Name = "BSecond",
                        Owner = user,
                        Ratings = new List<Rating>()
                        {
                            new Rating()
                            {
                                Stars = 1,
                                User = new ApplicationUser()
                                {
                                    Id = "2",
                                    UserName = "Fake User2",
                                    PasswordHash = "1234"
                                }
                            }
                        },
                        Meals = new List<Meal>(),
                        Town = sofia
                    }
                }
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Town>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(fakeTown);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Towns).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, new AspNetUserIdProvider());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetRestaurantsByTown(1).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var restaurants = response.Content
                .ReadAsAsync<IEnumerable<RestaurantViewModel>>()
                .Result
                .Select(r => r.Name)
                .ToList();
            var fakeRestourants = fakeTown.Restaurants
                .Select(r => r.Name)
                .ToList();
            CollectionAssert.AreEqual(fakeRestourants, restaurants);
        }

        [TestMethod]
        public void GetAllRestaurantsWhenHasSuchTownAndMoreThanOneRestaurantShouldReturnOkAndOrderTheRestaurants()
        {
            // Setup fake restaurants
            var user = new ApplicationUser() { Id = "1", UserName = "Fake User", PasswordHash = "1234" };
            var sofia = new Town() { Id = 1, Name = "Sofia" };
            var fakeTown = new Town()
            {
                Id = 1,
                Name = "Sofia",
                Restaurants = new List<Restaurant>()
                {
                    new Restaurant()
                    {
                        Id = 1,
                        Name = "Best",
                        Owner = user,
                        Ratings = new List<Rating>()
                        {
                            new Rating()
                            {
                                Stars = 10,
                                User = new ApplicationUser()
                                {
                                    Id = "2",
                                    UserName = "Fake User2",
                                    PasswordHash = "1234"
                                }
                            }
                        },
                        Meals = new List<Meal>(),
                        Town = sofia
                    },
                    new Restaurant()
                    {
                        Id = 2,
                        Name = "BSecond",
                        Owner = user,
                        Ratings = new List<Rating>()
                        {
                            new Rating()
                            {
                                Stars = 1,
                                User = new ApplicationUser()
                                {
                                    Id = "2",
                                    UserName = "Fake User2",
                                    PasswordHash = "1234"
                                }
                            }
                        },
                        Meals = new List<Meal>(),
                        Town = sofia
                    },
                    new Restaurant()
                    {
                        Id = 3,
                        Name = "AThird",
                        Owner = user,
                        Ratings = new List<Rating>()
                        {
                            new Rating()
                            {
                                Stars = 1,
                                User = new ApplicationUser()
                                {
                                    Id = "2",
                                    UserName = "Fake User2",
                                    PasswordHash = "1234"
                                }
                            }
                        },
                        Meals = new List<Meal>(),
                        Town = sofia
                    }
                }
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Town>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(fakeTown);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Towns).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, new AspNetUserIdProvider());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetRestaurantsByTown(1).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var restaurants = response.Content
                .ReadAsAsync<IEnumerable<RestaurantViewModel>>()
                .Result
                .Select(r => r.Name)
                .ToList();
            var fakeRestourants = fakeTown.Restaurants
                .OrderByDescending(r => r.Ratings.Select(ra => ra.Stars).Average())
                 .ThenBy(r => r.Name)
                .Select(r => r.Name)
                .ToList();
            CollectionAssert.AreEqual(fakeRestourants, restaurants);
        }

        [TestMethod]
        public void GetAllRestaurantsWhenHasNoSuchTownShouldReturnOkAndEmptyList()
        {
            // Setup repositories
            var mockedRepository = new Mock<IRepository<Town>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns((Town)null);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Towns).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, new AspNetUserIdProvider());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetRestaurantsByTown(1).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var restaurants = response.Content
                .ReadAsAsync<IEnumerable<RestaurantViewModel>>()
                .Result
                .Select(r => r.Name)
                .ToList();

            Assert.AreEqual(0, restaurants.Count);
        }

        [TestMethod]
        public void RateRestaurantWIthValidDataShouldReturnOk()
        {
            // Setup fake restaurants
            var user = new ApplicationUser() { Id = "1", UserName = "Fake User", PasswordHash = "1234" };
            var sofia = new Town() { Id = 1, Name = "Sofia" };
            var restourant = new Restaurant()
            {
                Id = 1,
                Meals = new List<Meal>(),
                Name = "Fake",
                Owner = user,
                OwnerId = "1",
                Ratings = new List<Rating>(),
                Town = sofia
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Restaurant>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(restourant);
            var mockedUsers = new Mock<IRepository<ApplicationUser>>();
            mockedUsers.Setup(r => r.GetById(It.IsAny<string>())).Returns(user);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Restaurants).Returns(mockedRepository.Object);
            mockedContext.Setup(c => c.ApplicationUsers).Returns(mockedUsers.Object);
            var mockedProvider = new Mock<IUserIdProvider>();
            mockedProvider.Setup(p => p.GetUserId()).Returns("10");

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, mockedProvider.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostRateExistingRestaurant(1, new RatingBindingModel()
            {
                Stars = 1
            })
                .ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual(1, restourant.Ratings.Count);
            Assert.AreEqual(1, restourant.Ratings.Select(r => r.Stars).Average());
        }

        [TestMethod]
        public void RateRestaurantWithInvalidIdShouldReturnNotFound()
        {
            // Setup repositories
            var mockedRepository = new Mock<IRepository<Restaurant>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns((Restaurant)null);
            var mockedUsers = new Mock<IRepository<ApplicationUser>>();

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Restaurants).Returns(mockedRepository.Object);
            mockedContext.Setup(c => c.ApplicationUsers).Returns(mockedUsers.Object);
            var mockedProvider = new Mock<IUserIdProvider>();
            mockedProvider.Setup(p => p.GetUserId()).Returns("10");

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, mockedProvider.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostRateExistingRestaurant(1, new RatingBindingModel()
            {
                Stars = 1
            })
                .ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void RateRestaurantWithValidIdButOwnerRatingHisRestaurantShouldReturnBadRequest()
        {
            // Setup fake restaurants
            var user = new ApplicationUser() { Id = "1", UserName = "Fake User", PasswordHash = "1234" };
            var sofia = new Town() { Id = 1, Name = "Sofia" };
            var restourant = new Restaurant()
            {
                Id = 1,
                Meals = new List<Meal>(),
                Name = "Fake",
                Owner = user,
                OwnerId = "1",
                Ratings = new List<Rating>(),
                Town = sofia
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Restaurant>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(restourant);
            var mockedUsers = new Mock<IRepository<ApplicationUser>>();
            mockedUsers.Setup(r => r.GetById(It.IsAny<string>())).Returns(user);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Restaurants).Returns(mockedRepository.Object);
            mockedContext.Setup(c => c.ApplicationUsers).Returns(mockedUsers.Object);
            var mockedProvider = new Mock<IUserIdProvider>();
            mockedProvider.Setup(p => p.GetUserId()).Returns("1");

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, mockedProvider.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostRateExistingRestaurant(1, new RatingBindingModel()
            {
                Stars = 1
            })
                .ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual(0, restourant.Ratings.Count);
        }

        [TestMethod]
        public void RateRestaurantWhenAllReadyRatedWIthValidDataShouldReturnOkAndOverridePreviousRating()
        {
            // Setup fake restaurants
            var user = new ApplicationUser() { Id = "1", UserName = "Fake User", PasswordHash = "1234" };
            var sofia = new Town() { Id = 1, Name = "Sofia" };
            var restourant = new Restaurant()
            {
                Id = 1,
                Meals = new List<Meal>(),
                Name = "Fake",
                Owner = user,
                OwnerId = "1",
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Stars = 1,
                        UserId = "10"
                    }
                },
                Town = sofia
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Restaurant>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(restourant);
            var mockedUsers = new Mock<IRepository<ApplicationUser>>();
            mockedUsers.Setup(r => r.GetById(It.IsAny<string>())).Returns(user);

            // Setup data layer
            var mockedContext = new Mock<IRestaurantData>();
            mockedContext.Setup(c => c.Restaurants).Returns(mockedRepository.Object);
            mockedContext.Setup(c => c.ApplicationUsers).Returns(mockedUsers.Object);
            var mockedProvider = new Mock<IUserIdProvider>();
            mockedProvider.Setup(p => p.GetUserId()).Returns("10");

            // Setup controller
            var controller = new RestaurantsController(mockedContext.Object, mockedProvider.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostRateExistingRestaurant(1, new RatingBindingModel()
            {
                Stars = 10
            })
                .ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual(1, restourant.Ratings.Count);
            Assert.AreEqual(10, restourant.Ratings.Select(r => r.Stars).Average());
        }
    }
}
