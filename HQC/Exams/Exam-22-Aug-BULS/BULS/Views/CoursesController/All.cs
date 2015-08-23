namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models;
    using Utilities;

    public class All : BaseView
    {
        public All(IEnumerable<Course> courses)
            : base(courses)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as IEnumerable<Course>;
            if (!courses.Any())
            {
                viewResult.AppendLine(Message.NoCourses);
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count).AppendLine();
                }
            }
        }
    }
}