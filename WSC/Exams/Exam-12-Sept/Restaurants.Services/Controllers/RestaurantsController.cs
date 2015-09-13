namespace Restaurants.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data.DataLayer;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Restaurants.Models;

    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : BaseController
    {
        public RestaurantsController():base()
        {
            
        }

        public RestaurantsController(IRestaurantData data, IUserIdProvider provider): base(data, provider)
        {
            
        }

        [Route("")]
        public IHttpActionResult GetRestaurantsByTown(int townId)
        {
            var restourants = this.Data.Towns.GetById(townId);
            if (restourants == null)
            {
                return this.Ok(new List<RestaurantViewModel>());
            }

            var viewModel = restourants.Restaurants.AsQueryable()
                .Select(RestaurantViewModel.Create)
                .OrderByDescending(r => r.Rating)
                .ThenBy(r => r.Name);
            return this.Ok(viewModel);
        }

        [Route("")]
        [Authorize]
        public IHttpActionResult PostNewRestaurant([FromBody] CreateRestaurantBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Data.Towns.GetById(model.TownId);
            if (town == null)
            {
                return this.BadRequest("Town with id " + model.TownId + " does not exit!");
            }

            var ownerId = this.UserIdProvider.GetUserId();
            var owner = this.Data.ApplicationUsers.GetById(ownerId);
            var restaurant = new Restaurant()
            {
                Name = model.Name,
                Owner = owner,
                Meals = new List<Meal>(),
                Ratings = new List<Rating>(),
            };

            town.Restaurants.Add(restaurant);
            this.Data.SaveChanges();

            var viewModel = new RestaurantViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Rating = null,
                Town = new TownViewModel()
                {
                    Id = town.Id,
                    Name = town.Name
                }
            };

            return this.Created("http://localhost:1337/api/restaurants/" + town.Id, viewModel);
        }

        [Route("{id}/rate")]
        public IHttpActionResult PostRateExistingRestaurant([FromUri] int id, [FromBody] RatingBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.GetById(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var userId = this.UserIdProvider.GetUserId();
            if (restaurant.OwnerId == userId)
            {
                return this.BadRequest("Cannot rate your own restaurant!");
            }

            if (restaurant.Ratings.Any(r => r.UserId == userId))
            {
                var currentRating = restaurant.Ratings.First(r => r.UserId == userId);
                currentRating.Stars = model.Stars;
                this.Data.SaveChanges();
                return this.Ok();
            }

            var user = this.Data.ApplicationUsers.GetById(userId);
            var rating = new Rating()
            {
                Stars = model.Stars,
                User = user
            };

            restaurant.Ratings.Add(rating);
            this.Data.SaveChanges();
            return this.Ok();
        }

        [Route("{id}/meals")]
        public IHttpActionResult GetRestaurantMeals([FromUri] int id)
        {
            var restaurant = this.Data.Restaurants.GetById(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var viewModel = restaurant.Meals.AsQueryable()
                .Select(MealViewModel.Create)
                .OrderBy(m => m.Type)
                .ThenBy(m => m.Name);

            return this.Ok(viewModel);
        }
    }
}
