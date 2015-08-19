namespace Visitor.Models.Visitors
{
    using CustomerService.Models;
    using Interfaces;

    public abstract class Visitor : ICustomerVisitor
    {
        public abstract void Visit(Customer customer);
    }
}
