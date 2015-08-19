namespace CustomerService
{
    using Data;
    using Visitor.Models.Visitors;

    public class Program
    {
        static void Main()
        {
            var repository = new CustomerRepository();

            var premiumCustomers = repository.GetPremiumCustomers();
            var discountVisitor = new DiscountRaiseVisitor();
            foreach (var premiumCustomer in premiumCustomers)
            {
                premiumCustomer.Accept(discountVisitor);
            }

            var allCustomers = repository.GetAll();
            var freePurchaseVisitor = new FreePurchaseVisitor();
            foreach (var customer in allCustomers)
            {
                customer.Accept(freePurchaseVisitor);
            }
        }
    }
}
