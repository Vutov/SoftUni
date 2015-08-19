namespace Visitor.Models.Visitors
{
    using CustomerService.Models;

    public class DiscountRaiseVisitor: Visitor
    {
        public override void Visit(Customer customer)
        {
            customer.RaiseDiscount(5.0);
        }
    }
}
