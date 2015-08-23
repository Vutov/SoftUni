namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class CoursesController : BaseController
    {
        public CoursesController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            var allCourses = this.Data.Courses().GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count);
            return this.View(allCourses);
        }

        public IView Details(int courseId)
        {
            if (!this.HasCurrentUser())
            {
                throw new ArgumentException(Message.NoOneLogged);
            }

            var course = this.Data.Courses().Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(Message.NoCourseWithId, courseId));
            }

            var user = this.User;
            if (!user.Courses.Contains(course))
            {
                throw new ArgumentException(Message.NotEnrolledInCourse);
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses().Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(Message.NoCourseWithId, courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException(Message.AlreadyEnrolled);
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);

            var c = new Course(name);
            this.Data.Courses().Add(c);
            return this.View(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);

            Course course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses().Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(Message.NoCourseWithId, courseId));
            }

            return course;
        }
    }
}
