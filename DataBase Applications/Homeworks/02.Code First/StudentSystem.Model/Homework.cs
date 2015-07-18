namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public TypeContent TypeContent { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
