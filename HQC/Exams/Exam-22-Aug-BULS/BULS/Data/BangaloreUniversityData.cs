namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;
    using Repositories;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        private readonly UsersRepository usersRepository;
        private readonly CourseRepository courseRepository;

        public BangaloreUniversityData()
        {
            this.usersRepository = new UsersRepository();
            this.courseRepository = new CourseRepository();
        }

        public UsersRepository Users()
        {
            return this.usersRepository;
        }

        public CourseRepository Courses()
        {
            return this.courseRepository;
        }
    }
}
