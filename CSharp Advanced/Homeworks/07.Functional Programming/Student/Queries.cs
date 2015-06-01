using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student
{
    class Queries
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student("Ivan", "Georgiev", 24, "112a14", "1234", "mail@",
                    new List<int>() {2, 3}, 1),
                new Student("Ben", "Ivanov", 12, "456115", "456115", "@mail",
                    new List<int>() {3, 4, 4, 5}, 2),
                new Student("Maik", "Markov", 34, "789213", "789213", "ma@il",
                    new List<int>() {2, 2, 2, 2}, 3),
                new Student("Geprgo", "Ivanov", 45, "123414", "123414", "mai@l",
                    new List<int>() {2, 4, 4}, 1),
                new Student("Mitko", "Markov", 5, "526114", "526114", "m@ail",
                    new List<int>() {6,6,6,6,6}, 2),
                new Student("Pehso", "Ivanov", 123, "021237", "021237", "mail@a",
                    new List<int>() {2,3,3}, 3),
                new Student("Asen", "Georgievich", 2, "882214", "882214", "ma@il",
                    new List<int>() {1, 3, 4, 5}, 1),
                new Student("Ivan", "Ivanov", 24, "777715", "777715", "mai#@l",
                    new List<int>() {6, 3, 4, 5}, 2),
                new Student("Mariika", "Markov", 14, "112314", "+359 25123", "ma#$@il@abv.bg",
                    new List<int>() {2, 38, 5}, 3),
                new Student("Gundi", "Ivanov", 54, "112315", "89123", "mai@@l",
                    new List<int>() {2, 3, 7, 5}, 1, "Spade"),
                new Student("Asen", "Georgiev", 64, "14g115", "0-123", "m@@ail@abv.bg",
                    new List<int>() {2, 3, 2, 5}, 4, "Ace"),
                new Student("AsenI", "Georgiev", 64, "14g214", "0-123", "m@@ail@abv.bg",
                    new List<int>() {2, 2}, 4, "Ace"),
            };

            Console.WriteLine("1.Students by Group:");
            Console.WriteLine("\t* " + string.Join("\n\t* ",
                students.Where(student => student.GroupNumber == 2)
                .OrderBy(student => student.FirstName)));
            Console.WriteLine();

            Console.WriteLine("2.Students by First and Last Name:");
            Console.WriteLine("\t* " + string.Join("\n\t* ",
                students.Where(student => student.FirstName.CompareTo(student.LastName) < 0)));
            Console.WriteLine();

            Console.WriteLine("3.Students by Age:");
            var ageQuery =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { student.FirstName, student.LastName, student.Age };

            foreach (var student in ageQuery)
            {
                Console.WriteLine("\t* {0} {1} age {2}",
                    student.FirstName, student.LastName, student.Age);
            }

            Console.WriteLine();

            Console.WriteLine("4.Sort Students:");
            Console.WriteLine(" Lambda:");
            Console.WriteLine("\t* " + string.Join("\n\t* ",
                students.OrderBy(student => student.FirstName)
                .ThenByDescending(student => student.LastName)));

            var sortQuery =
                from student in students
                orderby student.FirstName, student.LastName descending
                select student;

            Console.WriteLine(" Query:");
            foreach (var student in sortQuery)
            {
                Console.WriteLine("\t* {0} {1}",
                    student.FirstName, student.LastName);
            }
            Console.WriteLine();

            Console.WriteLine("5.Filter Students by Email Domain:");
            var emailQuery =
               from student in students
               where student.Email.Contains("@abv.bg")
               select student;

            foreach (var student in emailQuery)
            {
                Console.WriteLine("\t* {0} {1} {2}",
                    student.FirstName, student.LastName, student.Email);
            }

            Console.WriteLine();

            Console.WriteLine("6.Filter Students by Phone:");
            var phoneQuery =
               from student in students
               where student.Phone.StartsWith("02") ||
                    student.Phone.StartsWith("+3592") ||
                    student.Phone.StartsWith("+359 2")
               select student;

            foreach (var student in phoneQuery)
            {
                Console.WriteLine("\t* {0} {1} {2}",
                    student.FirstName, student.LastName, student.Phone);
            }

            Console.WriteLine();

            Console.WriteLine("7.Excellent Students:");
            var excelentQuery =
               from student in students
               where student.Marks.Contains(6)
               select new { student.FirstName, student.LastName, student.Marks };

            foreach (var student in excelentQuery)
            {
                Console.WriteLine("\t* {0} {1} {2}",
                    student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }

            Console.WriteLine();

            Console.WriteLine("8.Weak Students:");
            var weakQuery =
               from student in students
               where student.Marks.FindAll(grade => grade == 2).Count == 2
               select new { student.FirstName, student.LastName, student.Marks };

            foreach (var student in weakQuery)
            {
                Console.WriteLine("\t* {0} {1} {2}",
                    student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }

            Console.WriteLine();

            Console.WriteLine("9.Students Enrolled in 2014:");
            var yearQuery =
               from student in students
               where student.FacultyNumber[4] == '1' && student.FacultyNumber[5] == '4'
               select student;

            foreach (var student in yearQuery)
            {
                Console.WriteLine("\t* {0} {1} {2}",
                    student.FirstName, student.LastName, student.FacultyNumber);
            }

            Console.WriteLine();

            Console.WriteLine("10.Students by Groups:");
            var groupQuery =
                from student in students
                group student by student.GroupName;

            foreach (var group in groupQuery)
            {
                Console.WriteLine("* {0}:\n\t* {1}",
                    group.Key, string.Join("\n\t* ", group) );
            }
        }
    }
}
