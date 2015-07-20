namespace CodeFirst.DataModel.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Mountain
    {
        private ICollection<Country> countries;
        private ICollection<Peak> peaks;
 
        public Mountain()
        {
            this.countries = new HashSet<Country>();
            this.peaks = new HashSet<Peak>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get { return this.countries; }
            set { this.countries = value; }
        }

        public virtual ICollection<Peak> Peaks
        {
            get { return this.peaks; }
            set { this.peaks = value; }
        }
    }
}
