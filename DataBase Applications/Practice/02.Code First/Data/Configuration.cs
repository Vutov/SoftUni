using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Models;

namespace Data
{
    public sealed class Configuration : DbMigrationsConfiguration<SystemDBContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}