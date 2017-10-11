using System.Data.Entity;

namespace HelloIoC.DAL
{
    public class ContactDbContext : DbContext
    {
        public IDbSet<Contact> Contacts { get; set; }

        public ContactDbContext() :base("ContactDb")
        {
            
        }
    }
}