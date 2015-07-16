namespace Problems
{
    using System.Data.Entity.Core;
    using DBConnection;

    public static class Handler
    {
        private static SoftUniEntities contex = new SoftUniEntities();

        public static void Add(Employee employee)
        {
            contex.Employees.Add(employee);
            contex.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var employee = contex.Employees.Find(key);

            if (employee == null)
            {
                throw new ObjectNotFoundException("No employee found");
            }

            return employee;
        }

        public static void Modify(Employee employee, string newName)
        {
            var id = employee.EmployeeID;
            var databaseEmployee = contex.Employees.Find(id);
            databaseEmployee.FirstName = newName;
            contex.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            contex.Employees.Remove(employee);
            contex.SaveChanges();
        }
    }
}
