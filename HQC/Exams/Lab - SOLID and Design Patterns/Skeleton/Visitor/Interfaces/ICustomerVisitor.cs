namespace Visitor.Interfaces
{
    using CustomerService.Models;

    public interface ICustomerVisitor
    {
        void Visit(Customer customer);
    }
}
