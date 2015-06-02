using System;

namespace Software_University_Learning_System
{
    class SeniorTrainer: Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("{0} has been deleted.", courseName);
        } 
    }
}
