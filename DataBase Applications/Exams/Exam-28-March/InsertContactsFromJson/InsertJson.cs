namespace InsertContactsFromJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;
    using CodeFirstPhonebook;
    using CodeFirstPhonebook.Models;

    class InsertJson
    {
        static void Main(string[] args)
        {
            var serializer = new JavaScriptSerializer();
            var json = File.ReadAllText("../../../contacts.json");
            var contacts = serializer.Deserialize<JsonContact[]>(json);
            var context = new PhonesEntitites();

            foreach (var contact in contacts)
            {
                try
                {
                    if (contact.Name == null)
                    {
                        throw new ArgumentException("Name is required");
                    }

                    var emails = new List<Email>();
                    if (contact.Emails != null)
                    {
                        foreach (var email in contact.Emails)
                        {
                            emails.Add(new Email()
                            {
                                EmailAddres = email
                            });
                        }
                    }

                    var phones = new List<Phone>();
                    if (contact.Phones != null)
                    {
                        foreach (var phone in contact.Phones)
                        {
                            phones.Add(new Phone()
                            {
                                PhoneNumber = phone
                            });
                        }
                    }

                    var newContact = new Contact()
                    {
                        Name = contact.Name,
                        Company = contact.Company,
                        Emails = emails,
                        Phones = phones,
                        Note = contact.Note,
                        Position = contact.Position,
                        Site = contact.Site
                    };

                    context.Contacts.Add(newContact);
                    context.SaveChanges();
                    Console.WriteLine("Contact {0} imported", newContact.Name);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine("Error: {0}", ex.Message);
                }
            }
        }
    }
}
