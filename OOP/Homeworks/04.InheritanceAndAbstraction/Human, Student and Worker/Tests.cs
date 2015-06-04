using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human__Student_and_Worker
{
    class Tests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Students:");
            var students = new List<Student>()
            {
                new Student("First", "frist", "as2345"),
                new Student("Sec", "frist", "bs2345"),
                new Student("Thir", "frist", "ass2345"),
                new Student("Las", "frist", "bd2345"),
                new Student("Nex", "frist", "cas2345"),
                new Student("Some", "frist", "123s2345"),
                new Student("Dude", "frist", "asds2345"),
                new Student("Here", "frist", "vbns2345"),
                new Student("Uff", "frist", "123xas2345"),
                new Student("bla", "frist", "xxas2345"),
            };
            var sortedStudents = students.OrderBy(x => x.FacultyNum);
            foreach (var sortedStudent in sortedStudents)
            {
                Console.WriteLine("{0}, {1}", sortedStudent, sortedStudent.FacultyNum);
            }

            Console.WriteLine("Workers:");
            var workers = new List<Worker>()
            {
                new Worker("Work", "frist", 13.3M, 13.4M),
                new Worker("Er", "frist", 14.3M, 13.4M),
                new Worker("Hard", "frist", 15.3M, 13.4M),
                new Worker("Las", "frist", 12.3M, 13.4M),
                new Worker("Nex", "frist", 10.3M, 13.4M),
                new Worker("Wor", "frist", 130.3M, 13.4M),
                new Worker("King", "frist", 112.3M, 13.4M),
                new Worker("Here", "frist", 13123.3M, 13.4M),
                new Worker("Of", "frist", 113.3M, 13.4M),
                new Worker("eh", "frist", 3.3M, 13.4M),
            };

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            foreach (var sortedWorker in sortedWorkers)
            {
                Console.WriteLine("{0}, {1:F2}", sortedWorker, sortedWorker.MoneyPerHour());
            }

            Console.WriteLine("All");
            var allHumans = new List<Human>();
            students.ForEach(x => allHumans.Add(x));
            workers.ForEach(x => allHumans.Add(x));

            var sortedHumans = allHumans.OrderBy(x => x.FirstName + ' ' + x.LastName);
            foreach (var sortedHuman in sortedHumans)
            {
                Console.WriteLine("{0}", sortedHuman);
            }
        }
    }
}
