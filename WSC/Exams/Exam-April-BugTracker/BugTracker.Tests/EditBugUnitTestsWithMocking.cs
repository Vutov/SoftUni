using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTracker.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data.DataLayer;
    using Data.Models;
    using Data.Repositories;
    using Moq;
    using RestServices.Controllers;
    using RestServices.Models.BindingModels;
    using RestServices.Models.ViewModels;

    [TestClass]
    public class EditBugUnitTestsWithMocking
    {
        private BugsController controller;
        private Bug fakeBug;

        [TestInitialize]
        public void InitTestInitialize()
        {
            // Setup fake bug
            this.fakeBug = new Bug()
            {
                Id = 1,
                Title = "not changed",
                Description = "not changed",
                DateCreated = DateTime.Now,
                Comments = new List<Comment>(),
                Author = null,
                Status = Status.Open
            };

            // Setup repositories
            var mockedRepository = new Mock<IRepository<Bug>>();
            mockedRepository.Setup(r => r.GetById(It.Is<int>(i => i == 1))).Returns(this.fakeBug);

            // Setup data layer
            var mockedContext = new Mock<IBugTrackerData>();
            mockedContext.Setup(c => c.Bugs).Returns(mockedRepository.Object);

            // Setup controller
            this.controller = new BugsController(mockedContext.Object);
            this.controller.Request = new HttpRequestMessage();
            this.controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void TestPatchExistingBugWhenGivenValidTitleShouldReturnOk200AndEditOnlyTitle()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Title = "changed"
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var bugMessage = response.Content
                .ReadAsAsync<MessageViewModel>()
                .Result;
            Assert.AreEqual("Bug #1 patched.", bugMessage.Message);
            Assert.AreEqual("changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenGivenValidDescriptionShouldReturnOk200AndEditOnlyDescription()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Description = "changed"
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var bugMessage = response.Content
                .ReadAsAsync<MessageViewModel>()
                .Result;
            Assert.AreEqual("Bug #1 patched.", bugMessage.Message);
            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenGivenValidStatusShouldReturnOk200AndEditOnlyStatus()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Status = "Fixed"
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var bugMessage = response.Content
                .ReadAsAsync<MessageViewModel>()
                .Result;
            Assert.AreEqual("Bug #1 patched.", bugMessage.Message);
            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Fixed", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenAllGivenDataIsValidShouldReturnOk200AndEditAll()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Title = "changed",
                Description = "changed",
                Status = "Fixed"
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var bugMessage = response.Content
                .ReadAsAsync<MessageViewModel>()
                .Result;
            Assert.AreEqual("Bug #1 patched.", bugMessage.Message);
            Assert.AreEqual("changed", this.fakeBug.Title);
            Assert.AreEqual("changed", this.fakeBug.Description);
            Assert.AreEqual("Fixed", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenInvalidBugIdShouldReturnNotFoundAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(2, new EditBugBindingModel()
            {
                Title = "changed",
                Description = "changed",
                Status = "Fixed"
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenTitleIsInvalidShouldReturnBadRequestAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Title = "",
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());

            response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Title = null,
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenDescriptionIsInvalidShouldReturnBadRequestAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Description = "",
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());

            response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Description = null,
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenStatusIsEmptyShouldReturnBadRequestAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Status  = "",
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());

            response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Status = null,
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenStatusIsInvalidShouldReturnBadRequestAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(1, new EditBugBindingModel()
            {
                Status = "InvalidStatus",
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }

        [TestMethod]
        public void TestPatchExistingBugWhenGivenInformationIsNullShouldReturnBadRequestAndNotEditBugs()
        {
            var response = this.controller.PatchExistingBug(1, null).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.AreEqual("not changed", this.fakeBug.Title);
            Assert.AreEqual("not changed", this.fakeBug.Description);
            Assert.AreEqual("Open", this.fakeBug.Status.ToString());
        }
    }
}