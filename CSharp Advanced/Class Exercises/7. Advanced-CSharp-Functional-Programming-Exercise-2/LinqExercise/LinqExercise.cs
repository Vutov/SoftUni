using System;
using System.IO;
using System.Linq;

namespace LinqExercise
{
    using System.Collections.Generic;

    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();

            using (var reader = new StreamReader(FilePath))
            {
                var data = reader.ReadLine();
                data = reader.ReadLine();
                while (data != null)
                {
                    string[] tokens = data.Split();

                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    string email = tokens[3];
                    string gender = tokens[4];
                    string studentType = tokens[5];
                    int examResult = int.Parse(tokens[6]);
                    int homeworksSent = int.Parse(tokens[7]);
                    int homeworksEvaluated = int.Parse(tokens[8]);
                    double teamworkScore = double.Parse(tokens[9]);
                    int attendancesCount = int.Parse(tokens[10]);
                    double bonus = double.Parse(tokens[11]);

                    students.Add(new Student(
                        id,
                        firstName,
                        lastName,
                        email,
                        gender,
                        studentType,
                        examResult,
                        homeworksSent,
                        homeworksEvaluated,
                        teamworkScore,
                        attendancesCount,
                        bonus));

                    data = reader.ReadLine();
                }
            }

            Console.WriteLine(string.Join("\n", students.Where(student => student.Gender == "Male")));
            Console.WriteLine(string.Join("\n", students.Where(student => student.ExamResult >= 350)));
            Console.WriteLine(string.Join("\n", students.Where(student => student.ExamResult >= 300 && student.StudentType == "Online").OrderByDescending(criteria => criteria.ExamResult)));
            Console.WriteLine(string.Join("\n", students.Where(student => student.HomeworksSent == 0).OrderBy(student => student.FirstName).ThenBy(student => student.LastName)));
            var queryData =
                from student in students
                where student.StudentType == "Onsite" && student.AttendancesCount <= 5
                select new { student.Email, student.ExamResult, student.AttendancesCount };

            foreach (var info in queryData)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine(students.Count(student => student.Bonus >= 4));
            Console.WriteLine(students.Where(student => student.StudentType == "Online").Select(student => student.ExamResult).Average());
            Console.WriteLine(students.Where(student => student.StudentType == "Onsite").Select(student => student.ExamResult).Average());
            var max = students.Max(student => student.TeamworkScore);
            Console.WriteLine(students.Count(student => student.TeamworkScore == max));
            var studentGroups = students.GroupBy(student => student.StudentType);
            foreach (var studentGroup in studentGroups)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t" + student);
                }
            }
            var studentGroups2 = students.GroupBy(student => student.FirstName[0]).OrderBy(student => student.Key);
            foreach (var studentGroup in studentGroups2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t" + student);
                }
            }
        }
    }
}