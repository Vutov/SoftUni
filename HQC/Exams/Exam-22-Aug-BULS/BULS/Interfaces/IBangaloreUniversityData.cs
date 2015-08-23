namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data.Repositories;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users();

        CourseRepository Courses();
    }
}