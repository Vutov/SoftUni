using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurtovo.Bank.Accounts;
using BankOfKurtovo.Bank.Customers;

namespace BankOfKurtovo
{
    class Tests
    {
        static void Main(string[] args)
        {
            Deposit deposit = new Deposit(new Individual("me", 123), 499, 0.1m, 2);
            Console.WriteLine(deposit.InterestRate);
            deposit.Deposit(10);
            Console.WriteLine(deposit.Balance);
            Loan myLoan = new Loan(new Company("MT", 11), 1000, 0.3m, 2);
            Console.WriteLine(myLoan.CalculateInterest());
            var morgage = new Mortgage(new Individual("me again", 1), 1000, 0.1m, 7);
            Console.WriteLine(morgage.CalculateInterest());
            morgage = new Mortgage(new Company("me ET", 1), 2000, 0.4m, 7);
            Console.WriteLine(morgage.CalculateInterest());
        }
    }
}
