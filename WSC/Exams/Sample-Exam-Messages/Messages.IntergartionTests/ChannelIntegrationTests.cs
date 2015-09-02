namespace Messages.IntergartionTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using Data.Models;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using RestServices;

    [TestClass]
    public class ChannelIntegrationTests
    {
        private static TestServer httpTestServer;
        private static HttpClient httpClient;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ClearDatabase();

            httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var startup = new Startup();

                startup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });

            httpClient = httpTestServer.HttpClient;

            SeedDatabase();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (httpTestServer != null)
            {
                httpTestServer.Dispose();
            }

            ClearDatabase();
        }

        [TestMethod]
        public void TestDeleteChannelByIdWhenChannelIdIsValidAndHasNoMessagesShouldReturnOkAndDeleteChannel()
        {
            var context = new MessagesDbContext();
            var channelId = context.Channels.First(c => c.Name == "EmptyChannel").Id;
            var response = this.DeleteChannelById(channelId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var dbChannel = context.Channels.FirstOrDefault(c => c.Id == channelId);
            Assert.IsNull(dbChannel);
        }

        [TestMethod]
        public void TestDeleteChannelByIdWhenChannelIdIsInvalidShouldReturnNotFound()
        {
            var invalidId = 10000;
            var context = new MessagesDbContext();
            var dbChannel = context.Channels.FirstOrDefault(c => c.Id == invalidId);
            Assert.IsNull(dbChannel);

            var response = this.DeleteChannelById(invalidId);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void TestDeleteChannelByIdWhenChannelIdIsValidAndHasMessagesShouldReturnConflict()
        {
            var context = new MessagesDbContext();
            var channelId = context.Channels.First(c => c.Name == "ChannelWithMessages").Id;
            var response = this.DeleteChannelById(channelId);
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);

            var dbChannel = context.Channels.FirstOrDefault(c => c.Id == channelId);
            Assert.IsNotNull(dbChannel);
        }


        private static void SeedDatabase()
        {
            var context = new MessagesDbContext();
            SeedChannels(context);
        }

        private static void ClearDatabase()
        {
            var context = new MessagesDbContext();
            context.Channels.Delete();
            context.SaveChanges();
        }

        private static void SeedChannels(MessagesDbContext context)
        {
            context.Channels.Add(new Channel()
            {
                Name = "EmptyChannel",
                ChannelMessages = new List<ChannelMessage>()
            });
            context.Channels.Add(new Channel()
            {
                Name = "ChannelWithMessages",
                ChannelMessages = new List<ChannelMessage>()
                {
                    new ChannelMessage()
                    {
                        Text = "seedSeed",
                        DateSent = DateTime.Now,
                        Sender = null
                    }
                }
            });

            context.SaveChanges();
        }

        private HttpResponseMessage DeleteChannelById(int id)
        {
            return httpClient.DeleteAsync("api/channels/" + id).Result;
        }
    }
}