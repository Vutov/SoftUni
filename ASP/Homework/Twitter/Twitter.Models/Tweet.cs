using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
