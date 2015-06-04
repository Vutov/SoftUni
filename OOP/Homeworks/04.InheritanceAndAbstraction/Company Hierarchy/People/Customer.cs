using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;

namespace Company_Hierarchy.People
{
    class Customer : Person, ICustomer
    {
        private decimal netPurchased;

        public Customer(string firstName, string lastName, int id, decimal netPurchased)
            : base(firstName, lastName, id)
        {
            this.NetPurchased = netPurchased;
        }

        public decimal NetPurchased
        {
            get
            {
                return this.netPurchased;
            }
            set
            {
                if (value >= 0)
                {
                    this.netPurchased = value;
                }
                else
                {
                    throw new ArgumentException("Net value of purchases cannot be negative!");
                }
            }
        }
    }
}
