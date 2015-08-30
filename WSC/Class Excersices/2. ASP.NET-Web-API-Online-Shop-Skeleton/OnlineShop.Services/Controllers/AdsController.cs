namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data.Data;
    using Microsoft.AspNet.Identity;
    using Models.Binding;
    using Models.View;
    using OnlineShop.Models;

    public class AdsController : BaseController
    {
        public AdsController(IOnlineShopData onlineShopData)
            : base(onlineShopData)
        {
        }

        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.All()
                .Where(a => a.ClosedOn == null)
                .Select(AdViewModel.Create)
                .ToList()
                .OrderBy(a => a.Type)
                .ThenBy(a => a.PostDateTime);

            return this.Ok(ads);
        }

        [Authorize]
        public IHttpActionResult PutCreateAd(CreateAdBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be empty!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!model.Categories.Any() || model.Categories.Count() > 3)
            {
                return this.BadRequest("Categories count cannot be " + model.Categories.Count());
            }

            var dbType = this.Data.AdTypes.All().FirstOrDefault(c => c.Id == model.TypeId);
            if (dbType == null)
            {
                return this.BadRequest("No type with id " + model.TypeId + " found!");
            }

            var categories = new List<Category>();
            foreach (var categoryId in model.Categories)
            {
                var dbCategory = this.Data.Categories.All().FirstOrDefault(c => c.Id == categoryId);
                if (dbCategory == null)
                {
                    return this.BadRequest("No category with id " + model.TypeId + " found!");
                }

                categories.Add(dbCategory);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
            var newAd = new Ad()
            {
                Categories = categories,
                PostedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                Owner = user,
                Price = model.Price,
                Type = dbType
            };

            this.Data.Ads.Add(newAd);
            this.Data.SaveChanges();

            var dbAd = this.Data.Ads.All()
                .Where(a => a.Id == newAd.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(dbAd);
        }

        [Authorize]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult PutCloseAd(int id)
        {
            var ad = this.Data.Ads.All().FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return this.BadRequest("No ad with id " + id);
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (ad.OwnerId != loggedUserId)
            {
                return this.BadRequest("You are not the owner of the ad");
            }

            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();
            return this.Ok();
        }
    }
}
