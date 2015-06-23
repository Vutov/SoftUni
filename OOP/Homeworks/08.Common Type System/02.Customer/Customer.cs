using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Customer
{
    class Customer: ICloneable, IComparable
    {
        public Customer(string firstName, string middleName, string lastName, string id,
            string address, string mobilePhone, string email, List<Payment> payments,
            CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public List<Payment> Payments { get; set; }
        public CustomerType CustomerType { get; set; }

        public override bool Equals(object other)
        {
            if (other is Customer)
            {
                var otherCustomer = (Customer) other;
                if (this.Id == otherCustomer.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Address.GetHashCode() ^ this.Email.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} Id: {2}", this.FirstName, this.LastName, this.Id);
        }

        public int CompareTo(object other)
        {
            if (other is Customer)
            {
                string fullName = string.Format("{0} {1} {2}",
                this.FirstName, this.MiddleName, this.LastName);
                var otherCustomer = (Customer) other;
                string otherFullName = string.Format("{0} {1} {2}",
                    otherCustomer.FirstName,
                    otherCustomer.MiddleName,
                    otherCustomer.LastName);
                if (fullName.CompareTo(otherCustomer) != 0)
                {
                    return fullName.CompareTo(otherCustomer);
                }

                return this.Id.CompareTo(otherCustomer.Id);
            }

            return 0;
        }

        public object Clone()
        {
            return new Customer(this.FirstName, this.MiddleName, this.LastName,this.Id,
                this.Address, this.MobilePhone, this.Email, new List<Payment>(this.Payments),
                this.CustomerType);
        }

        public static bool operator ==(Customer first, Customer second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Customer first, Customer second)
        {
            return !first.Equals(second);
        }
    }
}
