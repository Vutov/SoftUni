namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Book> books;

        public Category()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BookId { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
