using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Human__Student_and_Worker
{
    abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (isValidName(value))
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
                if (isValidName(value))
                {
                    this.lastName = value;
                }
            }
        }

        private bool isValidName(string name)
        {
            if (Regex.IsMatch(name, "[a-zA-Z]{2,20}"))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid name format");
            }
        }

        public override string ToString()
        {
            return string.Format("My name is {0} and I'm {1}", this.firstName, GetType().Name);
        }
    }
}
