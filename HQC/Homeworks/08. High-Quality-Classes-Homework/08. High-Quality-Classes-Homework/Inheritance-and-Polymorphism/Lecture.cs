namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public class Lecture
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }
        public string Place { get; set; }

        public Lecture(string courseName, string teacherName = null,
            IList<string> students = null, string place = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Place = place;
        }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
