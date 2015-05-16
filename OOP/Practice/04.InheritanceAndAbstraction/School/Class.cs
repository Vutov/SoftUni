using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class
    {
        public string Id { get; set; }
        public List<Teacher> Teachers { get; set; }
        public string Details { get; set; }

        public Class(string id, List<Teacher> teachers, string details = null)
        {
            this.Id = id;
            this.Teachers = teachers;
            this.Details = details;
        }
    }
}
