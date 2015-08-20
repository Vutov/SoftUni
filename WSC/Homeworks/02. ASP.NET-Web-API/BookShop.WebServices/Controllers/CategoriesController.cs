namespace BookShop.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using BookShop.Models;
    using Data;
    using Models;
    using Models.ViewModels;

    public class CategoriesController : BaseController
    {
        public IHttpActionResult GetCategoriesById(int id)
        {
            var category = this.Data.Categories.Find(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            var viewModel = category.Select(CategoryViewModel.Create).First();
            return this.Ok(viewModel);
        }

        [EnableQuery]
        public IHttpActionResult GetCategories()
        {
            var categories = this.Data.Categories.All();

            if (!categories.Any())
            {
                return this.NotFound();
            }

            var viewModels = categories.Select(CategoryViewModel.Create);
            return this.Ok(viewModels);
        }

        [Authorize]
        public IHttpActionResult PostCategory([FromBody] CategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var duplicate = this.Data.Categories.Find(c => c.Name == model.Name);

            if (duplicate != null)
            {
                var message = string.Format("Category with {0} name already exist!", model.Name);
                return this.BadRequest(message);
            }

            var category = new Category { Name = model.Name };
            this.Data.Categories.Add(category);
            this.Data.SaveChanges();

            var viewModel = new CategoryViewModel() { Name = category.Name };
            return this.Ok(viewModel);
        }

        [Authorize]
        public IHttpActionResult PutCategory([FromUri] int id, [FromBody] CategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = this.Data.Categories.GetById(id);

            if (category == null)
            {
                return this.NotFound();
            }

            var duplicate = this.Data.Categories.Find(c => c.Name == model.Name);

            if (duplicate != null)
            {
                var message = string.Format("Category with {0} name already exist!", model.Name);
                return this.BadRequest(message);
            }

            category.Name = model.Name;
            this.Data.SaveChanges();

            var viewModel = new CategoryViewModel() { Name = category.Name };
            return this.Ok(viewModel);
        }

        [Authorize]
        public IHttpActionResult DeleteCategoriesById(int id)
        {
            var category = this.Data.Categories.GetById(id);

            if (category == null)
            {
                return this.NotFound();
            }

            this.Data.Categories.Delete(category);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
