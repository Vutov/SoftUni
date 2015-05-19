using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurtovo.Bank.Customers;

namespace BankOfKurtovo.Bank.Accounts
{
    class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate, int duration)
            : base(customer, balance, interestRate, duration)
        {
            if (balance <= 1000)
            {
                this.InterestRate = 0;
            }
        }
    }
}
