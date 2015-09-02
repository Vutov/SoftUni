namespace OnlineShop.Tests
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
    using OnlineShop.Models;
    using Owin;
    using Services;

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
           var context = new OnlineShopContext();
            var category = context.Categories.First();
            var typeAd = context.AdTypes.First();

            var data = new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("name", "first"), 
                new KeyValuePair<string, string>("description", "1111"), 
                new KeyValuePair<string, string>("price", "1"), 
                new KeyValuePair<string, string>("typeId", typeAd.Id.ToString()), 
                new KeyValuePair<string, string>("categories[0]", category.Id.ToString()), 
            });

            var response = this.PostNewAd(data);
            if (response.StatusCode != HttpStatusCode.OK )
            {
                Assert.Fail(response.Content.ReadAsStringAsync().Result);
            }
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private static void SeedDatabase()
        {
            var context = new OnlineShopContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = Username,
                Email = "Some@Some.Some"
            };

            var result = userManager.CreateAsync(user, Password).Result;
            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedCategories(context);
            SeedAdTypes(context);
        }

        private static void SeedAdTypes(OnlineShopContext context)
        {
            var adType = new AdType()
            {
                Ads = new List<Ad>(),
                Index = 1,
                Name = "type1",
                PricePerDay = 1
            };

            context.AdTypes.Add(adType);
            context.SaveChanges();
        }

        private static void SeedCategories(OnlineShopContext context)
        {
            var category = new Category()
            {
                Ads = new List<Ad>(),
                Name = "cat1"
            };

            context.Categories.Add(category);
            context.SaveChanges();
        }

        private static void ClearDatabase()
        {
            var context = new OnlineShopContext();
            context.Ads.Delete();
            context.AdTypes.Delete();
            context.Categories.Delete();
            context.Users.Delete();
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

        private HttpResponseMessage PostNewAd(FormUrlEncodedContent data)
        {
            httpClient.DefaultRequestHeaders
                .Add("Authorization", "Bearer " + this.AccessToken);

            return httpClient.PostAsync("/api/Ads", data).Result;
        }
    }
}
