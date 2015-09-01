namespace Messages.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    using Messages.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChannelTests
    {
        [TestMethod]
        public void CreateChannels_ListChannels_ShouldListCreatedChannelsAlphabetically()
        {
            // Arrange -> prepare a few channels
            TestingEngine.CleanDatabase();
            var channelsToAdds = new string[]
            {  
                "Channel Omega" + DateTime.Now.Ticks,
                "Channel Alpha" + DateTime.Now.Ticks,
                "Channel Zeta" + DateTime.Now.Ticks,
                "Channel X" + DateTime.Now.Ticks,
                "Channel Psy" + DateTime.Now.Ticks
            };

            // Act -> create a few channels
            foreach (var channelName in channelsToAdds)
            {
                var httpPostResponse = this.CreateChannelHttpPost(channelName);
                
                // Assert -> ensure each channel is successfully created
                Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            }

            // Assert -> list the channels and assert their count, order and content are correct
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/channels").Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var channelsFromService = httpResponse.Content.ReadAsAsync<List<ChannelModel>>().Result;
            Assert.AreEqual(channelsToAdds.Count(), channelsFromService.Count);

            var sortedChannels = channelsToAdds.OrderBy(c => c).ToList();
            for (int i = 0; i < sortedChannels.Count; i++)
            {
                Assert.IsTrue(channelsFromService[i].Id != 0);
                Assert.AreEqual(sortedChannels[i], channelsFromService[i].Name);
            }
        }

        [TestMethod]
        public void GetChannelById_ExistingChannel_ShouldReturnTheChannel()
        {
            // Arrange -> create a new channel
            var channelName = "channel" + DateTime.Now.Ticks;
            var httpPostResponse = this.CreateChannelHttpPost(channelName);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var postedChannel = httpPostResponse.Content.ReadAsAsync<ChannelModel>().Result;

            // Act -> find the channel by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/channels/" + postedChannel.Id).Result;

            // Assert -> the channel by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var channelFromService = httpResponse.Content.ReadAsAsync<ChannelModel>().Result;
            Assert.IsTrue(channelFromService.Id != 0);
            Assert.AreEqual(channelFromService.Name, channelName);
        }

        [TestMethod]
        public void EditExistingChannel_ShouldReturn200OK_Modify()
        {
            // Arrange -> create a new channel
            TestingEngine.CleanDatabase();
            var channelName = "channel" + DateTime.Now.Ticks;
            var httpPostResponse = this.CreateChannelHttpPost(channelName);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var postedChannel = httpPostResponse.Content.ReadAsAsync<ChannelModel>().Result;

            // Act -> edit the above created channel
            var channelNewName = "Edited " + channelName;
            var httpPutResponse = this.EditChannelHttpPut(postedChannel.Id, channelNewName);

            // Assert -> the PUT result is 200 OK
            Assert.AreEqual(HttpStatusCode.OK, httpPutResponse.StatusCode);

            // Assert the service holds the modified channel
            var httpGetResponse = TestingEngine.HttpClient.GetAsync("/api/channels").Result;
            var channelsFromService = httpGetResponse.Content.ReadAsAsync<List<ChannelModel>>().Result;
            Assert.AreEqual(HttpStatusCode.OK, httpGetResponse.StatusCode);
            Assert.AreEqual(1, channelsFromService.Count);
            Assert.AreEqual(postedChannel.Id, channelsFromService.First().Id);
            Assert.AreEqual(channelNewName, channelsFromService.First().Name);
        }


        [TestMethod]
        public void DeleteExistingChannel_ShouldReturn200OK()
        {
            // Arrange -> create a channel
            TestingEngine.CleanDatabase();

            var channelName = "channel" + DateTime.Now.Ticks;
            var httpPostResponse = this.CreateChannelHttpPost(channelName);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var channel = httpPostResponse.Content.ReadAsAsync<ChannelModel>().Result;
            Assert.AreEqual(1, TestingEngine.GetChannelsCountFromDb());

            // Act -> delete the channel
            var httpDeleteResponse = TestingEngine.HttpClient.DeleteAsync(
                "/api/channels/" + channel.Id).Result;

            // Assert -> HTTP status code is 200 (OK)
            Assert.AreEqual(HttpStatusCode.OK, httpDeleteResponse.StatusCode);
            Assert.AreEqual(0, TestingEngine.GetChannelsCountFromDb());
        }

        private HttpResponseMessage CreateChannelHttpPost(string channelName)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", channelName)
            });
            var httpPostResponse = TestingEngine.HttpClient.PostAsync(
                "/api/channels", postContent).Result;
            return httpPostResponse;
        }

        private HttpResponseMessage EditChannelHttpPut(int id, string channelName)
        {
            var putContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", channelName)
            });
            var httpPutResponse = TestingEngine.HttpClient.PutAsync(
                "/api/channels/" + id, putContent).Result;
            return httpPutResponse;
        }

    }
}
