using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Discipline
    {
        public string Name { get; set; }
        public int NumberOfLectures { get; set; }
        public List<Student> Students { get; set; }
        public string Details { get; set; }

        public Discipline(string name, int numberOfLectures, List<Student> students, string details = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.Students = students;
            this.Details = details;
        }
    }
}
