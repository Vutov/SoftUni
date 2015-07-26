namespace CodeFirstPhonebook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

    }
}
