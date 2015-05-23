using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Lecture
    {
        public OffsiteCourse(string courseName, string teacherName = null, IList<string> students = null, string place = null)
            : base(courseName, teacherName, students, place)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Place != null)
            {
                result.Append("; Town = ");
                result.Append(this.Place);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
