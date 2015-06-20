using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        private DateTime registrationDate;

        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.RegistrationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required][MaxLength(25, ErrorMessage = "Max length allowed is 25")]
        public string Name { get; set; }

        [MaxLength(15, ErrorMessage = "Max length allowed is 15")]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;

            }
            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
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
    }
}
