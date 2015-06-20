using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Course
    {
        private ICollection<Resourse> resourses;
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Resourses = new HashSet<Resourse>();
            this.SubmitedHomeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required][MaxLength (25, ErrorMessage = "Max length allowed is 25")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;

            }
            set
            {
                this.students = value;
            }
        }
        public virtual ICollection<Homework> SubmitedHomeworks
        {
            get
            {
                return this.homeworks;

            }
            set
            {
                this.homeworks = value;
            }
        }
        public virtual ICollection<Resourse> Resourses
        {
            get
            {
                return this.resourses;

            }
            set
            {
                this.resourses = value;
            }
        }
    }
}
