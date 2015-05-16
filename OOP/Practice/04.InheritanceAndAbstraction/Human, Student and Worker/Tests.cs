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
            students.Sort((x, y) =>
            {
                return x.FacultyNum.CompareTo(y.FacultyNum);
            });
            students.ForEach(x => Console.WriteLine("{0}, {1}", x, x.FacultyNum));

            Console.WriteLine("Workers:");
            var workers = new List<Worker>()
            {
                new Worker("Work", "frist", 13.3M, 13.4M),
                new Worker("Er", "frist",  14.3M, 13.4M),
                new Worker("Hard", "frist", 15.3M, 13.4M),
                new Worker("Las", "frist",  12.3M, 13.4M),
                new Worker("Nex", "frist",  10.3M, 13.4M),
                new Worker("Wor", "frist",  130.3M, 13.4M),
                new Worker("King", "frist",  112.3M, 13.4M),
                new Worker("Here", "frist",  13123.3M, 13.4M),
                new Worker("Of", "frist",  113.3M, 13.4M),
                new Worker("eh", "frist",  3.3M, 13.4M),
            };
            workers.Sort((x, y) =>
            {
                return (int)(y.MoneyPerHour() - x.MoneyPerHour());
            });
            workers.ForEach(x => Console.WriteLine("{0}, {1:F2}", x, x.MoneyPerHour()));

            Console.WriteLine("All");
            var allHumans = new List<Human>();
            students.ForEach(x => allHumans.Add(x));
            workers.ForEach(x => allHumans.Add(x));

            allHumans.Sort((x, y) =>
            {
                string xName = x.FirstName + " " + x.LastName;
                string yName = y.FirstName + " " + y.LastName;
                return xName.CompareTo(yName);
            });
            allHumans.ForEach(Console.WriteLine);
        }
    }
}
