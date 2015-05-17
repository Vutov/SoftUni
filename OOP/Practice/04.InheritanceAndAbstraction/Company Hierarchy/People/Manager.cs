using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;

namespace Company_Hierarchy.People
{
    class Manager : Person, IManager
    {

        private List<Employee> employees;

        public List<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public Manager(string firstName, string lastName, int id, List<Employee> employees)
            : base(firstName, lastName, id)
        {
            this.Employees = employees;
        }
    }
}
