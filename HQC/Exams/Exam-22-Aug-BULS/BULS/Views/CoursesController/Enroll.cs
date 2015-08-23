namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Text;
    using Models;
    using Utilities;

    public class Enroll : BaseView
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(Message.EnrolledSuccessfully, course.Name).AppendLine();
        }
    }
}