using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyInfo
{
    class CompanyInfo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Please enter company adress:");
            string adress = Console.ReadLine();
            Console.WriteLine("Please enter company phone number:");
            uint phoneNumber = uint.Parse(Console.ReadLine());
            Console.WriteLine("Please enter company fax:");
            uint fax = uint.Parse(Console.ReadLine());
            Console.WriteLine("Please enter company website:");
            string website = Console.ReadLine();
            Console.WriteLine("Please enter manager's first name:");
            string managerFirstName = Console.ReadLine();
            Console.WriteLine("Please enter manager's last name:");
            string managerLastName = Console.ReadLine();
            Console.WriteLine("Please enter manager's phone number:");
            uint managerPhoneNumber = uint.Parse(Console.ReadLine());
            Console.WriteLine("Company's name is {0}, with adress {1}, phone number"
            + " {2:0### ### ###}, fax {3}) and webisite {4}. The manager is {5} {6}"
            + " with phone number {7:0### ### ###}.", companyName, adress, phoneNumber,
            fax, website, managerFirstName, managerLastName, managerPhoneNumber);
        }
    }
}