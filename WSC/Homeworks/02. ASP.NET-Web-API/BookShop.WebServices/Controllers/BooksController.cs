namespace BookShop.WebServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using BookShop.Models;
    using Data;
    using Models;
    using Models.ViewModels;

    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        public IHttpActionResult GetBookById(int id)
        {
            var context = new BookShopContext();
            var book = context.Books
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    b.AgeRestriction,
                    b.Copies,
                    b.EditionType,
                    b.Decription,
                    b.Price,
                    b.ReleaseDate,
                    Categories = b.Categories.Select(c => c.Name)
                })
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            return this.Ok(book);
        }

        [EnableQuery]
        public IHttpActionResult GetBookBySearchWord([FromUri] BookSearchBindingModel searchWord)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid search parameters");
            }

            var context = new BookShopContext();
            var books = context.Books
                .Where(b => b.Title.Contains(searchWord.Search) ||
                            b.Decription.Contains(searchWord.Search) ||
                            b.EditionType.ToString() == searchWord.Search ||
                            b.Categories.Select(c => c.Name).Any(c => c == searchWord.Search) ||
                            b.Author.FirstName == searchWord.Search ||
                            b.Author.LastName == searchWord.Search)
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    b.AgeRestriction,
                    b.Copies,
                    b.EditionType,
                    b.Decription,
                    b.Price,
                    b.ReleaseDate,
                    Categories = b.Categories.Select(c => c.Name)
                })
                .Take(10)
                .ToList();

            if (!books.Any())
            {
                return this.NotFound();
            }

            return this.Ok(books);
        }

        [Authorize]
        public IHttpActionResult DeleteBookById(int id)
        {
            var context = new BookShopContext();
            var book = context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            context.Books.Remove(book);
            context.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        public IHttpActionResult PostBook([FromBody] BookPostBindingModel bookPost)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var context = new BookShopContext();
            var categories = bookPost.Categories.Split(' ').Select(c => c.Trim()).ToList();
            var categoryList = new List<Category>();
            categories.ForEach(c =>
            {
                var categoryDb = context.Categories.FirstOrDefault(ca => ca.Name == c);
                if (categoryDb == null)
                {
                    categoryList.Add(new Category() { Name = c });
                }
                else
                {
                    categoryList.Add(categoryDb);
                }
            });

            var newBook = new Book()
            {
                Title = bookPost.Title,
                Decription = bookPost.Decription,
                Price = bookPost.Price,
                Copies = bookPost.Copies,
                EditionType = bookPost.EditionType,
                AgeRestriction = bookPost.AgeRestriction,
                ReleaseDate = bookPost.ReleaseDate,
                Categories = categoryList,
                AuthorId = 1
            };

            context.Books.Add(newBook);
            context.SaveChanges();

            return this.Ok(bookPost);
        }

        [Authorize]
        public IHttpActionResult PutBook([FromUri] int id, [FromBody] BookPutBindingModel bookModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var context = new BookShopContext();
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            book.Title = bookModel.Title;
            book.Decription = bookModel.Decription;
            book.Price = bookModel.Price;
            book.Copies = bookModel.Copies;
            book.EditionType = bookModel.EditionType;
            book.AgeRestriction = bookModel.AgeRestriction;
            book.ReleaseDate = bookModel.ReleaseDate;
            book.AuthorId = bookModel.AuthorId;

            context.SaveChanges();

            return this.Ok(bookModel);
        }

        [Authorize]
        [Route("Buy/{id}")]
        public IHttpActionResult PutBuyBook(int id)
        {
            var context = new BookShopContext();
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            if (book.Copies <= 0)
            {
                return this.BadRequest("No copies left");
            }

            book.Copies--;

            var purchase = new Purchase()
            {
                Book = book,
                ApplicationUser = context.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name),
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false
            };

            context.Purchases.Add(purchase);
            context.SaveChanges();

            var purchaseView = new PurchaseViewModel()
            {
                BookName = book.Title,
                Price = book.Price,
                User = purchase.ApplicationUser.UserName
            };
            return this.Ok(purchaseView);
        }

        [Authorize]
        [Route("Recall/{id}")]
        public IHttpActionResult PutRecallBook(int id)
        {
            var context = new BookShopContext();
            var purchase = context.Purchases.FirstOrDefault(p => p.Id == id);
            if (purchase == null)
            {
                return this.NotFound();
            }

            if (purchase.ApplicationUser.UserName != this.User.Identity.Name)
            {
                return this.BadRequest("You cannot return this purchase, you are not the buyer!");
            }

            purchase.IsRecalled = true;
            purchase.Book.Copies++;
            context.SaveChanges();

            return this.Ok("Refunded!");
        }
    }
}
