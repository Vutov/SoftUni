namespace Visitor.Models.Visitors
{
    using CustomerService.Models;

    public class FreePurchaseVisitor : Visitor
    {
        public override void Visit(Customer customer)
        {
            customer.AddFreePurchase(new Purchase("SteamOp", 0.0));
        }
    }
}
