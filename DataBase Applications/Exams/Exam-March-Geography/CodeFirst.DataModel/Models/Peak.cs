namespace CodeFirst.DataModel.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Peak
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Elevation { get; set; }

        [Required]
        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
