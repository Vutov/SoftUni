namespace BookShop.WebServices.Models.ViewModels
{
    using System.Collections.Generic;

    public class AuthorViewModel
    {
        public class AuthorBooksViewModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public IEnumerable<string> BookTitles { get; set; }
        }

        public class AuthorInfoViewModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}