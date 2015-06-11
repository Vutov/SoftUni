using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankOfKurtovo.Bank.Customers
{
    abstract class Customer
    {
        private string name;
        private int id;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (Regex.IsMatch(value, "\\w{2,20}"))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Name!");
                }
            }
        }

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
                    throw new ArgumentException("Invalid ID!");
                }
            }
        }

        protected Customer(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
