using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06.ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ATMEntities())
            {
                Console.WriteLine("Transaction started.");
                Console.WriteLine("CardNumber:");
                var cardNumber = Console.ReadLine();
                Console.WriteLine("CardPin");
                var pin = Console.ReadLine();
                var account = context.CardAccounts
                    .Where(c => c.CardNumber == cardNumber && c.CardPIN == pin)
                    .Take(1);
                var userAccount = account.ToList();
                if (!userAccount.Any())
                {
                    throw new ArgumentException("Invalid card number or pin!");
                }

                var accountMoney = userAccount.First().CardCash;
                Console.WriteLine("You have {0:F2}$", accountMoney);
                Console.WriteLine("Amount to withdraw:");
                var moneyToWithdraw = decimal.Parse(Console.ReadLine());

                if (moneyToWithdraw > accountMoney)
                {
                    throw new ArgumentException("Not enough money in the card!");
                }

                var moneyLeft = accountMoney - moneyToWithdraw;
                account.First().CardCash = moneyLeft;

                Console.WriteLine("Money left {0:F2}", moneyLeft);

                context.SaveChanges();

                context.TransactionHistories.Add(new TransactionHistory()
                {
                    CardNumber = cardNumber,
                    TransactionDate = DateTime.Now,
                    Amount = moneyToWithdraw
                });

                context.SaveChanges();

                Console.WriteLine("Transaction end.");
            }
        }
    }
}
