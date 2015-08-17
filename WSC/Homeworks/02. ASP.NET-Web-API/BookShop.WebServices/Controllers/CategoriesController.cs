namespace BookShop.WebServices.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Data;
    using System.Linq;
    using System.Web.OData;
    using BookShop.Models;
    using Models;
    using Models.ViewModels;

    public class CategoriesController : ApiController
    {
        public IHttpActionResult GetCategoriesById(int id)
        {
            var context = new BookShopContext();
            var category = context.Categories
                .Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            var viewModel = new CategoryViewModel() { Name = category.Name };
            return this.Ok(viewModel);
        }

        [EnableQuery]
        public IHttpActionResult GetCategories()
        {
            var context = new BookShopContext();
            var categories = context.Categories
                .Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .ToList();

            if (!categories.Any())
            {
                return this.NotFound();
            }

            var viewModels = new List<CategoryViewModel>();
            categories.ForEach(c => viewModels.Add(new CategoryViewModel() { Name = c.Name }));
            return this.Ok(viewModels);
        }

        public IHttpActionResult PostCategory([FromBody] CategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var context = new BookShopContext();

            var duplicate = context.Categories
                .FirstOrDefault(c => c.Name == model.Name);

            if (duplicate != null)
            {
                var message = string.Format("Category with {0} name already exist!", model.Name);
                return this.BadRequest(message);
            }

            var category = new Category { Name = model.Name };
            context.Categories.Add(category);
            context.SaveChanges();

            var viewModel = new CategoryViewModel() { Name = category.Name };
            return this.Ok(viewModel);
        }

        public IHttpActionResult PutCategory([FromUri] int id, [FromBody] CategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var context = new BookShopContext();
            var category = context.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            var duplicate = context.Categories
                .FirstOrDefault(c => c.Name == model.Name);

            if (duplicate != null)
            {
                var message = string.Format("Category with {0} name already exist!", model.Name);
                return this.BadRequest(message);
            }

            category.Name = model.Name;
            context.SaveChanges();

            var viewModel = new CategoryViewModel() { Name = category.Name };
            return this.Ok(viewModel);
        }

        public IHttpActionResult DeleteCategoriesById(int id)
        {
            var context = new BookShopContext();
            var category = context.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return this.Ok();
        }
    }
}
