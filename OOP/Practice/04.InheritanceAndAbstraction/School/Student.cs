using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student : Person
    {
        public string ClassNumber { get; set; }

        public Student(string name, string classNumber, string details = null)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
            this.Details = details;
        }
    }
}
