using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Resourse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ResourseType Type { get; set; }

        [Required]
        public string Link { get; set; }

        public Course CourseId { get; set; }
    }
}
