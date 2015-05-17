using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;
using Company_Hierarchy.People;

namespace Company_Hierarchy.Utility
{
    class Sale : ISale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (Person.IsValidName(value))
                {
                    this.productName = value;
                }
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Price must be positive!");
                }
            }
        }

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }
    }
}
