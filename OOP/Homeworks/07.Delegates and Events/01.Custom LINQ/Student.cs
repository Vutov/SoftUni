using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Custom_LINQ
{
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
