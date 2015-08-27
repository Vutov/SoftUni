namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ad
    {
        private ICollection<Category> categories;

        public Ad()
        {
            this.categories = new HashSet<Category>();
        } 
        
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public DateTime? ClosedOn { get; set; }

        public AdStatus Status { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual AdType Type { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
