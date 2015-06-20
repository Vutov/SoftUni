namespace _03.Employees_with_Projects_after_2002
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System;
    using System.Linq;

    class ProgramMain
    {
        static void Main(string[] args)
        {
            var emplyees = GetEmployeesWithProjectsIn2002();
            PrintEmployees(emplyees);
            emplyees = GetEmployeesNative();
            PrintEmployees(emplyees);

        }

        private static List<Employee> GetEmployeesWithProjectsIn2002()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                        p.StartDate <= new DateTime(2002, 12, 31)))
                .OrderBy(e => e.FirstName + " " + e.LastName)
                .ToList();

            return employees;
        }

        private static List<Employee> GetEmployeesNative()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees.SqlQuery(@"
                SELECT *
                FROM Employees e
                JOIN EmployeesProjects ep
                ON e.EmployeeID = ep.EmployeeID
                JOIN Projects p
                ON p.ProjectID = ep.ProjectID
                WHERE p.StartDate >= '2002-1-1' AND p.StartDate <= '2002-12-31'").ToList();

            return employees;
        }

        private static void PrintEmployees(List<Employee> emplyees)
        {
            var counter = 1;
            emplyees.ForEach(e =>
            {
                Console.Write("{0}.{1}: ",
                    counter,
                    e.FirstName + " " + e.LastName);
                var projects = e.Projects
                    .Where(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                         p.StartDate <= new DateTime(2002, 12, 31));
                projects.ToList().ForEach(p => Console.Write("{0}: {1:dd-MM-yyyy} ", p.Name, p.StartDate));
                Console.WriteLine();

                counter++;
            });
        }
    }
}
