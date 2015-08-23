namespace BangaloreUniversityLearningSystem.Utilities
{
    public static class Message
    {
        public const string AuthorizationFailed = "The current user is not authorized to perform this operation.";
        public const string NoOneLogged = "There is no currently logged in user.";
        public const string NoCourseWithId = "There is no course with ID {0}.";
        public const string AlreadyEnrolled = "You are already enrolled in this course.";
        public const string UserDontExist = "A user with username {0} does not exist.";
        public const string NotAuthorized = "The current user is not authorized to perform this operation.";
        public const string PassWordDontMatch = "The provided passwords do not match.";
        public const string UserAlreadyExist = "A user with username {0} already exists.";
        public const string WrongPassword = "The provided password is wrong.";
        public const string CourseNameLenError = "The course name must be at least 5 symbols long.";
        public const string LectureNameLenError = "The lecture name must be at least 3 symbols long.";
        public const string UsernameLenError = "The username must be at least 5 symbols long.";
        public const string PasswordLenError = "The password must be at least 6 symbols long.";
        public const string UserLoggedSuccessfully = "User {0} logged in successfully.";
        public const string UserLoggedOutSuccessfully = "User {0} logged out successfully.";
        public const string UserRegisteredSuccessfully = "User {0} registered successfully.";
        public const string CourseCreatedSuccessfully = "Course {0} created successfully.";
        public const string LectureAddedSuccessfully = "Lecture successfully added to course {0}.";
        public const string EnrolledSuccessfully = "Student successfully enrolled in course {0}.";
        public const string NoCourses = "No courses.";
        public const string NoLectures = "No lectures";
        public const string AllreadyLoged = "There is already a logged in user.";
        public const string NotEnrolledInCourse = "You are not enrolled in this course.";
    }
}
