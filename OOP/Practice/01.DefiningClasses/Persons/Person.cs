using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persons
{
    class Person
    {

        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email = null)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length > 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new FormatException("Name must be at least 1 symbol!");
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Age must be between 0 and 100!");
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value == null || Regex.IsMatch(value, ".*?@.*"))
                {
                    this.email = value;
                }
                else
                {
                    throw new FormatException("Invalid Email!");
                }
            }
        }

        public override string ToString()
        {
            if (this.Email == null)
            {
                return string.Format("{0} is {1} years old and don't have email.", this.Name, this.Age);
            }
            return string.Format("{0} is {1} years old and have email: {2}.", this.Name, this.Age, this.Email);
        }

        static void Main(string[] args)
        {
            Person ivan = new Person("Ivan", 15, "ivan@abv.bg");
            Console.WriteLine(ivan);
            Person gosho = new Person("Gosho", 20);
            Console.WriteLine(gosho);
            Person mitko = new Person("", -2, "");
        }
    }
}
