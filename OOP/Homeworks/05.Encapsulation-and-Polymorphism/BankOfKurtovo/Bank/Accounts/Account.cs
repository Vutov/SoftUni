using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurtovo.Bank.Customers;

namespace BankOfKurtovo.Bank.Accounts
{
    abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;
        private int duration;

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value >= 0)
                {
                    this.balance = value;
                }
                else
                {
                    throw new ArgumentException("Balance cannot be negative");
                }
            }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    this.interestRate = value;
                }
                else
                {
                    throw new ArgumentException("Interest rate must be between 0 and 2");
                }
            }
        }

        public int Duration { get; set; }

        protected Account(Customer customer, decimal balance, decimal interestRate, int duration)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.Duration = duration;
        }

        public virtual decimal CalculateInterest()
        {
            decimal fv = this.balance * (1 + this.interestRate * this.duration);

            return fv;
        }

        public virtual void Deposit(decimal value)
        {
            this.Balance += value;
        }

        public virtual void Withdraw(decimal value)
        {
            if (value <= this.balance)
            {
                this.Balance -= value;
            }
            else
            {
                throw new ArgumentException("Not enough money in the balance");
            }
        }
    }
}
