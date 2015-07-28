namespace CodeFirstPhonebook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public virtual User Recipiant { get; set; }

        public virtual User Sender { get; set; }
    }
}
