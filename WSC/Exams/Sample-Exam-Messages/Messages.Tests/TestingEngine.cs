namespace Messages.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;

    using EntityFramework.Extensions;

    using Messages.Data;
    using Messages.Tests.Models;

    using Messages.RestServices;

    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Owin;

    [TestClass]
    public static class TestingEngine
    {
        private static TestServer TestWebServer { get; set; }

        public static HttpClient HttpClient { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Start OWIN testing HTTP server with Web API support
            TestWebServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });
            HttpClient = TestWebServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestWebServer.Dispose();
        }

        public static void CleanDatabase()
        {
            using (var dbContext = new MessagesDbContext())
            {
                dbContext.ChannelMessages.Delete();
                dbContext.UserMessages.Delete();
                dbContext.Users.Delete();
                dbContext.Channels.Delete();
                dbContext.SaveChanges();
            }
        }

        public static int GetChannelsCountFromDb()
        {
            using (var dbContext = new MessagesDbContext())
            {
                return dbContext.Channels.Count();
            }
        }

        public static HttpResponseMessage RegisterUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage LoginUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("recipientUsername", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", postContent).Result;
            return httpResponse;
        }

        public static UserSessionModel RegisterUser(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static UserSessionModel LoginUser(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static HttpResponseMessage CreateChannelHttpPost(string channelName)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", channelName)
            });
            var httpPostResponse = TestingEngine.HttpClient.PostAsync(
                "/api/channels", postContent).Result;
            return httpPostResponse;
        }

        public static HttpResponseMessage SendChannelMessageHttpPost(string channelName, string text)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("text", text)
            });
            var sendMsgUrl = "/api/channel-messages/" + WebUtility.UrlEncode(channelName);
            var httpPostResponse = TestingEngine.HttpClient.PostAsync(sendMsgUrl, postContent).Result;
            return httpPostResponse;
        }

        public static HttpResponseMessage SendChannelMessageFromUserHttpPost(
            string channelName, string text, string userSessionToken)
        {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(
                "/api/channel-messages/" + WebUtility.UrlEncode(channelName),
                UriKind.Relative);
            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", userSessionToken);
            httpRequest.Content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("text", text)
            });
            var httpResponse = TestingEngine.HttpClient.SendAsync(httpRequest).Result;
            return httpResponse;
        }

        public static HttpResponseMessage SendPersonalMessageHttpPost(
            string recipientUsername, string messageText)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("recipient", recipientUsername),
                new KeyValuePair<string, string>("text", messageText)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync(
                "/api/user/personal-messages", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage GetPersonalMessagesForUserHttpGet(string userSessionToken)
        {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri("/api/user/personal-messages", UriKind.Relative);
            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", userSessionToken);
            var httpResponse = TestingEngine.HttpClient.SendAsync(httpRequest).Result;
            return httpResponse;
        }

        public static HttpResponseMessage SendPersonalMessageHttpPost(
           string senderUserSessionToken, string recipientUsername, string messageText)
        {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri("/api/user/personal-messages", UriKind.Relative);
            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", senderUserSessionToken);
            httpRequest.Content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("recipient", recipientUsername),
                new KeyValuePair<string, string>("text", messageText)
            });
            var httpResponse = TestingEngine.HttpClient.SendAsync(httpRequest).Result;
            return httpResponse;
        }
    }
}
