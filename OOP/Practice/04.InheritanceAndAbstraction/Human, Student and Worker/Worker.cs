using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human__Student_and_Worker
{
    class Worker : Human
    {
        private decimal weekSalary;
        private decimal dailyWorkHours;

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public decimal DailyWorkHours
        {
            get { return this.dailyWorkHours; }
            set { this.dailyWorkHours = value; }
        }

        public Worker(string firstName, string lastName, decimal weekSalary, decimal dailyWorkHours)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.DailyWorkHours = dailyWorkHours;
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary/(7*this.DailyWorkHours);
            return moneyPerHour;
        }
    }
}
