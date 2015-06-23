using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Customer
{
    class Tests
    {
        public static void Main(string[] args)
        {
            var customer = new Customer("ma", "re", "mi", "1",
                "asdas", "12321", "adsd", new List<Payment>() { new Payment("asds", 12)},
                CustomerType.OneTime);

            var copy = (Customer) customer.Clone();

            Console.WriteLine(customer == copy);
            Console.WriteLine(customer);
            copy.FirstName = "Changes!";
            Console.WriteLine(customer);
            Console.WriteLine(copy);
        }
    }
}
