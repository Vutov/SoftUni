using System.Data.Entity;
using Models;

namespace Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext()
        {
            Database.SetInitializer(new DBInitializer());
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Resourse> Resourses { get; set; }
        public IDbSet<Homework> Homeworks { get; set; }
    }
}
