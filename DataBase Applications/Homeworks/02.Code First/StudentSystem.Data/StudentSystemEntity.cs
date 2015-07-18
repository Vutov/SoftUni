namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Initializations;
    using Migrations;
    using Model;

    public class StudentSystemEntity : DbContext
    {
        public StudentSystemEntity()
            : base("name=StudentSystemEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>());
            //Database.SetInitializer(new DbInitializator());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}