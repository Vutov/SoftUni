using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;

namespace Company_Hierarchy.People
{
    class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value >= 0)
                {
                    this.salary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be negative!");
                }
            }
        }

        public Employee(string firstName, string lastName, int id, decimal salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
    }
}
