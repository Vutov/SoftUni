using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;

namespace Company_Hierarchy.People
{
    abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value > 0)
                {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentException("The Id must be positive number.");
                }
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (IsValidName(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (IsValidName(value))
                {
                    this.lastName = value;
                }
            }
        }

        protected Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public static bool IsValidName(string name)
        {
            if (Regex.IsMatch(name, "[a-zA-Z]{2,20}"))
            {
                return true;
            }

            throw new ArgumentException("Invalid name!");
        }

        public override string ToString()
        {
            string name = this.firstName + " " + this.lastName;
            return string.Format("My names is {0} and I'm {1}", name, GetType().Name);
        }
    }
}
