namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class DBInitializer : CreateDatabaseIfNotExists<SystemDBContext>
    {
        protected override void Seed(SystemDBContext context)
        {
            context.Students.Add((new Student()
            {
                Name = "Test",
                PhoneNumber = "131",
                Birthday = new DateTime(2015, 1, 1, 0, 0, 0)
            }));
            context.Students.Add((new Student()
            {
                Name = "Test1",
                PhoneNumber = "132",
                Birthday = new DateTime(2015, 1, 1, 0, 0, 0)
            }));
            context.Students.Add((new Student()
            {
                Name = "Test2",
                PhoneNumber = "1311232",
                Birthday = new DateTime(2015, 1, 1, 0, 0, 0)
            }));
            context.Students.Add((new Student()
            {
                Name = "Test3",
                PhoneNumber = "131323231",
                Birthday = new DateTime(2015, 1, 1, 0, 0, 0)
            }));

            base.Seed(context);
        }
    }
}