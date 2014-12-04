using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AccountInformation
{
    static void Main(string[] args)
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int clientId = int.Parse(Console.ReadLine());
        decimal balance = decimal.Parse(Console.ReadLine());

        string active = "";
        if (balance >= 0)
        {
            active = "yes";
        }
        else
        {
            active = "no";
        }

        Console.WriteLine("Hello, {0} {1}\nClient id: {2}\nTotal balance: {3:f}\nActive: {4}",
            firstName, lastName, clientId, balance, active);
    }
}
