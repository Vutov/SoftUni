namespace Messages.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using Messages.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChannelMessagesTests
    {
        [TestMethod]
        public void ListChannelMessages_ExistingChannel_ShouldReturn200OK_SortedMessagesByDate()
        {
            // Arrange -> create a chennel and send a few messages to it
            TestingEngine.CleanDatabase();
            
            // Create a channel
            var channelName = "channel" + DateTime.Now.Ticks;
            var httpResponseCreateChannel = TestingEngine.CreateChannelHttpPost(channelName);
            Assert.AreEqual(HttpStatusCode.Created, httpResponseCreateChannel.StatusCode);

            // Send a few messages to the channel
            string firstMsg = "First message";
            var httpResponseFirstMsg = TestingEngine.SendChannelMessageHttpPost(channelName, firstMsg);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseFirstMsg.StatusCode);
            Thread.Sleep(2);

            string secondMsg = "Second message";
            var httpResponseSecondMsg = TestingEngine.SendChannelMessageHttpPost(channelName, secondMsg);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseSecondMsg.StatusCode);
            Thread.Sleep(2);

            string thirdMsg = "Third message";
            var httpResponseThirdMsg = TestingEngine.SendChannelMessageHttpPost(channelName, thirdMsg);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseThirdMsg.StatusCode);

            // Act -> list the channel messages
            var urlMessages = "/api/channel-messages/" + WebUtility.UrlEncode(channelName);
            var httpResponseMessages = TestingEngine.HttpClient.GetAsync(urlMessages).Result;

            // Assert -> messages are returned correcty, ordered from the last to the first
            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessages.StatusCode);
            var messages = httpResponseMessages.Content.ReadAsAsync<List<MessageModel>>().Result;
            Assert.AreEqual(3, messages.Count);

            // Check the first message
            Assert.IsTrue(messages[2].Id > 0);
            Assert.AreEqual(firstMsg, messages[2].Text);
            Assert.IsTrue((DateTime.Now - messages[2].DateSent) < TimeSpan.FromMinutes(1));
            Assert.IsNull(messages[2].Sender);

            // Check the second message
            Assert.IsTrue(messages[1].Id > 0);
            Assert.AreEqual(secondMsg, messages[1].Text);
            Assert.IsTrue((DateTime.Now - messages[1].DateSent) < TimeSpan.FromMinutes(1));
            Assert.IsNull(messages[1].Sender);

            // Check the third message
            Assert.IsTrue(messages[0].Id > 0);
            Assert.AreEqual(thirdMsg, messages[0].Text);
            Assert.IsTrue((DateTime.Now - messages[0].DateSent) < TimeSpan.FromMinutes(1));
            Assert.IsNull(messages[0].Sender);
        }

        [TestMethod]
        public void SendChannelMessage_FromExisitingUser_ShouldListMessagesCorectly()
        {
            // Arrange -> create a channel
            TestingEngine.CleanDatabase();
            var channelName = "channel" + DateTime.Now.Ticks;
            var httpResponseCreateChannel = TestingEngine.CreateChannelHttpPost(channelName);
            Assert.AreEqual(HttpStatusCode.Created, httpResponseCreateChannel.StatusCode);

            // Arrange -> register two users
            var userSessionPeter = TestingEngine.RegisterUser("peter", "pAssW@rd#123456");
            var userSessionMaria = TestingEngine.RegisterUser("maria", "SECret#76^%asf!");

            // Act -> send a few messages to the channel (from the registered users and anonymous)
            string firstMsg = "A message from Peter";
            var httpResponseFirstMsg = TestingEngine.SendChannelMessageFromUserHttpPost(
                channelName, firstMsg, userSessionPeter.Access_Token);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseFirstMsg.StatusCode);
            Thread.Sleep(2);

            string secondMsg = "Anonymous message";
            var httpResponseThirdMsg = TestingEngine.SendChannelMessageHttpPost(channelName, secondMsg);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseThirdMsg.StatusCode);
            Thread.Sleep(2);

            string thirdMsg = "A message from Maria";
            var httpResponseSecondMsg = TestingEngine.SendChannelMessageFromUserHttpPost(
                channelName, thirdMsg, userSessionMaria.Access_Token);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseSecondMsg.StatusCode);

            // Act -> list the channel messages
            var urlMessages = "/api/channel-messages/" + WebUtility.UrlEncode(channelName);
            var httpResponseMessages = TestingEngine.HttpClient.GetAsync(urlMessages).Result;

            // Assert -> messages are returned correcty, ordered from the last to the first
            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessages.StatusCode);
            var messages = httpResponseMessages.Content.ReadAsAsync<List<MessageModel>>().Result;
            Assert.AreEqual(3, messages.Count);

            // Check the first message
            Assert.IsTrue(messages[2].Id > 0);
            Assert.AreEqual(firstMsg, messages[2].Text);
            Assert.IsTrue((DateTime.Now - messages[2].DateSent) < TimeSpan.FromMinutes(1));
            Assert.AreEqual("peter", messages[2].Sender);

            // Check the second message
            Assert.IsTrue(messages[1].Id > 0);
            Assert.AreEqual(secondMsg, messages[1].Text);
            Assert.IsTrue((DateTime.Now - messages[1].DateSent) < TimeSpan.FromMinutes(1));
            Assert.IsNull(messages[1].Sender);

            // Check the third message
            Assert.IsTrue(messages[0].Id > 0);
            Assert.AreEqual(thirdMsg, messages[0].Text);
            Assert.IsTrue((DateTime.Now - messages[0].DateSent) < TimeSpan.FromMinutes(1));
            Assert.AreEqual("maria", messages[0].Sender);
        }
    }
}
