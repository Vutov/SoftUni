using System;
using System.Linq;

namespace _01.DbContext
{
    using System.Data.Entity;

    class TestQuery
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var employees = context.Employees.Include(e => e.Address).Where(a => a.Address.AddressID == 1);

            Console.WriteLine(employees.First().FirstName);
        }
    }
}
