using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Company_Hierarchy.Interfaces;
using Company_Hierarchy.People;

namespace Company_Hierarchy.Utility
{
    class Project : IProject
    {
        private string name;
        private DateTime startDate;
        private string details;
        private State state;

        public string Name
        {
            get { return this.name; }
            set {
                if (Person.IsValidName(value))
                {
                    this.name = value;
                }
            }
        }

        public DateTime StartDate { get; set; }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public State State { get; set; }

        public Project(string name, DateTime date, string details, State state)
        {
            this.Name = name;
            this.StartDate = date;
            this.Details = details;
            this.State = state;
        }

        public void CloseProject()
        {
            this.State = State.Closed;
        }
    }
}
