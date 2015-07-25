namespace Shop.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual User Buyer { get; set; }

        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
