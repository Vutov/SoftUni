namespace StudentSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class CourseLicense
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
