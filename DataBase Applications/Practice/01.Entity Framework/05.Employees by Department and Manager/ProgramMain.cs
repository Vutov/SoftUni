using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Employees_by_Department_and_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDepartmentAndManager();
        }

        private static void GetDepartmentAndManager()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Manager != null)
                .OrderBy(d => d.Department.Name)
                .ThenBy(m => m.Manager.FirstName + " " + m.Manager.LastName)
                .ToList();

            employees.ForEach(e =>
            {
                Console.WriteLine("{0} Dep: {1}, Manager {2}",
                    e.FirstName + " " + e.LastName,
                    e.Department.Name,
                    e.Manager.FirstName + " " + e.Manager.LastName);
            });
        }
    }
}
