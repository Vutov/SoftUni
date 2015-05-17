using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.People;
using Company_Hierarchy.Utility;

namespace Company_Hierarchy
{
    class Tests
    {
        static void Main(string[] args)
        {
            var employees = new List<Person>()
            {
                new Manager("Some", "Guy", 123, new List<Employee>()
                {
                    new Employee("Other", "Guy", 124, 200, Department.Sales),
                    new Employee("An", "Guy", 125, 500, Department.Marketing),
                }),
                new SalesEmployee("Ga", "mani", 126, new List<Sale>()
                {
                    new Sale("Some", new DateTime(), 123.4M )
                }),
                new Customer("Sas", "asds", 12345, 1234.5M),
                new Developer("Dev", "Guy", 12346, new List<Project>()
                {
                    new Project("Proj", new DateTime(), "Test project", State.Open )
                }),
                new Employee("Emply", "asdas", 123468, 19238, Department.Production)
            };

            employees.ForEach(Console.WriteLine);
        }
    }
}
