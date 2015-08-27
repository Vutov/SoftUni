namespace OnlineShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Ad> ads;

        public Category()
        {
            this.ads = new HashSet<Ad>();
        } 

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads
        {
            get { return this.ads; }
            set { this.ads = value; }
        } 
    }
}
