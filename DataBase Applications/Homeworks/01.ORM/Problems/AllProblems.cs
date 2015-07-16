namespace Problems
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using DBConnection;

    class AllProblems
    {
        static void Main(string[] args)
        {
            // 02.Employee DAO Class
            // Uncomment if you want to mess with the db
            var employee = Handler.FindByKey(10);
            Console.WriteLine(employee.FirstName);
            ////Handler.Modify(employee, "mitko");
            Console.WriteLine(employee.FirstName);
            employee.FirstName = "asda";
            ////Handler.Add(employee);

            // 03.Database Search Queries
            var context = new SoftUniEntities();
            var emplyeedByProject = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                              p.StartDate <= new DateTime(2002, 12, 31)))
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.Projects
                        .Where(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                                    p.StartDate <= new DateTime(2002, 12, 31))
                })
                .Take(5)
                .ToList();

            var lineCounter = 1;
            emplyeedByProject.ForEach(e =>
            {
                Console.Write("{0}.{1}: ",
                    lineCounter,
                    e.ManagerName);
                e.Projects.ToList().ForEach(p => Console.Write("{0}: {1:dd-MM-yyyy} ", p.Name, p.StartDate));
                Console.WriteLine();

                lineCounter++;
            });

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    Address = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .Take(10)
                .ToList();

            addresses.ForEach(a => Console.WriteLine("{0}, {1} - {2} employees",
                a.Address, a.TownName, a.EmployeeCount));

            var employeeById = context.Employees.Find(147);
            var employeeProjects = employeeById.Projects.OrderBy(p => p.Name).Select(p => p.Name);
            Console.WriteLine("147. {0} {1} - {2}, {3}", employeeById.FirstName, employeeById.LastName,
                employeeById.JobTitle, string.Join(", ", employeeProjects));

            var departments = context.Departments
                .Where(d => d.Employee.Count > 5)
                .OrderBy(d => d.Employee.Count)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employee.Select(e => new
                                {
                                    e.FirstName,
                                    e.LastName,
                                    e.HireDate,
                                    e.JobTitle
                                })
                                .ToList()
                })
                .ToList();

            departments.ForEach(d =>
            {
                Console.WriteLine("{0}, {1}: {2}", d.DepartmentName, d.ManagerName, d.Employees.Count);

                // To print all employees
                ////var employeeCounter = 1;
                ////d.Employees.ForEach(e =>
                ////{
                ////    Console.WriteLine("{0}.{1} {2} - {3} {4:dd-MM-yyyy}", employeeCounter,
                ////        e.FirstName, e.LastName, e.JobTitle, e.HireDate);

                ////    employeeCounter++;
                ////});
            });

            // 04.Native SQL Query
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            PrintNumberOfEmployeesNativeQuery(context);
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();

            PrintNumberOfEmployeesLinqQuery(context);
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Stop();

            // 06.Call a Stored Procedure
            /* Proc used:
             * CREATE PROC udp_get_full_names AS
             * SELECT FirstName + ' ' + LastName AS [Full name]
             * FROM Employees
             */

            var employees = context.udp_get_full_names().Take(5);
            Console.WriteLine(string.Join(", ", employees));
        }

        private static void PrintNumberOfEmployeesNativeQuery(SoftUniEntities context)
        {
            var employees = context.Employees.SqlQuery(@"
                SELECT *
                FROM Employees e
                JOIN EmployeesProjects ep
                ON e.EmployeeID = ep.EmployeeID
                JOIN Projects p
                ON p.ProjectID = ep.ProjectID
                WHERE p.StartDate >= '2002-1-1' AND p.StartDate <= '2002-12-31'")
                .ToList();
            Console.WriteLine(employees.Count);
        }

        private static void PrintNumberOfEmployeesLinqQuery(SoftUniEntities context)
        {
            var emplyeedByProject = context.Employees
               .Where(e => e.Projects
                   .Any(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                             p.StartDate <= new DateTime(2002, 12, 31)))
               .OrderBy(e => e.FirstName)
               .Select(e => new
               {
                   ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                   Projects = e.Projects
                       .Where(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                                   p.StartDate <= new DateTime(2002, 12, 31))
               })
               .ToList();
            Console.WriteLine(emplyeedByProject.Count);
        }
    }
}
