namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Text;
    using Models;
    using Utilities;

    public class Create : BaseView
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(Message.CourseCreatedSuccessfully, course.Name).AppendLine();
        }
    }
}