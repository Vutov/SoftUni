namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Category> categories;
 
        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Decription { get; set; }

        public EditionType EditionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public AgeRestriction AgeRestriction { get; set; }

    }
}
