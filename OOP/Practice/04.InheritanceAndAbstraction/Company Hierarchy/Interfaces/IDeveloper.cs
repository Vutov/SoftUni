using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Utility;

namespace Company_Hierarchy.Interfaces
{
    interface IDeveloper
    {
        List<Project> Projects { get; set; }
    }
}
