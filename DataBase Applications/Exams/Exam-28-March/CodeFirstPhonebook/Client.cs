using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPhonebook
{
    class Client
    {
        static void Main(string[] args)
        {
            var context = new PhonesEntitites();
            var contacts = context.Contacts
                .Select(c => new
                {
                    c.Name,
                    PhoneNumbers = c.Phones.Select(n => n.PhoneNumber),
                    Emails = c.Emails.Select(e => e.EmailAddres),
                })
                .ToList();
            contacts.ForEach(c =>
            {
                Console.WriteLine("{0}:\n phone numbers: {1}\nemails: {2}",
                    c.Name,
                    string.Join(", ", c.PhoneNumbers),
                    string.Join(", ", c.Emails));   
            });
        }
    }
}
