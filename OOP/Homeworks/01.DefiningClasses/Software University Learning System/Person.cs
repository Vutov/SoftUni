using System;
using System.Text.RegularExpressions;

namespace Software_University_Learning_System
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (validName(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (validName(value))
                {
                    this.lastName = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (validAge(value))
                {
                    this.age = value;
                }
            }
        }

        protected Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        private bool validAge(int value)
        {
            if (value >= 0 && value <= 130)
            {
                return true;
            }

            throw new ArgumentException("Invalid age!");
        }

        private bool validName(string name)
        {
            if (Regex.IsMatch(name, "[A-Z]{1}[a-z]+"))
            {
                return true;
            }

            throw new ArgumentException("Invalid name!");
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} yrs old {3}",
                this.firstName, this.lastName, this.age, GetType().Name);
        }
    }
}
