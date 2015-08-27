namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.Binding;
    using Models.View;
    using OnlineShop.Models;

    public class AdsController : BaseController
    {
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.Select(AdViewModel.Create)
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

            var dbType = this.Data.AdTypes.FirstOrDefault(c => c.Id == model.TypeId);
            if (dbType == null)
            {
                return this.BadRequest("No type with id " + model.TypeId + " found!");
            }

            var categories = new List<Category>();
            foreach (var categoryId in model.Categories)
            {
                var dbCategory = this.Data.Categories.FirstOrDefault(c => c.Id == categoryId);
                if (dbCategory == null)
                {
                    return this.BadRequest("No category with id " + model.TypeId + " found!");
                }

                categories.Add(dbCategory);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.FirstOrDefault(u => u.Id == userId);
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

            var dbAd = this.Data.Ads
                .Where(a => a.Id == newAd.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(dbAd);
        }
    }
}
