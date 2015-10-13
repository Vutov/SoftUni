using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
