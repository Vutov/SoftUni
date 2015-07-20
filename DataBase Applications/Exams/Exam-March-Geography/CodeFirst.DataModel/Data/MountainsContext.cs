namespace CodeFirst.DataModel.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class MountainsContext : DbContext
    {
        public MountainsContext()
            : base("name=MountainsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
    }
}