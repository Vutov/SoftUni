using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;
using Company_Hierarchy.Utility;

namespace Company_Hierarchy.People
{
    class Developer: Person, IDeveloper
    {
        private List<Project> projects; 

        public List<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public Developer(string firstName, string lastName, int id, List<Project> projects )
            : base(firstName, lastName, id)
        {
            this.Projects = projects;
        }
    }
}
