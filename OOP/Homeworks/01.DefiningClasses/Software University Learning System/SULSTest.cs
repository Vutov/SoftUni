using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_University_Learning_System
{
    class SULSTest
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>()
            {
                new JuniorTrainer("Sasda", "Asds", 20),
                new JuniorTrainer("Scfs", "Xad", 21),
                new SeniorTrainer("Qdfsdf", "Basd", 25),
                new SeniorTrainer("Zasd", "Afsdfsd", 20),
            };

            var someOne = new SeniorTrainer("Asd", "Sad", 20);
            someOne.CreateCourse("estCourse");
            someOne.DeleteCourse("estCourse");
            trainers.ForEach(Console.WriteLine);
            Console.WriteLine();

            var students = new List<Student>()
            {
                new OnlineStudent("Sasda", "Asds", 20, "1234", 2.1, "te"),
                new OnlineStudent("Scfs", "Xad", 21, "1235", 5.1, "te"),
                new OnlineStudent("Asfs", "Xad", 21, "1230", 3.1, "te"),
                new GraduateStudent("Qdfsdf", "Basd", 22, "1236", 6.0),
                new DropoutStudent("Zasd", "Afsdfsd", 35, "1237", 3.0, "dropped"),
            };

            var query = students.Where(x => x is CurrentStudent).OrderBy(student => student.AvgGrade);
            foreach (var person in query)
            {
                Console.WriteLine(person);
            }
        }
    }
}
