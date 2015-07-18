namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;

    public class ConsoleClient
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemEntity();
            var studentsCount = context.Students.Count();
            Console.WriteLine(studentsCount);

            var studentHomeworks = context.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Courses.Select(c => c.Homeworks
                        .Select(h => new
                        {
                            h.Content,
                            h.TypeContent
                        }))
                })
                .ToList();

            studentHomeworks.ForEach(s =>
            {
                Console.WriteLine("{0}", s.Name);
                var homeworks = s.Homeworks.ToList();
                homeworks.ForEach(c =>
                {
                    c.ToList().ForEach(h => Console.WriteLine("*{0} - {1}",
                        h.Content,
                        h.TypeContent));
                });
            });

            var courses = context.Courses.Include(r => r.Resources)
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                })
                .ToList();

            courses.ForEach(c =>
            {
                Console.WriteLine("{0} - {1}", c.Name, c.Description);
                c.Resources.ToList().ForEach(r =>
                {
                    Console.WriteLine("{0}, {1} - {2}", r.Name, r.TypeResouce, r.Url);
                });
            });

            var coursesR = context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderBy(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    CourseCount = c.Resources.Count
                })
                .ToList();
            coursesR.ForEach(Console.WriteLine);

            var date = DateTime.Now;
            var activeCouses = context.Courses
                .Where(c => c.StartDate < date && c.EndDate >= date)
                .ToList()
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate).TotalDays)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    StudentCount = c.Students.Count,
                    CurseDuration = (c.EndDate - c.StartDate).TotalDays
                })
                .ToList();

            activeCouses.ForEach(c =>
            {
                Console.WriteLine("{0} [{1:dd-MM-yyyy} - {2:dd-MM-yyyy}]: {3} days, {4} students", c.Name,
                    c.StartDate, c.EndDate, c.CurseDuration, c.StudentCount);
            });

            var students = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    NumOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AvgPrice = s.Courses.Sum(c => c.Price)/s.Courses.Count
                })
                .ToList();
            
            students.ForEach(s =>
            {
                Console.WriteLine("{0} - {1} courses, total price {2:F}, avg price {3:F}",
                    s.Name,
                    s.NumOfCourses,
                    s.TotalPrice,
                    s.AvgPrice);
            });
        }
    }
}
