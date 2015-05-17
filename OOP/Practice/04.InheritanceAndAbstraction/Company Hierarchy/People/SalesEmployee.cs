using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;
using Company_Hierarchy.Utility;

namespace Company_Hierarchy.People
{
    class SalesEmployee : Person, ISalesEmployee
    {
        public List<Sale> Sales { get; set; }

        public SalesEmployee(string firstName, string lastName, int id, List<Sale> sales)
            : base(firstName, lastName, id)
        {
            this.Sales = sales;
        }
    }
}
