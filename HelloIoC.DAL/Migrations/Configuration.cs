namespace HelloIoC.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HelloIoC.DAL.ContactDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HelloIoC.DAL.ContactDbContext context)
        {
            context.Contacts.Add(new Contact
            {
                Firstname = "Martin",
                Lastname = "Dybal",
                Email = "martin@dybal.it"
            });
        }
    }
}
