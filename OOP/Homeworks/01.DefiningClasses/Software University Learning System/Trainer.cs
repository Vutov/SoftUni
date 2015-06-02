using System;

namespace Software_University_Learning_System
{
    class Trainer : Person
    {
        protected Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("{0} created.", courseName);
        }
    }
}
