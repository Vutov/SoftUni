namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemEntity>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemEntity context)
        {
            if (!context.Students.Any())
            {
                var student = new Student()
                {
                    Name = "Ivan Ivanov",
                    PhoneNumber = "+359 888 888 888",
                    RegistrationDate = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "DBA course",
                            Description = "Cool course!",
                            StartDate = new DateTime(2015,1,1),
                            EndDate = new DateTime(2016,10,1),
                            Price = 1000m,
                            Homeworks = new List<Homework>()
                            {
                                new Homework()
                                {
                                    Content = "some cool shit",
                                    SubmissionDate = DateTime.Now,
                                    TypeContent = TypeContent.ApplicationZip
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "book on cool stuff",
                                    TypeResouce = TypeResouce.Other,
                                    Url = "None"
                                }
                            }
                        }
                    }
                };

                context.Students.Add(student);
                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
