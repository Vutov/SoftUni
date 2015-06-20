using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public Student StudentId { get; set; }

        public Course CourseId { get; set; }
    }
}
