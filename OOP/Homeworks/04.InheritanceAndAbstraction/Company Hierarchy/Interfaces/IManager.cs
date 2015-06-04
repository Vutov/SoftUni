using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.People;

namespace Company_Hierarchy.Interfaces
{
    interface IManager
    {
        List<Employee> Employees { get; set; }
    }
}
