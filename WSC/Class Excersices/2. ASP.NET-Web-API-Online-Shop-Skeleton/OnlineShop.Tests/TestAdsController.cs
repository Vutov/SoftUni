using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnlineShop.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data;
    using Data.Data;
    using Data.Repositories;
    using Mocked;
    using Models;
    using Moq;
    using Services.Controllers;
    using Services.Models.View;

    [TestClass]
    public class TestAdsController
    {
        private MockContainer mock;

        [TestInitialize]
        public void Init()
        {
            this.mock = new MockContainer();
            this.mock.PrepareMocks();
        }

        [TestMethod]
        public void TestGetAdsShouldReturnAllAdsSortedByType()
        {
            var mockedContext = new Mock<IOnlineShopData>();
            mockedContext.Setup(c => c.Ads).Returns(this.mock.AdRepositoryMock.Object);
            var adsController = new AdsController(mockedContext.Object);

            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
            var response = adsController.GetAds().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseAds = response.Content
                .ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result
                .Select(a => a.Id)
                .ToList();
            var fakeAds = this.mock.AdRepositoryMock.Object.All()
                .Select(AdViewModel.Create)
                .OrderBy(a => a.Type)
                .ThenBy(a => a.PostDateTime)
                .Select(a => a.Id)
                .ToList();
            CollectionAssert.AreEqual(fakeAds, responseAds);
        }
    }
}
