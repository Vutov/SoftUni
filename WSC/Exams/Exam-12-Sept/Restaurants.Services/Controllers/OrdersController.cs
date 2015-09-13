namespace Restaurants.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Restaurants.Models;

    [RoutePrefix("api")]
    public class OrdersController : BaseController
    {
        [Authorize]
        [Route("meals/{id}/order")]
        public IHttpActionResult PostNewOrder([FromUri]int id, [FromBody] NewOrderBindingModel model)
        {
            var meal = this.Data.Meals.GetById(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.ApplicationUsers.GetById(userId);

            var order = new Order()
            {
                Meal = meal,
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Pending, //?,
                Quantity = model.Quantity,
                User = user
            };
            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        [Route("orders")]
        public IHttpActionResult GetViewPendingOrders(
            [FromUri] int startPage,
            [FromUri] int limit,
            [FromUri] int? mealId = null)
        {
            var userId = this.User.Identity.GetUserId();
            var orders = this.Data.Orders.All()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending);
            if (mealId != null)
            {
                orders = orders.Where(o => o.MealId == mealId);
            }

            if (startPage < 0 || limit < 0)
            {
                return this.BadRequest();
            }

            orders = orders.OrderByDescending(o => o.CreatedOn);
            var viewModel = orders
                .Skip(startPage * limit)
                .Take(limit)
                .Select(OrdersViewModel.Create);
            return this.Ok(viewModel);
        }
    }
}