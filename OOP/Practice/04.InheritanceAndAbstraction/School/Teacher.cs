using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher : Person
    {
        public List<Discipline> Disciplines { get; set; }

        public Teacher(string name, List<Discipline> disciplines, string details = null)
        {
            this.Name = name;
            this.Disciplines = disciplines;
            this.Details = details;
        }
    }
}
