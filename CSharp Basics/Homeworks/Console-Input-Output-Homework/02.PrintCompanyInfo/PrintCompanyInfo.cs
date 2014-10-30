using System;

class PrintCompanyInfo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Please enter company adress:");
        string adress = Console.ReadLine();
        Console.WriteLine("Please enter company phone number:");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Please enter company fax:");
        string fax = Console.ReadLine();
        if (fax == "") // pressed 'Enter' == "".
        {
            fax = "(no fax)";
        }
        Console.WriteLine("Please enter company website:");
        string website = Console.ReadLine();
        Console.WriteLine("Please enter manager's first name:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Please enter manager's last name:");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Please enter manager's age:");
        ushort managerAge = ushort.Parse(Console.ReadLine()); // age is in range 0 to 120ish(best case).
        Console.WriteLine("Please enter manager's phone number:");
        string managerPhoneNumber = Console.ReadLine();
        Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}" +
            "\nManager: {5} {6} (age: {7}, tel. {8}).",
            companyName, adress, phoneNumber, fax, website, managerFirstName,
            managerLastName, managerAge, managerPhoneNumber);
    }
}