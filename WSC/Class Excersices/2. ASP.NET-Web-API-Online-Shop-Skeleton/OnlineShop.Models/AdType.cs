namespace OnlineShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdType
    {
        private ICollection<Ad> ads;
         
        public AdType()
        {
            this.ads = new HashSet<Ad>();    
        }

        public int Id { get; set; }

        public int Index { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public virtual ICollection<Ad> Ads
        {
            get { return this.ads; }
            set { this.ads = value; }
        }
    }
}
