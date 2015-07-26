namespace CodeFirstPhonebook.Initialization
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class Initializer : DropCreateDatabaseIfModelChanges<PhonesEntitites>
    {
        protected override void Seed(PhonesEntitites context)
        {
            var peter = new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        EmailAddres = "peter@gmail.com"
                    },
                    new Email()
                    {
                        EmailAddres = "peter_ivanov@yahoo.com"
                    }
                },
                Phones = new List<Phone>()
                {
                    new Phone()
                    {
                        PhoneNumber = "+359 2 22 22 22"
                    },
                    new Phone()
                    {
                        PhoneNumber = "+359 88 77 88 99"
                    }
                },
                Site = "http://blog.peter.com",
                Note = "Friend from school"
            };

            context.Contacts.Add(peter);

            var maria = new Contact()
            {
                Name = "Maria",
                Phones = new List<Phone>()
                {
                    new Phone()
                    {
                        PhoneNumber = "+359 22 33 44 55"
                    }
                }
            };

            context.Contacts.Add(maria);

            var angie = new Contact()
            {
                Name = "Angie Stanton",
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        EmailAddres = "info@angiestanton.com"
                    }
                },
                Site = "http://angiestanton.com"
            };

            context.Contacts.Add(angie);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
