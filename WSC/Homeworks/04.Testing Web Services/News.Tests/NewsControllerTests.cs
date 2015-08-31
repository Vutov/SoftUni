namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data.DataLayer;
    using Data.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Services.Controllers;
    using Services.Models.BindingModels;
    using Services.Models.ViewModels;

    [TestClass]
    public class NewsControllerTests
    {
        [TestMethod]
        public void TestGetAllPostWhenHasNewsShouldReturnNewsSortedDescendingByDate()
        {
            // Setup fake news
            var fakeNews = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "1",
                    Content = "1",
                    PublishDate = new DateTime(2000, 01, 01)
                },
                new News()
                {
                    Id = 2,
                    Title = "2",
                    Content = "2",
                    PublishDate = new DateTime(2000, 01, 02)
                },
                new News()
                {
                    Id = 3,
                    Title = "3",
                    Content = "3",
                    PublishDate = new DateTime(2000, 01, 03)
                },
                new News()
                {
                    Id = 4,
                    Title = "4",
                    Content = "4",
                    PublishDate = new DateTime(2000, 01, 04)
                },
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.All()).Returns(fakeNews.AsQueryable());

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetAllNews().ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var news = response.Content
                .ReadAsAsync<IEnumerable<NewsViewModel>>()
                .Result
                .Select(n => n.Title)
                .ToList();
            var orderedFakenews = fakeNews
                .OrderByDescending(n => n.PublishDate)
                .Select(n => n.Title)
                .ToList();
            CollectionAssert.AreEqual(orderedFakenews, news);
        }

        [TestMethod]
        public void TestPostNewNewsWithValidDataShouldAddNewNews()
        {
            // Setup fake news
            var fakeNews = new List<News>();
            var isNewsSaved = false;

            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.Add(It.IsAny<News>()))
                .Callback((News n) =>
                {
                    fakeNews.Add(n);
                });

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);
            mockedContext.Setup(r => r.SaveChanges())
                .Callback(() =>
                {
                    isNewsSaved = true;
                });

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostNewNews(new NewsBindingModel()
            {
                Content = "test",
                Title = "test",
                PublishDate = DateTime.Now
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var news = response.Content
                .ReadAsAsync<NewsViewModel>()
                .Result;

            var orderedFakenews = fakeNews
                .Select(n => n.Title)
                .ToList();
            Assert.AreEqual(orderedFakenews[0], news.Title);
            Assert.IsTrue(isNewsSaved);
        }

        [TestMethod]
        public void TestPostNewNewsWithInValidDataShouldReturnBadRequest()
        {
            var mockedContext = new Mock<INewsData>();
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var response = controller
                .PostNewNews(null)
                .ExecuteAsync(CancellationToken.None)
                .Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestPutUpdateNewsWhenHasNewsWithThatIdShouldEditTheNews()
        {
            // Setup fake news
            var fakeNews = new News()
            {
                Id = 1,
                Content = "NotChanged",
                Title = "NotChanged",
                PublishDate = DateTime.Now
            };

            var isNewsSaved = false;

            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(fakeNews);

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);
            mockedContext.Setup(r => r.SaveChanges())
                .Callback(() =>
                {
                    isNewsSaved = true;
                });

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PutUpdateNews(1, new NewsBindingModel()
            {
                Content = "test",
                Title = "test",
                PublishDate = DateTime.Now
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var news = response.Content
                .ReadAsAsync<NewsViewModel>()
                .Result;

            Assert.AreEqual(fakeNews.Title, news.Title);
            Assert.AreEqual("test", news.Title);
            Assert.IsTrue(isNewsSaved);
        }

        [TestMethod]
        public void TestPutUpdateNewsWhenNewsWithThatIdDontExitShouldReturnBadRequest()
        {
            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns((News)null);

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PutUpdateNews(1, new NewsBindingModel()
            {
                Content = "test",
                Title = "test",
                PublishDate = DateTime.Now
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestPutUpdateNewsWhenNewsDataIsInvalidShouldReturnBadRequest()
        {
            // Setup fake news
            var fakeNews = new News()
            {
                Id = 1,
                Content = "NotChanged",
                Title = "NotChanged",
                PublishDate = DateTime.Now
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(fakeNews);

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PutUpdateNews(1, null)
                .ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("NotChanged", fakeNews.Title);
        }

        [TestMethod]
        public void TestDeleteNewsWithExistingIdShouldDeleteNews()
        {
            // Setup fake news
            var fakeNews = new News()
            {
                Id = 1,
                Content = "NotChanged",
                Title = "NotChanged",
                PublishDate = DateTime.Now
            };

            var isNewsSaved = false;

            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(fakeNews);
            mockedRepository.Setup(r => r.Delete(It.Is<News>(n => n == fakeNews)))
                .Callback(() =>
                {
                    fakeNews = null;
                });

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);
            mockedContext.Setup(r => r.SaveChanges())
                .Callback(() =>
                {
                    isNewsSaved = true;
                });

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.DeleteNews(1)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNull(fakeNews);
            Assert.IsTrue(isNewsSaved);
        }

        [TestMethod]
        public void TestDeleteNewsWithNotExisingIdShouldReturnBadRequest()
        {
            // Setup repositories
            var mockedRepository = new Mock<IRepository<News>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns((News)null);

            // Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.DeleteNews(1)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
