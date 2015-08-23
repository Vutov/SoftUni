namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Text;
    using Models;
    using Utilities;

    public class AddLecture : BaseView
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(Message.LectureAddedSuccessfully, course.Name).AppendLine();
        }
    }
}