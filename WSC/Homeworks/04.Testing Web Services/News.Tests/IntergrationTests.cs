namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using EntityFramework.Extensions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Services;
    using OnlineShop.Tests.Models;
    using Owin;
    using Services.Models.ViewModels;

    [TestClass]
    public class IntegrationalTests
    {
        private const string Username = "testUser";
        private const string Password = "Abc123$";

        private static TestServer httpTestServer;
        private static HttpClient httpClient;
        private string accessToken;

        public string AccessToken
        {
            get
            {
                if (this.accessToken == null)
                {
                    var loginResponse = this.Login();
                    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

                    var loginData = loginResponse.Content.ReadAsAsync<LoginDto>().Result;
                    Assert.IsNotNull(loginData.Access_Token);

                    this.accessToken = loginData.Access_Token;
                }

                return this.accessToken;
            }
        }

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
        public void TestAddAdsWhenDataCorrectShouldAddAds()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "first"), 
                new KeyValuePair<string, string>("content", "1111"), 
                new KeyValuePair<string, string>("PublishDate", DateTime.Now.ToString()), 
            });

            var response = this.PostNews(data);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                Assert.Fail(response.Content.ReadAsStringAsync().Result);
            }

            var createdNews = response.Content.ReadAsAsync<NewsViewModel>().Result;
            Assert.AreEqual("first", createdNews.Title);
            Assert.AreEqual("1111", createdNews.Content);
        }

        [TestMethod]
        public void TestAddAdsWhenDataIsNotCorrectShouldReturnBadRequest()
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "second"), 
                new KeyValuePair<string, string>("PublishDate", DateTime.Now.ToString()), 
            });

            var response = this.PostNews(data);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            var context = new NewsContext();
            var dbNews = context.News.FirstOrDefault(n => n.Title == "second");
            Assert.IsNull(dbNews);
        }

        [TestMethod]
        public void TestDeleteNewsWhenIdIsCorrentShouldDeleteNews()
        {
            var context = new NewsContext();
            var newsId = context.News.First(n => n.Title == "Seed").Id;
            var response = this.DeleteNews(newsId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var dbNews = context.News.FirstOrDefault(n => n.Title == "Seed");
            Assert.IsNull(dbNews);
        }

        [TestMethod]
        public void TestDeleteNewsWhenIdIsInvalidCorrentShouldDeleteNews()
        {
            var context = new NewsContext();
            int id = 150005;
            var dbNews = context.News.FirstOrDefault(n => n.Id == id);
            Assert.IsNull(dbNews);
            var response = this.DeleteNews(id);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestGetAllNewsSouldReturnAllNews()
        {
            var response = this.GetAllNews();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var news = response.Content.ReadAsAsync<IEnumerable<NewsViewModel>>()
                .Result
                .Select(n => n.Title)
                .ToList();
            var context = new NewsContext();
            var dbNews = context.News.Select(NewsViewModel.Create)
                .Select(n => n.Title)
                .ToList();
            CollectionAssert.AreEqual(dbNews, news);
        }

        private static void SeedDatabase()
        {
            var context = new NewsContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = Username,
                Email = Username
            };

            var result = userManager.CreateAsync(user, Password).Result;
            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedNews(context);
        }

        private static void ClearDatabase()
        {
            var context = new NewsContext();
            context.News.Delete();
            context.Users.Delete();
            context.SaveChanges();
        }

        private static void SeedNews(NewsContext context)
        {
            context.News.Add(new News()
            {
                Title = "Seed", 
                Content = "Seed", 
                PublishDate = DateTime.Now
            });
            context.SaveChanges();
        }

        private HttpResponseMessage Login()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", Username), 
                new KeyValuePair<string, string>("password", Password), 
                new KeyValuePair<string, string>("grant_type", "password"), 
            });

            var response = httpClient.PostAsync("/Token", loginData).Result;

            return response;
        }

        private void AddAuthenticationToken()
        {
            if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                httpClient.DefaultRequestHeaders
                    .Add("Authorization", "Bearer " + this.AccessToken);
            }
        }

        private void RemoveAuthenticatioToken()
        {
            if (httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                httpClient.DefaultRequestHeaders
                    .Remove("Authorization");
            }
        }

        private HttpResponseMessage PostNews(FormUrlEncodedContent data)
        {
            this.AddAuthenticationToken();

            return httpClient.PostAsync("/api/news", data).Result;
        }

        private HttpResponseMessage DeleteNews(int id)
        {
            this.AddAuthenticationToken();

            return httpClient.DeleteAsync("/api/news/" + id).Result;
        }

        private HttpResponseMessage GetAllNews()
        {
            this.RemoveAuthenticatioToken();

            return httpClient.GetAsync("/api/news/").Result;
        }
    }
}