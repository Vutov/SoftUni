namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Transactions;
    using Data;
    using Data.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class BugTrackerRepositoryTests
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            // Start a new temporary transaction
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            // Rollback the temporary transaction
            tran.Dispose();
        }

        [TestMethod]
        public void AddNewsWhenNewsIsAddedToDbShouldReturnNews()
        {
            // Arrange -> prapare the objects
            var repo = new Repository<News>(new NewsContext());
            var news = new News()
            {
                Id = 1,
                Content = "1",
                Title = "1",
                PublishDate = DateTime.Now
            };

            // Act -> perform some logic
            repo.Add(news);
            repo.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = repo.GetById(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.PublishDate, newsFromDb.PublishDate);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void AddNewsWhenNEwsIsInvalidShouldThrowException()
        {
            // Arrange -> prapare the objects
            var repo = new Repository<News>(new NewsContext());
            var invalidNews = new News() { Content = null };

            // Act -> perform some logic
            repo.Add(invalidNews);
            repo.SaveChanges();

            // Assert -> expect an exception
        }

        [TestMethod]
        public void DeleteNewsWhenExistingItemShouldDelete()
        {
            var repo = new Repository<News>(new NewsContext());
            var news = new News()
            {
                Id = 1,
                Content = "1",
                Title = "1",
                PublishDate = DateTime.Now
            };

            repo.Add(news);
            repo.SaveChanges();
            var newsFromDb = repo.GetById(news.Id);

            repo.Delete(newsFromDb);
            repo.SaveChanges();
            var newNewsFromDb = repo.GetById(news.Id);
            Assert.IsNull(newNewsFromDb);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNewsWhenNotExistingItemShouldDelete()
        {
            var repo = new Repository<News>(new NewsContext());
            var newsFromDb = repo.GetById(155000);
            repo.Delete(newsFromDb);
        }

        [TestMethod]
        public void ModifyNewsWhenExistingItemShouldModify()
        {
            var repo = new Repository<News>(new NewsContext());
            var news = new News()
            {
                Id = 1,
                Content = "1",
                Title = "1",
                PublishDate = DateTime.Now
            };

            repo.Add(news);
            repo.SaveChanges();
            news.Content = "2";
            news.Title = "2";

            repo.Update(news);
            repo.SaveChanges();
            var newsFromDb = repo.GetById(news.Id);
            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual("2", newsFromDb.Title);
            Assert.AreEqual("2", newsFromDb.Content);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        public void ListAllNewsShouldReturnAllNews()
        {
            var repo = new Repository<News>(new NewsContext());
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

            foreach (var news in fakeNews)
            {
                repo.Add(news);
                repo.SaveChanges();
            }

            var fakeNewsTitles = fakeNews
                .Select(n => n.Title)
                .ToList();

            var allNews = repo.All()
                .Select(n => n.Title)
                .ToList();
            CollectionAssert.AreEqual(fakeNewsTitles, allNews);
        }
    }
}