using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTracker.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using Models;

    [TestClass]
    public class BugCommentsIntegrationTests
    {
        [TestMethod]
        public void TestGetCommentForBugWhenBugExistAndThereAreCommentsShouldReturnCommentOrderedDescendingByDate()
        {
            // Arrange -> create a new bug with three comments
            TestingEngine.CleanDatabase();

            var bugTitle = "bug title";
            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, null);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);
            Thread.Sleep(2);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);
            Thread.Sleep(2);

            var httpPostResponseThirdComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 3");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseThirdComment.StatusCode);

            // Act -> find all comments for the bug
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check the returned comments
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<List<CommentModel>>().Result;

            Assert.AreEqual(3, commentsFromService.Count());

            Assert.AreEqual("Comment 3", commentsFromService[0].Text);
            Assert.AreEqual(null, commentsFromService[0].Author);
            Assert.IsTrue(commentsFromService[0].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));

            Assert.AreEqual("Comment 2", commentsFromService[1].Text);
            Assert.AreEqual(null, commentsFromService[1].Author);
            Assert.IsTrue(commentsFromService[1].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));

            Assert.AreEqual("Comment 1", commentsFromService[2].Text);
            Assert.AreEqual(null, commentsFromService[2].Author);
            Assert.IsTrue(commentsFromService[2].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));
        }

        [TestMethod]
        public void TestGetCommentForBugWhenBugExistAndThereAreNoCommentsShouldReturnNoComments()
        {
            // Arrange -> create a new bug
            TestingEngine.CleanDatabase();

            var bugTitle = "bug title";
            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, null);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            // Act -> find all comments for the bug
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check the returned comments
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<List<CommentModel>>().Result;

            Assert.AreEqual(0, commentsFromService.Count());
        }

        [TestMethod]
        public void TestGetCommentForBugWhenBugDontExistShouldReturnNotFound()
        {
            // Arrange -> clean database
            TestingEngine.CleanDatabase();

            // Act -> find all comments for the bug
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/1/comments").Result;

            // Assert -> check the returned comments
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }
    }
}
