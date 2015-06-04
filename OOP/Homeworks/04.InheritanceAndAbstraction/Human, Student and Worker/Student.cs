using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Human__Student_and_Worker
{
    class Student : Human
    {
        private string facutlyNum;

        public Student(string firstName, string lastName, string facultynum)
            : base(firstName, lastName)
        {
            this.FacultyNum = facultynum;
        }

        public string FacultyNum
        {
            get { return this.facutlyNum; }
            set
            {
                if (Regex.IsMatch(value, "[a-zA-Z0-9]{5,10}"))
                {
                    this.facutlyNum = value;
                }
                else
                {
                    throw new ArgumentException("Invalid faculty number");
                }
            }
        }
    }
}
