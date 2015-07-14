namespace _01.Db
{
    using System;
    using System.Linq;

    public class Emplyees
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            var employeeNames = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ToList();
            employeeNames.ForEach(Console.WriteLine);

            var employeesFromSeattle = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToList();

            employeesFromSeattle.ForEach(e => Console.WriteLine("{0} {1} from {2} - ${3}",
                e.FirstName, e.LastName, e.Name, e.Salary));

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            context.Addresses.Add(address);

            context.SaveChanges();
        }
    }
}
