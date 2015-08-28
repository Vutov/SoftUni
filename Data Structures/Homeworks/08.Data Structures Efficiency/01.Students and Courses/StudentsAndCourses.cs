namespace _01.Students_and_Courses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    class StudentsAndCourses
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("../../../Students.txt");
            var regex = @"([a-zA-Z]+)\s+\|\s+([a-zA-Z]+)\s+\|\s+(.+)";
            var matches = Regex.Matches(data, regex);
            var coursesAndStudents = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            foreach (Match match in matches)
            {
                var course = match.Groups[3].Value.Trim();
                var firstName = match.Groups[1].Value.Trim();
                var lastName = match.Groups[2].Value.Trim();
                if (!coursesAndStudents.ContainsKey(course))
                {
                    coursesAndStudents.Add(course, new SortedDictionary<string, SortedSet<string>>());
                }

                if (!coursesAndStudents[course].ContainsKey(firstName))
                {
                    coursesAndStudents[course].Add(firstName, new SortedSet<string>());
                }

                coursesAndStudents[course][firstName].Add(lastName);
            }

            foreach (var course in coursesAndStudents)
            {
                Console.Write(course.Key);
                var isFirstRow = true;
                foreach (var firstName in course.Value)
                {
                    foreach (var lastName in firstName.Value)
                    {
                        if (isFirstRow)
                        {
                            Console.Write(":");
                            isFirstRow = false;
                        }
                        else
                        {
                            Console.Write(",");
                        }

                        Console.Write(" {0} {1}", firstName.Key, lastName);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
