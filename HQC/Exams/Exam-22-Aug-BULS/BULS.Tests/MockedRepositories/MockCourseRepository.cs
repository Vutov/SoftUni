namespace BULS.Tests.MockedRepositories
{
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Data.Repositories;
    using BangaloreUniversityLearningSystem.Models;

    public class MockCourseRepository : CourseRepository
    {
        public List<Course> Items { get; private set; }

        public MockCourseRepository()
        {
            this.Items = new List<Course>();
        }

        public override void Add(Course item)
        {
            this.Items.Add(item);
        }

        public override Course Get(int id)
        {
            return this.Items[id - 1];
        }
    }
}
