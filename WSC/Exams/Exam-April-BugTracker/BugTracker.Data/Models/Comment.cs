namespace BugTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public Bug Bug { get; set; }
    }
}
