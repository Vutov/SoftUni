using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.People;

namespace Company_Hierarchy.Interfaces
{
    interface IEmployee
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}
