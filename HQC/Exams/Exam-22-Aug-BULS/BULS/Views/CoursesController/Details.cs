namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System;
    using System.Linq;
    using System.Text;
    using Models;
    using Utilities;

    public class Details : BaseView
    {
        public Details(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as Course;
            viewResult.AppendLine(courses.Name);
            if (!courses.Lectures.Any())
            {
                viewResult.AppendLine(Message.NoLectures);
            }
            else
            {
                var lectureNames = courses.Lectures.Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}