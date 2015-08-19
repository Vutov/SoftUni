namespace CustomerService.Models
{
    using System.Collections.Generic;
    using Visitor.Models.Visitors;

    public class Customer
    {
        private const double DefaultDiscount = 0.0;

        public Customer(string name)
        {
            this.Name = name;
            this.Purchases = new HashSet<Purchase>();
            this.Discount = DefaultDiscount;
        }

        public string Name { get; set; }

        public ISet<Purchase> Purchases { get; set; }

        public double Discount { get; set; }

        public void RaiseDiscount(double amount)
        {
            this.Discount += amount;
        }

        public void AddFreePurchase(Purchase purchase)
        {
            this.Purchases.Add(purchase);
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
