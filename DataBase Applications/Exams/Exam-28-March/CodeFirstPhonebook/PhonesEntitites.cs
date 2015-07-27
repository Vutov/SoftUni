namespace CodeFirstPhonebook
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Initialization;
    using Models;

    public class PhonesEntitites : DbContext
    {
        public PhonesEntitites()
            : base("name=PhonesEntitites")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
    }
}