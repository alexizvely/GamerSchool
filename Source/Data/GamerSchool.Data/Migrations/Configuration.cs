﻿namespace GamerSchool.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using GamerSchool.Data.Seed;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            new RolesSeeder().Seed(context);
            new AdminsSeeder().Seed(context);
            new CountriesSeeder().Seed(context);
        }
    }
}
