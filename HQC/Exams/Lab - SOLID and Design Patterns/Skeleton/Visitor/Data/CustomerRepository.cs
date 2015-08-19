namespace CustomerService.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class CustomerRepository
    {
        private const int PremiumCustomerMinPurchasePower = 500;

        private readonly ISet<Customer> customers;

        public CustomerRepository()
        {
            this.customers = new HashSet<Customer>();
            this.Seed();
        }

        public IEnumerable<Customer> GetAll()
        {
            return this.customers;
        }

        public IEnumerable<Customer> GetPremiumCustomers()
        {
            return this.customers
                .Where(c => c.Purchases
                    .Sum(p => p.Price) >= PremiumCustomerMinPurchasePower);
        }

        private void Seed()
        {
            var gosho = new Customer("George");
            gosho.Purchases.Add(new Purchase("Corkscrew", 20));
            gosho.Purchases.Add(new Purchase("Audi A6", 3000.00));

            var peyo = new Customer("Peyo");
            peyo.Purchases.Add(new Purchase("Sheets", 415.50));

            var tania = new Customer("Tania");
            tania.Purchases.Add(new Purchase("Ropes", 99.90));
            tania.Purchases.Add(new Purchase("Fifty Shades of Gray", 129.80));
            tania.Purchases.Add(new Purchase("Intimate Nerve Stimulant", 455.90));
            tania.Discount = 3.3;

            this.customers.Add(gosho);
            this.customers.Add(peyo);
            this.customers.Add(tania);
        }
    }
}
